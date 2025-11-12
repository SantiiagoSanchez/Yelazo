using Microsoft.EntityFrameworkCore;
using Yelazo.BD.Data;
using Yelazo.BD.Data.Entity;

namespace Yelazo.Server.Repositorios
{
    public class DetalleCarritoRepositorio : Repositorio<DetalleCarrito>, IDetalleCarritoRepositorio
    {
        private readonly Context context;

        public DetalleCarritoRepositorio(Context context) : base(context)
        {
            this.context = context;
        }

        public async Task AgregarProductoAsync(int carritoId, int productoId, int cantidad)
        {
            var detalle = await context.DetalleCarritos
                .Include(d => d.Producto)
                .FirstOrDefaultAsync(d => d.CarritoId == carritoId && d.ProductoId == productoId);

            if (detalle == null)
            {
                var producto = await context.Productos.FindAsync(productoId);
                if (producto == null)
                    throw new Exception("Producto no encontrado");

                detalle = new DetalleCarrito
                {
                    CarritoId = carritoId,
                    ProductoId = productoId,
                    Cantidad = cantidad,
                    Total = producto.Precio * cantidad
                };

                context.DetalleCarritos.Add(detalle);
            }
            else
            {
                // Si ya existe el producto, solo actualizamos cantidad y total
                detalle.Cantidad += cantidad;
                detalle.Total = detalle.Producto.Precio * detalle.Cantidad;
            }

            await context.SaveChangesAsync();
        }

        public async Task QuitarProductoAsync(int carritoId, int productoId)
        {
            var detalle = await context.DetalleCarritos
                .FirstOrDefaultAsync(d => d.CarritoId == carritoId && d.ProductoId == productoId);

            if (detalle == null)
                throw new Exception("El producto no existe en el carrito");

            context.DetalleCarritos.Remove(detalle);
            await context.SaveChangesAsync();
        }
    }
}
