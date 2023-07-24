using System;
using System.Collections.Generic;

namespace ServicioWeb2.Models;

public partial class Producto
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public decimal Preciounitario { get; set; }

    public decimal Costo { get; set; }

    public virtual ICollection<Concepto> Conceptos { get; set; } = new List<Concepto>();
}
