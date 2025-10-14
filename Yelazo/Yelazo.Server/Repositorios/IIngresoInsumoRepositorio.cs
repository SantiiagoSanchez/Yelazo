using Yelazo.BD.Data.Entity;

namespace Yelazo.Server.Repositorios
{
    public interface IIngresoInsumoRepositorio : IRepositorio<IngresoInsumo>
    {
        Task<List<IngresoInsumo>> GetIngresoInsumoInclude();
    }
}
