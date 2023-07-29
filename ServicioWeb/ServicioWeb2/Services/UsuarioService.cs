using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using ServicioWeb2.Models;
using ServicioWeb2.Models.Common;
using ServicioWeb2.Models.Request;
using ServicioWeb2.Models.Response;
using ServicioWeb2.Tools;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ServicioWeb2.Services
{
  public class UsuarioService: IUsuarioService
  {
    private readonly AppSettings _appsettings;

    VentasRealContext _db;
    public UsuarioService(VentasRealContext db, IOptions<AppSettings> appsettings)
    {
      _db = db;
      _appsettings = appsettings.Value;
    }


    public UsuarioResponse Autent(AutenticacionRequest model)
    {
      UsuarioResponse userresponese = new UsuarioResponse();

        using (_db)
        {
          string scontraseña = Encrypt.GetSHA256(model.Contraseña);

          var usuario = _db.Usuarios.Where(d => d.Email == model.Email && d.Contraseña == scontraseña).First();

          if (usuario == null) return null;

          userresponese.Email = usuario.Email;
          userresponese.Token = GetToken(usuario);

        }


      return userresponese;
    }

    private string GetToken(Usuario usuario)
    {
      var tokenHandler = new JwtSecurityTokenHandler();

      var llave = Encoding.ASCII.GetBytes(_appsettings.Secreto);

      var tokenDescriptor = new SecurityTokenDescriptor
      {
        Subject = new ClaimsIdentity(
          new Claim[]
          {
            new Claim(ClaimTypes.NameIdentifier, usuario.Id.ToString()),
            new Claim(ClaimTypes.Email, usuario.Email)
          }),
        Expires = DateTime.UtcNow.AddDays(60),
        SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(llave), SecurityAlgorithms.HmacSha256Signature)
      };

      var token = tokenHandler.CreateToken(tokenDescriptor);
      return tokenHandler.WriteToken(token);
    }
  }

  
}
