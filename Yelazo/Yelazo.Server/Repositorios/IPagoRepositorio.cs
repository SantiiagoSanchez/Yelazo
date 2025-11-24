using Yelazo.BD.Data.Entity;
using Yelazo.Shared.DTO;

namespace Yelazo.Server.Repositorios
{
    public interface IPagoRepositorio
    {
        Task<Pago> CrearPagoAsync(CrearPagoDTO dto);
    }
}