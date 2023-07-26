using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ServicioWeb2.Models;
using ServicioWeb2.Models.Response;
using ServicioWeb2.Models.Request;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Cors;


namespace ServicioWeb2.Controllers
{
  [EnableCors("ReglasCors")]
  [Route("api/cliente")]
  [ApiController]
  public class ClienteController : ControllerBase
  {
    //Se crea un objeto del tipo contexto de la base de datos
    public readonly VentasRealContext _dbcontext;

    public ClienteController(VentasRealContext _context)
    {
      //En el constructor se le da los atributos
      _dbcontext = _context;
    }


    [HttpGet]
    [Route("lista")]
    public IActionResult Get()
    {
      //Creo un objeto tipo respuesta donde se guarda el estado de la solicitud (1 o 0)
      //un mensaje y la data si se trata de un get
      Respuesta oRespuesta = new Respuesta();
      try
      {
        //Creo un entorno y uso el contexto de la base de datos para comunicarme con las tablas
        using (_dbcontext)
        {
          //Realizo la query
          var lt = _dbcontext.Clientes.ToList();
          //Si la operacion termina bien se cambia el estado de la solicitud y se carga los objetos obtenidos en la query a Data
          oRespuesta.Exito = 1;
          oRespuesta.Data = lt;
        }
      }
      catch (Exception ex) {
        oRespuesta.Mensaje = ex.Message;
      }

      return Ok(oRespuesta);
    }


    [HttpGet]
    [Route("obtener/{id:long}")]
    //Para obtener un solo cliente
    public IActionResult GetCliente(long id)
    {
      Respuesta oRespuesta = new Respuesta();
      try
      {
        using (_dbcontext)
        {
          
          oRespuesta.Data = _dbcontext.Clientes.Find(id);
          if(oRespuesta.Data == null) return Ok(oRespuesta);

          oRespuesta.Exito = 1;
        }
      }
      catch (Exception ex)
      {
        oRespuesta.Mensaje = ex.Message;
      }

      return Ok(oRespuesta);
    }


    [HttpPost]
    [Route("nuevo")]
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
    [Route("editar")]
    public IActionResult Edit(ClienteRequest oModel)
    {
      Respuesta oRespuesta = new Respuesta();
      try
      {
        using (_dbcontext)
        {
          Cliente oCliente = _dbcontext.Clientes.Find(oModel.Id);

          if (oCliente == null) return Ok(oRespuesta);

          //Por si vienen valores nulos se deja el que ya tenia
          oCliente.Nombre = oModel.Nombre is null ? oCliente.Nombre : oModel.Nombre;
          oCliente.Apellido = oModel.Apellido is null ? oCliente.Apellido: oModel.Apellido;

          //_dbcontext.Entry(oCliente).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
          _dbcontext.Clientes.Update(oCliente);
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


    [HttpDelete]
    [Route("eliminar/{id:long}")]
    public IActionResult Delete(long id)
    {
      Respuesta oRespuesta = new Respuesta();
      try
      {
        using (_dbcontext)
        {
          Cliente oCliente = _dbcontext.Clientes.Find(id);

          if (oCliente == null) return Ok(oRespuesta);

          _dbcontext.Clientes.Remove(oCliente);
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
