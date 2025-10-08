using Yelazo.BD.Data.Entity;
using Yelazo.Shared.DTO;

namespace Yelazo.Server.Repositorios
{
    public interface IActividadMantenimientoRepositorio : IRepositorio<ActividadMantenimiento>
    {
        Task<List<ActividadMantenimiento>> GetActividadMantenimientoInclude();
        Task<List<MantenimientoCardDTO>> ObtenerMantenimientosConUltimaActividad();
    }
}