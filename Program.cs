using FazendaUrbanaApi.Data;
using FazendaUrbanaApi.Services.Clientes;

using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IClienteInterface, ClienteService>();
builder.Services.AddScoped<IClienteLoginInterface, LoginClienteService>();
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
Console.WriteLine($"String de conexão usada: {connectionString}");
builder.Services.AddDbContext<TetoVerdeContext>(options => options.UseSqlServer(connectionString));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();