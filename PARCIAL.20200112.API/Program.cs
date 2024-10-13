using Microsoft.EntityFrameworkCore;
using PARCIAL._20200112.DOMAIN.Core.Interfaces;
using PARCIAL._20200112.DOMAIN.Infrastructure.Data;
using PARCIAL._20200112.DOMAIN.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var _config = builder.Configuration;
var cnx = _config.GetConnectionString("DevConnection");
builder.Services
    .AddDbContext<Parcial20240220200112DbContext>
    (options => options.UseSqlServer(cnx));

builder.Services.AddTransient<IMechanicRepository, MechanicRepository>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
