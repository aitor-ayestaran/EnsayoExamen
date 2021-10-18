using Entidades;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace Dal
{
    public partial class EntityDataModel : DbContext
    {
        public EntityDataModel()
            : base("name=EntityDataModel")
        {
            Configuration.ProxyCreationEnabled = false;
            Configuration.LazyLoadingEnabled = false;
        }

        public virtual DbSet<Categoria> Categorias { get; set; }
        public virtual DbSet<Cliente> Clientes { get; set; }
        public virtual DbSet<Empleado> Empleados { get; set; }
        public virtual DbSet<Factura> Facturas { get; set; }
        public virtual DbSet<FacturasProducto> FacturasProductos { get; set; }
        public virtual DbSet<Mueble> Muebles { get; set; }
        public virtual DbSet<Producto> Productos { get; set; }
        public virtual DbSet<Usuario> Usuarios { get; set; }
        public virtual DbSet<ProductosCompleto> ProductosCompletos { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Categoria>()
                .HasMany(e => e.Productos)
                .WithRequired(e => e.Categoria)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Cliente>()
                .HasMany(e => e.Facturas)
                .WithRequired(e => e.Cliente)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Empleado>()
                .HasMany(e => e.Empleados1)
                .WithOptional(e => e.Empleado1)
                .HasForeignKey(e => e.JefeId);

            modelBuilder.Entity<Factura>()
                .Property(e => e.Numero)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Factura>()
                .HasMany(e => e.FacturasProductos)
                .WithRequired(e => e.Factura)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Mueble>()
                .Property(e => e.Precio)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Producto>()
                .Property(e => e.Precio)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Producto>()
                .HasMany(e => e.FacturasProductos)
                .WithRequired(e => e.Producto)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Usuario>()
                .Property(e => e.Password)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Usuario>()
                .HasOptional(e => e.Cliente)
                .WithRequired(e => e.Usuario);

            modelBuilder.Entity<ProductosCompleto>()
                .Property(e => e.Precio)
                .HasPrecision(19, 4);
        }
    }
}
