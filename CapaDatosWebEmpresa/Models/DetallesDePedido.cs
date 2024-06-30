using System;
using System.Collections.Generic;

namespace CapaDatosWebEmpresa.Models;

public partial class DetallesDePedido
{
    public int IdPedido { get; set; }

    public int IdProducto { get; set; }

    public decimal PrecioUnidad { get; set; }

    public short Cantidad { get; set; }

    public virtual Pedido IdPedidoNavigation { get; set; } = null!;

    public virtual Producto IdProductoNavigation { get; set; } = null!;
}
