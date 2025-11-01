using Microsoft.EntityFrameworkCore;
using PaymentApi.Data;
using PaymentApi.Services;

var builder = WebApplication.CreateBuilder(args);

// Base de datos en memoria (simple para pruebas)
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseInMemoryDatabase("PaymentsDb"));

// Servicio de negocio
builder.Services.AddScoped<PaymentService>();

// Controladores
builder.Services.AddControllers();

// Swagger clásico (.NET 8)
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.MapControllers();
app.Run();
