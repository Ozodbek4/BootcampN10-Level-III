using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using N70.Identity.Application.Common.Identity.Services;
using N70.Identity.Application.Common.Notifications.Services;
using N70.Identity.Application.Common.Settings;
using N70.Identity.Infrastructure.Common.Identity.Services;
using N70.Identity.Infrastructure.Common.Notification.Services;
using System.Text;

namespace N70.Identity.Api.Configurations;

public static partial class HostConfigurations
{
    private static WebApplicationBuilder AddHttpContextProvider(this WebApplicationBuilder builder)
    {
        builder.Services.AddHttpContextAccessor();

        return builder;
    }

    private static WebApplicationBuilder AddPersistence(this WebApplicationBuilder builder)
    {
        builder.Services.AddDbContext<DbContext>(options =>
            options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

        return builder;
    }

    private static WebApplicationBuilder AddIdentityInfrastructure(this WebApplicationBuilder builder)
    {
        builder.Services.Configure<JwtSettings>(builder.Configuration.GetSection(nameof(JwtSettings)));
        builder.Services.Configure<VerificationTokenSettings>(builder.Configuration.GetSection(nameof(VerificationTokenSettings)));

        builder.Services
            .AddTransient<IPasswordHasherService, PasswordHasherService>()
            .AddTransient<ITokenGeneratorService, TokenGeneratorService>()
            .AddTransient<IVerificationTokenGeneratorService, VerificationTokenGeneratorService>();

        builder.Services
            .AddScoped<IAccountService, AccountService>()
            .AddScoped<IUserService, UserService>()
            .AddScoped<IAuthService, AuthService>()
            .AddScoped<IRoleService, RoleService>()
            .AddScoped<IAccessTokenService, AccessTokenService>();

        var jwtSettings = new JwtSettings();
        builder.Configuration.GetSection(nameof(jwtSettings)).Bind(jwtSettings);

        builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options =>
            {
                options.RequireHttpsMetadata = false;

                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = jwtSettings.ValidateIssuer,
                    ValidIssuer = jwtSettings.ValidIssuer,
                    ValidAudience = jwtSettings.ValidAudience,
                    ValidateAudience = jwtSettings.ValidateAudience,
                    ValidateLifetime = jwtSettings.ValidLifeTime,
                    ValidateIssuerSigningKey = jwtSettings.ValidateIssuerSingingKey,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings.SecretKey))
                };
            });

        return builder;
    }

    private static WebApplicationBuilder AddNotificationInfrastructure(this WebApplicationBuilder builder)
    {
        builder.Services.Configure<EmailSenderSettings>(builder.Configuration.GetSection(nameof(EmailSenderSettings)));

        builder.Services.AddScoped<IEmailOrchestrationService, EmailOrchestrationService>();

        return builder;
    }

    private static WebApplicationBuilder AddDevTools(this WebApplicationBuilder builder)
    {
        builder.Services.AddSwaggerGen();
        builder.Services.AddEndpointsApiExplorer();

        return builder;
    }

    private static WebApplicationBuilder AddExposers(this WebApplicationBuilder builder)
    {
        builder.Services.AddRouting(options => options.LowercaseUrls = true);
        builder.Services.AddControllers();

        return builder;
    }

    private static WebApplication AddIdentityInfrastrucutre(this WebApplication app)
    {
        app.UseAuthentication();
        app.UseAuthorization();

        return app;
    }

    private static WebApplication AddDevTools(this WebApplication app)
    {
        app.UseSwagger();
        app.UseSwaggerUI();

        return app;
    }

    private static WebApplication AddExposers(this WebApplication app)
    {
        app.MapControllers();

        return app;
    }
}