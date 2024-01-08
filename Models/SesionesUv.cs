using System;
using System.Collections.Generic;

namespace GYMBros_GABGS.Models;

public partial class SesionesUv
{
    public int Idsesiones { get; set; }

    public int IdclienteMembresia { get; set; }

    public int CantidadSesiones { get; set; }

    public DateOnly FechaSesion { get; set; }

    public TimeOnly HoraSesion { get; set; }

    public int Disponibles { get; set; }

    public virtual ClienteMembresium IdclienteMembresiaNavigation { get; set; }
}
