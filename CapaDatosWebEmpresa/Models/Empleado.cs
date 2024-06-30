using System;
using System.Collections.Generic;

namespace CapaDatosWebEmpresa.Models;

public partial class Empleado
{
    public int IdEmpleado { get; set; }

    public string Apellidos { get; set; } = null!;

    public string Nombre { get; set; } = null!;

    public string? Cargo { get; set; }

    public DateTime? FechaNacimiento { get; set; }

    public DateTime? FechaContratación { get; set; }

    public string? Dirección { get; set; }

    public string? Ciudad { get; set; }

    public string? País { get; set; }

    public string? TelDomicilio { get; set; }

    public string? Foto { get; set; }

    public virtual ICollection<Pedido> Pedidos { get; set; } = new List<Pedido>();
}
