using Microsoft.EntityFrameworkCore;
using ServicioWeb2.Models;
using ServicioWeb2.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using ServicioWeb2.Models.Common;

var builder = WebApplication.CreateBuilder(args);


//Configuracion del JWT

builder.Configuration.AddJsonFile("appsettings.json");
var appSettingsSection = builder.Configuration.GetSection("AppSettings");
builder.Services.Configure<AppSettings>(appSettingsSection);

//Creacion del JWT
var appSettings = appSettingsSection.Get<AppSettings>();
var llave = Encoding.ASCII.GetBytes(appSettings.Secreto);//Arreglo de bytes
builder.Services.AddAuthentication(config =>
{
  config.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
  config.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}
).AddJwtBearer(config =>
{
  config.RequireHttpsMetadata= false;
  config.SaveToken = true;
  config.TokenValidationParameters = new TokenValidationParameters
  {
    ValidateIssuerSigningKey = true,
    IssuerSigningKey = new SymmetricSecurityKey(llave),
    ValidateIssuer = false,
    ValidateAudience = false
  };
});


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



//para inyeccion de dependencias
builder.Services.AddScoped<IUsuarioService, UsuarioService>(); 

var app = builder.Build();

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{

//}

app.UseSwagger();
app.UseSwaggerUI();


//Se activan los cors
app.UseCors(MyCors);

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
