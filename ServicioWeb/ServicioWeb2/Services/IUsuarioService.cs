using ServicioWeb2.Models.Request;
using ServicioWeb2.Models.Response;

namespace ServicioWeb2.Services
{
  public interface IUsuarioService
  {
    UsuarioResponse Autent(AutenticacionRequest model);
  }
}
