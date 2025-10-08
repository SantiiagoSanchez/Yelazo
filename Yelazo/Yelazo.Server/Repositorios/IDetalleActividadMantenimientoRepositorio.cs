using Yelazo.BD.Data.Entity;

namespace Yelazo.Server.Repositorios
{
    public interface IDetalleActividadMantenimientoRepositorio : IRepositorio<DetalleActividadMantenimiento>
    {
        Task InsertarDetalleActividad(DetalleActividadMantenimiento detalle);
    }
}