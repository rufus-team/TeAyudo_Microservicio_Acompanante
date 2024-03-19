using Application.Interfaces.Commands;
using Application.Interfaces.Querys;
using Application.Interfaces.Service;
using Application.Services;
using Infrastructure.Commands;
using Infrastructure.Persistence;
using Infrastructure.Querys;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;

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

builder.Services.AddTransient<ITagService, TagService>();

builder.Services.AddTransient<ITagQuery, TagQuery>();

string ClaveSecreta = builder.Configuration.GetValue<string>("JwtSettings:Key");
Byte[] KeyBytes = Encoding.ASCII.GetBytes(ClaveSecreta);

builder.Services.AddAuthentication(s => {
    s.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    s.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(s =>
{
    s.RequireHttpsMetadata = false;
    s.SaveToken = true;
    s.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(KeyBytes),
        ValidateIssuer = false,
        ValidateAudience = false,
        ValidateLifetime = true,
        ClockSkew = TimeSpan.Zero,
    };
});


builder.Services.AddCors(x => x.AddDefaultPolicy(c => c.AllowAnyHeader().AllowAnyOrigin().AllowAnyMethod()));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors();

app.UseAuthentication();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
