using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ServicioWeb2.Models;
using ServicioWeb2.Models.Response;
using ServicioWeb2.Models.Request;
using Microsoft.EntityFrameworkCore;


namespace ServicioWeb2.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class ClienteController : ControllerBase
  {
    public readonly VentasRealContext _dbcontext;

    public ClienteController(VentasRealContext _context)
    {
      _dbcontext = _context;
    }

    [HttpGet]
    [Route("Lista")]
    public IActionResult Get()
    {
      Respuesta oRespuesta = new Respuesta();
      try
      {
        using (_dbcontext)
        {
          var lt = _dbcontext.Clientes.ToList();
          oRespuesta.Exito = 1;
          oRespuesta.Data = lt;
        }
      }
      catch (Exception ex) {
        oRespuesta.Mensaje = ex.Message;
      }

      return Ok(oRespuesta);
    }

    [HttpPost]
    [Route("Nuevo")]
    public IActionResult Post(ClienteRequest oModel)
    {
      Respuesta oRespuesta = new Respuesta();
      try
      {
        using (_dbcontext)
        {
          Cliente oCliente = new Cliente();
          oCliente.Nombre = oModel.Nombre;
          oCliente.Apellido = oModel.Apellido;

          _dbcontext.Clientes.Add(oCliente);
          _dbcontext.SaveChanges();

          oRespuesta.Exito = 1;
        }
      }
      catch (Exception ex)
      {
        oRespuesta.Mensaje=ex.Message;
      }

      return Ok(oRespuesta);
    }

    [HttpPut]
    [Route("Editar")]
    public IActionResult Edit(ClienteRequest oModel)
    {
      Respuesta oRespuesta = new Respuesta();
      try
      {
        using (_dbcontext)
        {
          Cliente oCliente = _dbcontext.Clientes.Find(oModel.Id);
          oCliente.Nombre = oModel.Nombre;
          oCliente.Apellido = oModel.Apellido;

          _dbcontext.Entry(oCliente).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
          _dbcontext.SaveChanges();

          oRespuesta.Exito = 1;
        }
      }
      catch (Exception ex)
      {
        oRespuesta.Mensaje = ex.Message;
      }

      return Ok(oRespuesta);
    }
  }
}
