using System;
using System.Collections.Generic;

namespace CapaDatosWebEmpresa.Models;

public partial class Proveedore
{
    public int IdProveedor { get; set; }

    public string NombreCompañía { get; set; } = null!;

    public string? Dirección { get; set; }

    public string? Ciudad { get; set; }

    public string? País { get; set; }

    public string? Teléfono { get; set; }

    public string? PáginaPrincipal { get; set; }

    public virtual ICollection<Producto> Productos { get; set; } = new List<Producto>();
}
