using EduflowBackend.Shared.Domain.Repositories;
using EduflowBackend.Shared.Infrastructure.Persistence.EFC.Configuration;
using EduflowBackend.Shared.Infrastructure.Persistence.EFC.Repositories;
using EduflowBackend.Shared.Interfaces.ASP.Configuration;

using EduflowBackend.Profiles.Domain.Repositories;
using EduflowBackend.Profiles.Domain.Services;
using EduflowBackend.Profiles.Application.Internal.CommandServices;
using EduflowBackend.Profiles.Application.Internal.QueryServices;
using EduflowBackend.Profiles.Infrastructure.Persistence.EFC.Repositories;

using Microsoft.EntityFrameworkCore;

using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add controllers and kebab-case route naming
builder.Services.AddRouting(options => options.LowercaseUrls = true);
builder.Services.AddControllers(options => options.Conventions.Add(new KebabCaseRouteNamingConvention()));

// Configure Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Eduflow API - Profiles",
        Version = "v1",
        Description = "REST API for managing user profiles in Eduflow."
    });
    options.EnableAnnotations();
});

// CORS policy
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
        policy.AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader());
});

// Configure MySQL connection
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
if (string.IsNullOrEmpty(connectionString))
    throw new InvalidOperationException("Missing connection string: DefaultConnection");

builder.Services.AddDbContext<AppDbContext>(options =>
{
    if (builder.Environment.IsDevelopment())
    {
        options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString))
               .LogTo(Console.WriteLine, LogLevel.Information)
               .EnableSensitiveDataLogging()
               .EnableDetailedErrors();
    }
    else
    {
        options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
    }
});

// Register shared services
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

// Register Profiles context services
builder.Services.AddScoped<IProfileRepository, ProfileRepository>();
builder.Services.AddScoped<IProfileCommandService, ProfileCommandService>();
builder.Services.AddScoped<IProfileQueryService, ProfileQueryService>();

var app = builder.Build();

// Ensure DB is created
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var dbContext = services.GetRequiredService<AppDbContext>();
    dbContext.Database.EnsureCreated();
}

// Middleware
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Eduflow API V1");
        c.RoutePrefix = string.Empty;
    });
}

app.UseHttpsRedirection();
app.UseCors("AllowAll");
app.UseAuthorization();
app.MapControllers();

app.Run();
