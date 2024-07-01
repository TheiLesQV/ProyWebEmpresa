using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace CapaDatosWebEmpresa.Models;

public partial class NegocioWebContext : DbContext
{
    public NegocioWebContext()
    {
    }

    public NegocioWebContext(DbContextOptions<NegocioWebContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Categoría> Categorías { get; set; }

    public virtual DbSet<Cliente> Clientes { get; set; }

    public virtual DbSet<CompañíasDeEnvío> CompañíasDeEnvíos { get; set; }

    public virtual DbSet<DetallesDePedido> DetallesDePedidos { get; set; }

    public virtual DbSet<Empleado> Empleados { get; set; }

    public virtual DbSet<Pedido> Pedidos { get; set; }

    public virtual DbSet<Producto> Productos { get; set; }

    public virtual DbSet<Proveedore> Proveedores { get; set; }
    public virtual DbSet<Modelos.ProductoModel> ProductoModel { get; set; }
    public virtual DbSet<Modelos.PedidoModel> PedidoModel { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=LAPTOP-MJNL9DAL; Database=NegocioWeb;Integrated Security=true;Encrypt=false");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.UseCollation("SQL_Latin1_General_CP1_CI_AS");

        modelBuilder.Entity<Categoría>(entity =>
        {
            entity.HasKey(e => e.IdCategoría);

            entity.Property(e => e.IdCategoría).ValueGeneratedNever();
            entity.Property(e => e.NombreCategoría).HasMaxLength(15);
        });

        modelBuilder.Entity<Cliente>(entity =>
        {
            entity.HasKey(e => e.IdCliente);

            entity.Property(e => e.IdCliente).HasMaxLength(5);
            entity.Property(e => e.CargoContacto).HasMaxLength(30);
            entity.Property(e => e.Ciudad).HasMaxLength(15);
            entity.Property(e => e.Dirección).HasMaxLength(60);
            entity.Property(e => e.NombreCompañía).HasMaxLength(40);
            entity.Property(e => e.NombreContacto).HasMaxLength(30);
            entity.Property(e => e.País).HasMaxLength(15);
            entity.Property(e => e.Teléfono).HasMaxLength(24);
        });

        modelBuilder.Entity<CompañíasDeEnvío>(entity =>
        {
            entity.HasKey(e => e.IdCompañíaEnvíos);

            entity.ToTable("Compañías de envíos");

            entity.Property(e => e.IdCompañíaEnvíos).ValueGeneratedNever();
            entity.Property(e => e.NombreCompañía).HasMaxLength(40);
            entity.Property(e => e.Teléfono).HasMaxLength(24);
        });

        modelBuilder.Entity<DetallesDePedido>(entity =>
        {
            entity.HasKey(e => new { e.IdPedido, e.IdProducto });

            entity.ToTable("Detalles de pedidos");

            entity.Property(e => e.PrecioUnidad).HasColumnType("money");

            entity.HasOne(d => d.IdPedidoNavigation).WithMany(p => p.DetallesDePedidos)
                .HasForeignKey(d => d.IdPedido)
                .HasConstraintName("FK_Detalles de pedidos_Pedidos");

            entity.HasOne(d => d.IdProductoNavigation).WithMany(p => p.DetallesDePedidos)
                .HasForeignKey(d => d.IdProducto)
                .HasConstraintName("FK_Detalles de pedidos_Productos");
        });

        modelBuilder.Entity<Empleado>(entity =>
        {
            entity.HasKey(e => e.IdEmpleado);

            entity.Property(e => e.IdEmpleado).ValueGeneratedNever();
            entity.Property(e => e.Apellidos).HasMaxLength(20);
            entity.Property(e => e.Cargo).HasMaxLength(30);
            entity.Property(e => e.Ciudad).HasMaxLength(15);
            entity.Property(e => e.Dirección).HasMaxLength(60);
            entity.Property(e => e.FechaContratación).HasColumnType("datetime");
            entity.Property(e => e.FechaNacimiento).HasColumnType("datetime");
            entity.Property(e => e.Foto).HasMaxLength(255);
            entity.Property(e => e.Nombre).HasMaxLength(10);
            entity.Property(e => e.País).HasMaxLength(15);
            entity.Property(e => e.TelDomicilio).HasMaxLength(24);
        });

        modelBuilder.Entity<Pedido>(entity =>
        {
            entity.HasKey(e => e.IdPedido);

            entity.Property(e => e.IdPedido).ValueGeneratedNever();
            entity.Property(e => e.Cargo).HasColumnType("money");
            entity.Property(e => e.FechaEntrega).HasColumnType("datetime");
            entity.Property(e => e.FechaPedido).HasColumnType("datetime");
            entity.Property(e => e.IdCliente).HasMaxLength(5);

            entity.HasOne(d => d.FormaEnvíoNavigation).WithMany(p => p.Pedidos)
                .HasForeignKey(d => d.FormaEnvío)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_Pedidos_Compañías de envíos");

            entity.HasOne(d => d.IdClienteNavigation).WithMany(p => p.Pedidos)
                .HasForeignKey(d => d.IdCliente)
                .HasConstraintName("FK_Pedidos_Clientes");

            entity.HasOne(d => d.IdEmpleadoNavigation).WithMany(p => p.Pedidos)
                .HasForeignKey(d => d.IdEmpleado)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_Pedidos_Empleados");
        });

        modelBuilder.Entity<Producto>(entity =>
        {
            entity.HasKey(e => e.IdProducto);

            entity.Property(e => e.IdProducto).ValueGeneratedNever();
            entity.Property(e => e.CantidadPorUnidad).HasMaxLength(20);
            entity.Property(e => e.Foto)
                .HasMaxLength(250)
                .HasColumnName("foto");
            entity.Property(e => e.NombreProducto).HasMaxLength(40);
            entity.Property(e => e.PrecioUnidad).HasColumnType("money");

            entity.HasOne(d => d.IdCategoríaNavigation).WithMany(p => p.Productos)
                .HasForeignKey(d => d.IdCategoría)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_Productos_Categorías");

            entity.HasOne(d => d.IdProveedorNavigation).WithMany(p => p.Productos)
                .HasForeignKey(d => d.IdProveedor)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_Productos_Proveedores");
        });

        modelBuilder.Entity<Proveedore>(entity =>
        {
            entity.HasKey(e => e.IdProveedor);

            entity.Property(e => e.IdProveedor).ValueGeneratedNever();
            entity.Property(e => e.Ciudad).HasMaxLength(15);
            entity.Property(e => e.Dirección).HasMaxLength(60);
            entity.Property(e => e.NombreCompañía).HasMaxLength(40);
            entity.Property(e => e.País).HasMaxLength(15);
            entity.Property(e => e.Teléfono).HasMaxLength(24);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
