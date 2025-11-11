
namespace Yelazo.Client.Servicios
{
    public interface ICarritoService
    {
        Task AgregarProductoAsync(int carritoId, int productoId, int cantidad);
    }
}