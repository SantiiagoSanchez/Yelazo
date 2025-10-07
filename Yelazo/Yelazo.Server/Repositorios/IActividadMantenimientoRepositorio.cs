using Yelazo.BD.Data.Entity;

namespace Yelazo.Server.Repositorios
{
    public interface IActividadMantenimientoRepositorio : IRepositorio<ActividadMantenimiento>
    {
        Task<List<ActividadMantenimiento>> GetActividadMantenimientoInclude();
    }
}