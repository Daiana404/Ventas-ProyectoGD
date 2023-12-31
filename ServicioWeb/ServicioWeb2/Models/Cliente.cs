﻿using System;
using System.Collections.Generic;

namespace ServicioWeb2.Models;

public partial class Cliente
{
    public long Id { get; set; }

    public string Nombre { get; set; } = null!;

    public string Apellido { get; set; } = null!;

    public virtual ICollection<Venta> Venta { get; set; } = new List<Venta>();
}
