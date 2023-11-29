using Interceptor.Application.Common.Services;
using Interceptor.Domain.Settings;
using Interceptor.Infrastructure.Common.Services;
using Interceptor.Persistence.DataContext;
using Interceptor.Persistence.Interceptors;
using Interceptor.Persistence.Repository;
using Interceptor.Persistence.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var assemblies = Assembly.GetExecutingAssembly().GetReferencedAssemblies().Select(Assembly.Load).ToList();
assemblies.Add(Assembly.GetExecutingAssembly());

builder.Services
    .AddScoped<AuditableInterceptor>()
    .AddScoped<CreationInterceptor>()
    .AddScoped<DeletedInterceptor>()
    .AddScoped<ModifiedInterceptor>()
    .AddScoped<SoftDeletedInterceptor>();

builder.Services
    .AddAutoMapper(assemblies);

builder.Services
    .Configure<AuditableSettings>(builder.Configuration.GetSection(nameof(AuditableSettings)));

builder.Services
    .AddDbContext<IdentityDbContext>((provider, option) =>
    {
        option.UseNpgsql("Host=localhost;Port=5432;Database=N76Hometask;Username=postgres;Password=postgres;");
        option
            .AddInterceptors(provider.CreateScope().ServiceProvider.GetRequiredService<AuditableInterceptor>())
            .AddInterceptors(provider.CreateScope().ServiceProvider.GetRequiredService<CreationInterceptor>())
            .AddInterceptors(provider.CreateScope().ServiceProvider.GetRequiredService<DeletedInterceptor>())
            .AddInterceptors(provider.CreateScope().ServiceProvider.GetRequiredService<ModifiedInterceptor>())
            .AddInterceptors(provider.CreateScope().ServiceProvider.GetRequiredService<SoftDeletedInterceptor>());
    });

builder.Services
    .AddScoped<IUserService, UserService>()
    .AddScoped<IUserRepository, UserRepository>();

builder.Services
    .AddControllers();

builder.Services
    .AddSwaggerGen()
    .AddEndpointsApiExplorer();

var app = builder.Build();

// Configure the HTTP request pipeline.

app
    .UseSwagger()
    .UseSwaggerUI();

app.MapControllers();

app.Run();