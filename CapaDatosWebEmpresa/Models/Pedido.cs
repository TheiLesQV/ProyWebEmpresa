using System;
using System.Collections.Generic;

namespace CapaDatosWebEmpresa.Models;

public partial class Pedido
{
    public int IdPedido { get; set; }

    public string IdCliente { get; set; } = null!;

    public int? IdEmpleado { get; set; }

    public DateTime? FechaPedido { get; set; }

    public DateTime? FechaEntrega { get; set; }

    public int? FormaEnvío { get; set; }

    public decimal? Cargo { get; set; }

    public virtual ICollection<DetallesDePedido> DetallesDePedidos { get; set; } = new List<DetallesDePedido>();

    public virtual CompañíasDeEnvío? FormaEnvíoNavigation { get; set; }

    public virtual Cliente IdClienteNavigation { get; set; } = null!;

    public virtual Empleado? IdEmpleadoNavigation { get; set; }
}
