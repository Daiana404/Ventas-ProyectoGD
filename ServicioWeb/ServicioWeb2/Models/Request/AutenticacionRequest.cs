using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace ServicioWeb2.Models.Request
{
  public class AutenticacionRequest
  {
    [Required]
    public string Email { get; set; }
    [Required]
    public string Contraseña { get; set; }
  }
}
