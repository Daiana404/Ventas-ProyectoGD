using Microsoft.EntityFrameworkCore;
using ServicioWeb2.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<VentasRealContext>(opt => opt.UseSqlServer(builder.Configuration.GetConnectionString("conn")));

//Configuracion de los cors (investigar)
var MyCors = "ReglasCors";
builder.Services.AddCors(opt =>
{
  opt.AddPolicy(name: MyCors, builder =>
  {
    builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
  });

});


var app = builder.Build();

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{

//}

app.UseSwagger();
app.UseSwaggerUI();


//Se activan los cors
app.UseCors(MyCors);

app.UseAuthorization();

app.MapControllers();

app.Run();
