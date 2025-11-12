
namespace Yelazo.Server.Repositorios
{
    public interface IDetalleCarritoRepositorio
    {
        Task AgregarProductoAsync(int carritoId, int productoId, int cantidad);
        Task QuitarProductoAsync(int carritoId, int productoId);
    }
}