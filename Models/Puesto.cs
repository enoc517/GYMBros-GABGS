using System;
using System.Collections.Generic;

namespace GYMBros_GABGS.Models;

public partial class Puesto
{
    public int Idpuesto { get; set; }

    public decimal PagoHora { get; set; }

    public string Nombre { get; set; }

    public string CategoriaPuesto { get; set; }

    public virtual ICollection<Empleado> Empleados { get; set; } = new List<Empleado>();
}
