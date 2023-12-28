using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Notification.Application.Common.Identities.Services;
using Notification.Application.Common.Notifications.Brokers;
using Notification.Application.Common.Notifications.Services;
using Notification.Infrastructure.Identities.Services;
using Notification.Infrastructure.Notifications.Brokers;
using Notification.Infrastructure.Settings;
using Notification.Persistence.DataContexts;
using Notification.Persistence.Repositories;
using Notification.Persistence.Repositories.Interfaces;
using Notifications.Infrastructure.Infrastrucutre.Common.Notifications.Services;
using System.Reflection;

namespace Notification.Api.Configurations;

public static partial class HostConfiguration
{
    private static IList<Assembly> Assemblies;
    
    static HostConfiguration()
    {
        Assemblies = Assembly
            .GetExecutingAssembly()
            .GetReferencedAssemblies()
            .Select(Assembly.Load).ToList();

        Assemblies.Add(Assembly.GetExecutingAssembly());
    }

    static WebApplicationBuilder AddValidators(this WebApplicationBuilder builder)
    {


        builder.Services.AddValidatorsFromAssemblies(Assemblies);

        return builder;
    }

    private static WebApplicationBuilder AddMappers(this WebApplicationBuilder builder)
    {
        builder.Services.AddAutoMapper(Assemblies);

        return builder;
    }

    private static WebApplicationBuilder AddIdentityInfrastructure(this WebApplicationBuilder builder)
    {
        // register configurations
        builder.Services
            .AddScoped<IUserRepository, UserRepository>()
            .AddScoped<IUserSettingsRepository, UserSettingsRepository>();

        builder.Services
            .AddScoped<IUserService, UserService>()
            .AddScoped<IUserSettingsService, UserSettingsService>();

        return builder;
    }

    private static WebApplicationBuilder AddNotificationInfrastructure(this WebApplicationBuilder builder)
    {
        // register configurations 
        builder.Services
            .Configure<TemplateRenderingSettings>(builder.Configuration.GetSection(nameof(TemplateRenderingSettings)))
            .Configure<SmtpEmailSenderSettings>(builder.Configuration.GetSection(nameof(SmtpEmailSenderSettings)))
            .Configure<TwilioSmsSenderSettings>(builder.Configuration.GetSection(nameof(TwilioSmsSenderSettings)))
            .Configure<NotificationSettings>(builder.Configuration.GetSection(nameof(NotificationSettings)));

        // register persistence
        builder.Services.AddDbContext<NotificationDbContext>(options =>
            options.UseNpgsql(builder.Configuration.GetConnectionString("NotificationsDatabaseConnection")));

        builder.Services.AddScoped<IEmailTemplateRepository, EmailTemplateRepository>()
            .AddScoped<ISmsTemplateRepository, SmsTemplateRepository>()
            .AddScoped<IEmailHistoryRepository, EmailHistoryRepository>()
            .AddScoped<ISmsHistoryRepository, SmsHistoryRepository>();

        // register brokers
        builder.Services.AddScoped<ISmsSenderBroker, TwilioSmsSenderBroker>()
            .AddScoped<IEmailSenderBroker, SmtpEmailSenderBroker>();

        // register data access foundation services
        builder.Services.AddScoped<ISmsTemplateService, SmsTemplateService>()
            .AddScoped<IEmailTemplateService, EmailTemplateService>()
            .AddScoped<IEmailHistoryService, EmailHistoryService>()
            .AddScoped<ISmsHistoryService, SmsHistoryService>();

        // register helper foundation services
        builder.Services.AddScoped<IEmailSenderService, EmailSenderService>()
            .AddScoped<ISmsSenderService, SmsSenderService>()
            .AddScoped<IEmailRenderingService, EmailRenderingService>()
            .AddScoped<ISmsRenderingService, SmsRenderingService>();

        // register orchestration and aggregation services
        builder.Services.AddScoped<ISmsOrchestrationService, SmsOrchestrationService>()
            .AddScoped<IEmailOrchestrationService, EmailOrchestrationService>()
            .AddScoped<INotificationAggregatorService, NotificationAggregatorService>();

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
        builder.Services.AddRouting(route => route.LowercaseUrls = true);
        builder.Services.AddControllers();

        return builder;
    }

    private static WebApplication UseDevTools(this WebApplication app)
    {
        app.UseSwagger();
        app.UseSwaggerUI();

        return app;
    }

    private static WebApplication UseExposers(this WebApplication app)
    {
        app.MapControllers();

        return app;
    }
}