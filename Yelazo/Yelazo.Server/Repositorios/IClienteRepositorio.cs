using Yelazo.Shared.DTO;

namespace Yelazo.Server.Repositorios
{
    public interface IClienteRepositorio
    {
        Task<List<PedidoDTO>> ObtenerHistorialPorId(string id);
    }
}