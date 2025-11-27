using Yelazo.Shared.DTO;

namespace Yelazo.Server.Repositorios
{
    public interface IEstadisticasRepositorio
    {
        Task<IngresosAnualesDTO> GetIngresosAnuales(int anio);
        Task<List<DetalleIngresosDTO>> GetIngresosDetallados(int anio, int mes);
    }
}