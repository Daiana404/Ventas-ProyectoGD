using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ServicioWeb2.Models.Request;
using ServicioWeb2.Models.Response;
using ServicioWeb2.Models;
using ServicioWeb2.Services;
using Microsoft.AspNetCore.Authorization;

namespace ServicioWeb2.Controllers
{
  [Route("api/usuario")]
  [ApiController]
  public class UsuarioController : ControllerBase
  {

    //Para atributos privados usamos el guion bajo
    private IUsuarioService _usuarioService;

    //Se realiza la inyeccion
    public UsuarioController(IUsuarioService usuarioService)
    {
      _usuarioService= usuarioService;
    }

    [HttpPost]
    [Route("login")]
    public IActionResult Autentificar([FromBody] AutenticacionRequest model)
    {
      Respuesta respuesta = new Respuesta();

      var userresponse = _usuarioService.Autent(model);

      if (userresponse == null)
      {
        respuesta.Exito = 0;
        respuesta.Mensaje = "Usuario o contraseña incorrecta";
        return BadRequest(respuesta);
      }

      respuesta.Exito = 1;
      respuesta.Mensaje = "Usuario encontrado";
      respuesta.Data = userresponse;
      return Ok(respuesta);
    }

  }
}
