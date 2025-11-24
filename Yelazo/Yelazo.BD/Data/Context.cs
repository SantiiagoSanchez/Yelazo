using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using Yelazo.BD.Data.Entity;

namespace Yelazo.BD.Data
{
    public class Context : IdentityDbContext<UsuarioYelazo>
    {

        public DbSet<Insumo> Insumos { get; set; }
        public DbSet<Gasto> Gastos { get; set; }
        public DbSet<Proveedor> Proveedores { get; set; }
        public DbSet<TipoGasto> TiposGasto { get; set; }
        public DbSet<MetodoPago> MetodosPago { get; set; }
        public DbSet<IngresoInsumo> IngresoInsumos { get; set; }
        public DbSet<DetalleActividadMantenimiento> DetalleActividadMantenimientos { get; set; }
        public DbSet<ActividadMantenimiento> ActividadMantenimientos { get; set; }
        public DbSet<Mantenimiento> Mantenimientos { get; set; }
        public DbSet<Producto> Productos { get; set; }
        public DbSet<Carrito> Carritos { get; set; }

        public DbSet<DetalleCarrito> DetalleCarritos { get; set; }

        public DbSet<Pedido> Pedidos { get; set; }

        public DbSet<DetallePedido> DetallePedidos { get; set; }

        public DbSet<Pago> Pagos { get; set; }

        public DbSet<Stock> Stocks { get; set; }
        public Context(DbContextOptions<Context> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            var cascadeFKs = modelBuilder.Model.G­etEntityTypes()
                                          .SelectMany(t => t.GetForeignKeys())
                                          .Where(fk => !fk.IsOwnership
                                                       && fk.DeleteBehavior == DeleteBehavior.Casca­de);
            foreach (var fk in cascadeFKs)
            {
                fk.DeleteBehavior = DeleteBehavior.Restr­ict;
            }

            base.OnModelCreating(modelBuilder);
        }
    }
}
