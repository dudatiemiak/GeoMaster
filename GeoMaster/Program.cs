using GeoMaster.Domain.Factories;
using GeoMaster.Domain.Entities;
using GeoMaster.Application.Interfaces;
using System.Reflection;
using GeoMaster.GeoMaster.Application.Interfaces;
using GeoMaster.GeoMaster.Application.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    // Inclui comentários XML dos controllers e DTOs
    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    if (File.Exists(xmlPath))
    {
        c.IncludeXmlComments(xmlPath, includeControllerXmlComments: true);
    }
});
builder.Services.AddScoped<ICalculadoraService, GeoMaster.Application.Services.CalculadoraService>();
builder.Services.AddScoped<IFormaContidaService, FormaContidaService>();

var shape2DFactory = new Shape2DFactory();
shape2DFactory.Register("circulo", args => new Circulo((double)args[0]));
shape2DFactory.Register("retangulo", args => new Retangulo((double)args[0], (double)args[1]));

var shape3DFactory = new Shape3DFactory();
shape3DFactory.Register("esfera", args => new Esfera((double)args[0]));

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
