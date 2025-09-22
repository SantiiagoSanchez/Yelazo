using Yelazo.BD.Data.Entity;

namespace Yelazo.Server.Repositorios
{
    public interface IProductoRepositorio
    {
        Task actualizarAsync(Producto producto);
        Task<Producto> GetById(int id);
    }
}