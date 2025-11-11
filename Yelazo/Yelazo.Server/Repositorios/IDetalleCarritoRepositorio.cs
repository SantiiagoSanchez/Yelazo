
namespace Yelazo.Server.Repositorios
{
    public interface IDetalleCarritoRepositorio
    {
        Task AgregarProductoAsync(int carritoId, int productoId, int cantidad);
    }
}