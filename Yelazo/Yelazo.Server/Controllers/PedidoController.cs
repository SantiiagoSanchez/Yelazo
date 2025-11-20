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
    }
}
