using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GYMBros_GABGS.Models;

public partial class Jornada
{
    public int Idjornadas { get; set; }

    public int Idempleado { get; set; }
    [DataType(DataType.Date)]
    public DateOnly FechaInicio { get; set; }
    [DataType(DataType.Date)]
    public DateOnly FechaFin { get; set; }

    public decimal HorasTrabajadas { get; set; }

    public virtual ICollection<GeneracionPago> GeneracionPagos { get; set; } = new List<GeneracionPago>();

    public virtual Empleado IdempleadoNavigation { get; set; }
}
