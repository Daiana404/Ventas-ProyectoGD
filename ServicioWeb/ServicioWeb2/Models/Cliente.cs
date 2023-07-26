using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace ServicioWeb2.Models;

public partial class Cliente
{
    public long Id { get; set; }
  
    public string? Nombre { get; set; } 

    public string? Apellido { get; set; }

    [JsonIgnore]
    public virtual ICollection<Venta> Venta { get; set; } = new List<Venta>();
}
