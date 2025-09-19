using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yelazo.BD.Data.Entity;

namespace Yelazo.BD.Data
{
    public class Context : DbContext
    {

        public DbSet<Insumo> Insumos { get; set; }

        public DbSet<Proveedor> Proveedores { get; set; }
        public DbSet<TipoGasto> TiposGasto { get; set; }
        public DbSet<MetodoPago> MetodosPago { get; set; }
        public DbSet<Mantenimiento> Mantenimientos { get; set; }
        public DbSet<Producto> Productos { get; set; }

        public DbSet<Rol> Roles { get; set; }

        public DbSet<Stock> Stocks { get; set; }
        public Context(DbContextOptions<Context> options) : base(options)
        {
        }
    }
}
