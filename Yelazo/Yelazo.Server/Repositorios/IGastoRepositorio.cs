using Microsoft.AspNetCore.Mvc;
using Yelazo.BD.Data.Entity;
using Yelazo.Shared.DTO;

namespace Yelazo.Server.Repositorios
{
    public interface IGastoRepositorio : IRepositorio<Gasto>
    {
        Task<List<Gasto>> GetGastoInclude();

        Task<ActionResult<IEnumerable<FiltrarGastoDTO>>> BuscarGastos(string? nombreTipoGasto, DateTime? fecha);
    }
}