using Microsoft.EntityFrameworkCore;
using EduflowAdminBackend.Data;

var builder = WebApplication.CreateBuilder(args);

// Agregar DbContext con MySQL
builder.Services.AddDbContext<AdminContext>(options =>
    options.UseMySql(builder.Configuration.GetConnectionString("DefaultConnection"),
        ServerVersion.AutoDetect(builder.Configuration.GetConnectionString("DefaultConnection"))));

// Agregar controladores
builder.Services.AddControllers();

// Agregar Swagger (opcional pero útil)
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configurar el pipeline de HTTP
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseRouting();
app.UseAuthorization();
app.MapControllers();

app.Run();