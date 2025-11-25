using Microsoft.AspNetCore.Mvc;
using Yelazo.Server.Repositorios;

namespace Yelazo.Server.Controllers
{
    [ApiController]
    [Route("api/CuentaCorriente")]
    public class CuentaCorrienteController : ControllerBase
    {
        private readonly IPedidoRepositorio repositorio;

        public CuentaCorrienteController(IPedidoRepositorio repositorio)
        {
            this.repositorio = repositorio;
        }

        [HttpGet("Cliente/{usuarioId}")]
        public async Task<IActionResult> ObtenerCuentaCorrienteCliente(string usuarioId)
        {
            try
            {
                var cuentaCorriente = await repositorio.CuentaCorrientePorUsuario(usuarioId);

                if (cuentaCorriente == null || !cuentaCorriente.Any())
                {
                    return NotFound("No se encontraron registros de cuenta corriente para el usuario especificado.");
                }
                return Ok(cuentaCorriente);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error al obtener la cuenta corriente: {ex.Message}");
            }
        }
    }
}
