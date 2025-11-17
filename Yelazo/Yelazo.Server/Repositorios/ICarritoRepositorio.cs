using Yelazo.BD.Data.Entity;
using Yelazo.Shared.DTO;

namespace Yelazo.Server.Repositorios
{
    public interface ICarritoRepositorio
    {
        Task<Carrito> CrearCarritoAsync(Carrito carrito);
        Task<bool> FinalizarCarrito(int carritoId);
        Task<CarritoDTO?> ObtenerCarritoActivoAsync(string usuarioId);
    }
}