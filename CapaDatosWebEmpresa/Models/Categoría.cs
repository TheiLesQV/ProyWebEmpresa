using System;
using System.Collections.Generic;

namespace CapaDatosWebEmpresa.Models;

public partial class Categoría
{
    public int IdCategoría { get; set; }

    public string NombreCategoría { get; set; } = null!;

    public virtual ICollection<Producto> Productos { get; set; } = new List<Producto>();
}
