using System;
using System.Collections.Generic;

namespace GYMBros_GABGS.Models;

public partial class Clase
{
    public int Idclase { get; set; }

    public int Idmatricula { get; set; }

    public int Idactividad { get; set; }

    public int Idempleado { get; set; }

    public int Idsala { get; set; }

    public DateOnly FechaClase { get; set; }

    public TimeOnly HoraInicio { get; set; }

    public TimeOnly HoraFin { get; set; }

    public bool Estado { get; set; }

    public int Capacidad { get; set; }

    public virtual Actividade IdactividadNavigation { get; set; }

    public virtual Empleado IdempleadoNavigation { get; set; }

    public virtual Martricula IdmatriculaNavigation { get; set; }

    public virtual Sala IdsalaNavigation { get; set; }
}
