using System;
using System.Collections.Generic;

namespace GYMBros_GABGS.Models;

public partial class CategoriaProducto
{
    public int IdcategoriaProducto { get; set; }

    public string Nombre { get; set; }

    public string Descripcion { get; set; }

    public virtual ICollection<ProductosVentum> ProductosVenta { get; set; } = new List<ProductosVentum>();
}
