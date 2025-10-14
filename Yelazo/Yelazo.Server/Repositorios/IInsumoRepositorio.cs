using Yelazo.BD.Data.Entity;

namespace Yelazo.Server.Repositorios
{
    public interface IInsumoRepositorio : IRepositorio<Insumo>
    {
        Task ActualizarAsync(Insumo insumo);
    }
}