using Application.Interfaces;
using Application.Services;
using Infrastructure.Commands;
using Infrastructure.Persistence;
using Infrastructure.Querys;
using Microsoft.EntityFrameworkCore;
using TeAyudo_Microservicio_Acompanante.Controllers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();



builder.Services.AddDbContext<AcompananteContext>(options =>
{
    options.UseSqlServer("Server=localhost;Database=AcompananteDB;Trusted_Connection=True;TrustServerCertificate=True;Persist Security Info=true");
});


builder.Services.AddTransient<IAcompananteService, AcompananteService>();
builder.Services.AddTransient<IHorariosService, HorariosService>();

builder.Services.AddTransient<IAcompananteQuery, AcompananteQuery>();
builder.Services.AddTransient<IAcompananteCommand, AcompananteCommand>();

builder.Services.AddTransient<IHorariosCommand, HorariosCommand>();
builder.Services.AddTransient<IHorariosQuery, HorariosQuery>();




builder.Services.AddCors(x => x.AddDefaultPolicy(c => c.AllowAnyHeader().AllowAnyOrigin().AllowAnyMethod()));

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
