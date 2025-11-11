using Microsoft.EntityFrameworkCore;
using Yelazo.BD.Data;
using Yelazo.BD.Data.Entity;
using Yelazo.Shared.DTO;

namespace Yelazo.Server.Repositorios
{
    public class CarritoRepositorio : Repositorio<Carrito>, ICarritoRepositorio
    {
        private readonly Context context;

        public CarritoRepositorio(Context context) : base(context)
        {
            this.context = context;
        }

        public async Task<CarritoDTO?> ObtenerCarritoActivoAsync(string usuarioId)
        {
            var carrito = await context.Carritos
                .Include(c => c.Detalles)
                .ThenInclude(d => d.Producto)
                .FirstOrDefaultAsync(c => c.UsuarioId == usuarioId && !c.Finalizado);

            if (carrito == null)
            {
                return null;
            }

            return new CarritoDTO
            {
                Id = carrito.Id,
                Detalles = carrito.Detalles.Select(d => new DetalleCarritoDTO
                {
                    Id = d.Id,
                    Cantidad = d.Cantidad,
                    Producto = new ProductoCarritosDTO
                    {
                        Id = d.Producto.Id,
                        Nombre = d.Producto.Nombre,
                        Precio = d.Producto.Precio
                    }

                }).ToList()
            };

            
        }

        public async Task<Carrito> CrearCarritoAsync(Carrito carrito)
        {
            context.Carritos.Add(carrito);
            await context.SaveChangesAsync();
            return carrito;
        }
    }
}
