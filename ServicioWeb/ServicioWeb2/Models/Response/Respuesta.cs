namespace ServicioWeb2.Models.Response
{
  public class Respuesta
  {
    public int Exito { get; set; }
    public string Mensaje { get; set; } = null!;
    public object Data { get; set; } = null!;

    public Respuesta() => this.Exito= 0;
  }
}
