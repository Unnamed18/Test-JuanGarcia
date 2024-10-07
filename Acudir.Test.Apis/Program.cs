using Acudir.Test.Apis.Repositories;
using NombreDelProyecto.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Agregar el servicio de IPersonaRepository antes de construir la app
builder.Services.AddScoped<IPersonaRepository, PersonaRepository>();

// Construir la aplicación
var app = builder.Build();

// Cargar el archivo Test.json después de construir la aplicación
var dataTest = System.IO.File.ReadAllText(Path.Combine(app.Environment.ContentRootPath, "Data/Test.json")); 

IWebHostEnvironment environment = app.Environment;

// Configure the HTTP request pipeline
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();



//var builder = WebApplication.CreateBuilder(args);
//// Add services to the container.
//builder.Services.AddControllers();
//// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
//builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();
//var app = builder.Build();
//var dataTest = System.IO.File.ReadAllText(@"Test.json");

//IWebHostEnvironment environment = app.Environment;
//// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
//    app.UseSwagger();
//    app.UseSwaggerUI();
//}
//app.UseHttpsRedirection();
//app.UseAuthorization();
//app.MapControllers();
//app.Run();