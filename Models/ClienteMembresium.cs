using System;
using System.Collections.Generic;

namespace GYMBros_GABGS.Models;

public partial class ClienteMembresium
{
    public int IdclienteMembresia { get; set; }

    public int IdcategoraMembresia { get; set; }

    public int Idcliente { get; set; }

    public DateOnly FechaProxRenovacion { get; set; }

    public DateOnly FechaInicio { get; set; }

    public DateOnly FechaFin { get; set; }

    public virtual ICollection<FacturaCliente> FacturaClientes { get; set; } = new List<FacturaCliente>();

    public virtual CategoriaMembresium IdcategoraMembresiaNavigation { get; set; }

    public virtual Cliente IdclienteNavigation { get; set; }

    public virtual ICollection<SesionesUv> SesionesUvs { get; set; } = new List<SesionesUv>();
}
