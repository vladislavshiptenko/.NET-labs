using Core.Models.Users;
using DataAccess.Extensions;
using Framework.Handlers;
using Framework.Requirements;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;

#pragma warning disable ASP0000

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddDataAccess(configuration =>
{
    configuration.Host = "localhost";
    configuration.Port = 5432;

    configuration.Username = "postgres";
    configuration.Password = "postgres";
    configuration.Database = "postgres";
    configuration.SslMode = "Prefer";
});

ServiceProvider provider = builder.Services.BuildServiceProvider();
using IServiceScope scope = provider.CreateScope();

scope.UseDataAccess();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAuthentication("BasicAuthentication")
    .AddScheme<AuthenticationSchemeOptions, AuthenticationHandler>("BasicAuthentication", null);
builder.Services.AddHttpContextAccessor();
builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("AdminOnly", policy => policy.RequireRole(UserRole.Admin));
    options.AddPolicy("AllowUser", policy => policy.Requirements.Add(new AccountIdAccess()));
});
builder.Services.AddScoped<IAuthorizationHandler, UserAuthorizationHandler>();

WebApplication app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
        options.RoutePrefix = string.Empty;
    });
}

app.UseRouting();
app.MapControllers();
app.UseAuthorization();

app.Run();