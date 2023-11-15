using N70.Identity.Api.Configurations;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var app = builder.Build();

await builder.ConfigureAsync();
// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

await app.ConfigureAsync();

app.Run();