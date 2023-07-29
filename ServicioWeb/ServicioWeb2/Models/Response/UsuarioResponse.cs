namespace ServicioWeb2.Models.Response
{
  public class UsuarioResponse
  {
    public string Email { get; set; }


    //el token sirve para que te loguees una sola ves y despues puedas ingresar de forma rapida
    public string Token { get; set; } 
  }
}
