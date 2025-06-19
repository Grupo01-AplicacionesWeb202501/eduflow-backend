var builder = WebApplication.CreateBuilder(args);

// Register controllers
builder.Services.AddControllers();

// Register Swagger/OpenAPI
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Enable Swagger UI in development
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// Enable routing and controllers
app.UseAuthorization();
app.MapControllers();

app.Run();