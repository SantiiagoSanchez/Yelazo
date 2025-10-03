using Yelazo.BD.Data.Entity;

namespace Yelazo.Server.Repositorios
{
    public interface IGastoRepositorio : IRepositorio<Gasto>
    {
        Task<List<Gasto>> GetGastoInclude();
    }
}