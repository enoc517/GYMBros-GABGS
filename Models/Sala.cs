using System;
using System.Collections.Generic;

namespace GYMBros_GABGS.Models;

public partial class Sala
{
    public int Idsala { get; set; }

    public DateOnly Dia { get; set; }

    public int Cupo { get; set; }

    public string Descripción { get; set; }

    public virtual ICollection<Clase> Clases { get; set; } = new List<Clase>();
}
