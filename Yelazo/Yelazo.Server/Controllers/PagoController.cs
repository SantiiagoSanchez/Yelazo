using Microsoft.AspNetCore.Mvc;
using Yelazo.Server.Repositorios;
using Yelazo.Shared.DTO;

namespace Yelazo.Server.Controllers
{
    [ApiController]
    [Route("api/Pago")]
    public class PagoController : ControllerBase
    {
        private readonly IPagoRepositorio repositorio;

        public PagoController(IPagoRepositorio repositorio)
        {
            this.repositorio = repositorio;
        }

        [HttpPost()]
        public async Task<ActionResult> CrearPago([FromBody] CrearPagoDTO dto)
        {
            try
            {
                var pago = await repositorio.CrearPagoAsync(dto);
                return Ok(pago);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
    }
}
