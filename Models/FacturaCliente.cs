using System;
using System.Collections.Generic;

namespace GYMBros_GABGS.Models;

public partial class FacturaCliente
{
    public int Idfactura { get; set; }

    public int IdclienteMembresia { get; set; }

    public DateOnly FechaEmicion { get; set; }

    public string MetodoPago { get; set; }

    public virtual ClienteMembresium IdclienteMembresiaNavigation { get; set; }
}
