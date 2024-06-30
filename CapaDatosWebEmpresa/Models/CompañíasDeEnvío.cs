using System;
using System.Collections.Generic;

namespace CapaDatosWebEmpresa.Models;

public partial class CompañíasDeEnvío
{
    public int IdCompañíaEnvíos { get; set; }

    public string NombreCompañía { get; set; } = null!;

    public string? Teléfono { get; set; }

    public virtual ICollection<Pedido> Pedidos { get; set; } = new List<Pedido>();
}
