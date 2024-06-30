using System;
using System.Collections.Generic;

namespace CapaDatosWebEmpresa.Models;

public partial class Producto
{
    public int IdProducto { get; set; }

    public string NombreProducto { get; set; } = null!;

    public int? IdProveedor { get; set; }

    public int? IdCategoría { get; set; }

    public string? CantidadPorUnidad { get; set; }

    public decimal? PrecioUnidad { get; set; }

    public short? UnidadesEnExistencia { get; set; }

    public short? UnidadesEnPedido { get; set; }

    public int? NivelNuevoPedido { get; set; }

    public bool Suspendido { get; set; }

    public string? Foto { get; set; }

    public virtual ICollection<DetallesDePedido> DetallesDePedidos { get; set; } = new List<DetallesDePedido>();

    public virtual Categoría? IdCategoríaNavigation { get; set; }

    public virtual Proveedore? IdProveedorNavigation { get; set; }
}
