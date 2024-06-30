using System;
using System.Collections.Generic;

namespace CapaDatosWebEmpresa.Models;

public partial class Cliente
{
    public string IdCliente { get; set; } = null!;

    public string NombreCompañía { get; set; } = null!;

    public string? NombreContacto { get; set; }

    public string? CargoContacto { get; set; }

    public string? Dirección { get; set; }

    public string? Ciudad { get; set; }

    public string? País { get; set; }

    public string? Teléfono { get; set; }

    public virtual ICollection<Pedido> Pedidos { get; set; } = new List<Pedido>();
}
