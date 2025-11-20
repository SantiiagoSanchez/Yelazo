using Yelazo.BD.Data.Entity;
using Yelazo.Shared.DTO;

namespace Yelazo.Server.Repositorios
{
    public interface IPedidoRepositorio : IRepositorio<Pedido>
    {
        Task<PedidoDTO> CrearPedidoDesdeCarrito(int carritoId);
        Task<List<DetallePedidoDTO>> ObtenerDetallesPorPedido(int pedidoId);
        Task<List<PedidoDTO>> ObtenerPedidosActivos();
    }
}