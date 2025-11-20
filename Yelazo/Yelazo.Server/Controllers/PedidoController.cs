using Microsoft.AspNetCore.Mvc;
using Yelazo.Server.Repositorios;
using Yelazo.Shared.DTO;

namespace Yelazo.Server.Controllers
{
    [ApiController]
    [Route("api/Pedido")]
    public class PedidoController : ControllerBase
    {
        private readonly IPedidoRepositorio repositorio;

        public PedidoController(IPedidoRepositorio repositorio)
        {
            this.repositorio = repositorio;
        }

        [HttpPost("CrearDesdeCarrito/{carritoId}")]
        public async Task<ActionResult<PedidoDTO>> CrearPedidoDesdeCarrito(int carritoId)
        {
            try
            {
                var pedido = await repositorio.CrearPedidoDesdeCarrito(carritoId);
                return Ok(pedido);
            }
            catch (Exception ex)
            {
                return BadRequest(new { mensaje = ex.Message });
            }
        }

        [HttpGet("")]
        public async Task<ActionResult<List<PedidoDTO>>> ObtenerPedidos()
        {
            var pedidos = await repositorio.ObtenerPedidosActivos();
            return Ok(pedidos);
        }

        [HttpGet("detalle/{pedidoId}")]
        public async Task<ActionResult<List<DetallePedidoDTO>>> ObtenerDetallesPedidos(int pedidoId)
        {
            var detalles = await repositorio.ObtenerDetallesPorPedido(pedidoId);
            return Ok(detalles);
        }

        [HttpPut("en-camino/{pedidoId}")]
        public async Task<ActionResult> MarcarPedidoEnCamino(int pedidoId)
        {
            var pedido = await repositorio.SelectById(pedidoId);
            if (pedido == null)
                return NotFound();
            pedido.Estado = "En camino";
            await repositorio.UpdateEntidad(pedidoId, pedido);
            return NoContent();
        }
    }
}
