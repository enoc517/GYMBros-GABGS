using System;
using System.Collections.Generic;

namespace GYMBros_GABGS.Models;

public partial class CategoriaMembresium
{
    public int IdcategoriaMembresia { get; set; }

    public string Descripcion { get; set; }

    public decimal Precio { get; set; }

    public string Nombre { get; set; }

    public virtual ICollection<ClienteMembresium> ClienteMembresia { get; set; } = new List<ClienteMembresium>();
}
