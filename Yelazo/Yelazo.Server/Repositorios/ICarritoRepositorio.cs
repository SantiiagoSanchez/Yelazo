using Yelazo.BD.Data.Entity;

namespace Yelazo.Server.Repositorios
{
    public interface ICarritoRepositorio
    {
        Task<Carrito> CrearCarritoAsync(Carrito carrito);
        Task<Carrito?> ObtenerCarritoActivoAsync(string usuarioId);
    }
}