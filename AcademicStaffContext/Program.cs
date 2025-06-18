using AcademicStaff.Application.Internal.CommandServices;
using AcademicStaff.Application.Internal.QueryServices;
using AcademicStaffContext.AcademicStaff.Application.Internal.CommandServices;
using AcademicStaffContext.AcademicStaff.Application.Internal.QueryServices;
using AcademicStaffContext.AcademicStaff.Domain.Repositories;
using AcademicStaffContext.AcademicStaff.Infrastructure.Persistence.EFC.Repositories;
using AcademicStaffContext.Shared.Infraestructure.Persistence.EFC.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Configurar DbContext con MySQL
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseMySql(
        builder.Configuration.GetConnectionString("DefaultConnection"),
        ServerVersion.AutoDetect(builder.Configuration.GetConnectionString("DefaultConnection"))));

// Repositorios
builder.Services.AddScoped<ITeacherRepository, TeacherRepository>();
builder.Services.AddScoped<IDepartmentRepository, DepartmentRepository>();


// Servicios de Aplicación
builder.Services.AddScoped<TeacherCommandService>();
builder.Services.AddScoped<TeacherQueryService>();
builder.Services.AddScoped<DepartmentCommandService>();
builder.Services.AddScoped<DepartmentQueryService>();

// Controladores
builder.Services.AddControllers();

// Swagger/OpenAPI
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "AcademicStaff API",
        Version = "v1",
        Description = "API para la gestión de profesores (AcademicStaffContext)"
    });

    // Habilita anotaciones como [SwaggerOperation]
    c.EnableAnnotations();
});

var app = builder.Build();

// Middleware
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "AcademicStaff API V1");
    });
}

// Seguridad básica
app.UseHttpsRedirection();
app.UseAuthorization();

// Rutas de controladores
app.MapControllers();

// Ejecutar app
app.Run();
