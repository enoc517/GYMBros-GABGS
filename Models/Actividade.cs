using System;
using System.Collections.Generic;

namespace GYMBros_GABGS.Models;

public partial class Actividade
{
    public int Idactividades { get; set; }

    public string Descripcion { get; set; }

    public virtual ICollection<Clase> Clases { get; set; } = new List<Clase>();
}
