
using Yelazo.Shared.DTO;

namespace Yelazo.Client.Servicios
{
    public interface ICarritoService
    {
        Task AgregarProductoAsync(int carritoId, int productoId, int cantidad);
        Task<CarritoDTO> CrearCarritoAsync(CrearCarritoDTO dto);
        Task FinalizarCarritoAsync(int carritoId);
        Task QuitarProductoAsync(int carritoId, int productoId);
    }
}