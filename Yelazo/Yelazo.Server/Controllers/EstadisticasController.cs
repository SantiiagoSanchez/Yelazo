using Microsoft.AspNetCore.Mvc;
using Yelazo.Server.Repositorios;

namespace Yelazo.Server.Controllers
{
    [ApiController]
    [Route("api/Estadisticas")]
    public class EstadisticasController : ControllerBase
    {
        private readonly IEstadisticasRepositorio repositorio;

        public EstadisticasController(IEstadisticasRepositorio repositorio)
        {
            this.repositorio = repositorio;
        }

        [HttpGet("Ingresos/{anio}")]
        public async Task<IActionResult> GetIngresosAnuales(int anio)
        {
            var ingresos = await repositorio.GetIngresosAnuales(anio);
            return Ok(ingresos);
        }

        [HttpGet("Ingresos/{anio}/{mes}")]
        public async Task<IActionResult> GetIngresosDetallados(int anio, int mes)
        {
            var ingresosDetallados = await repositorio.GetIngresosDetallados(anio, mes);
            return Ok(ingresosDetallados);
        }

        [HttpGet("Tarjetas")]
        public async Task<IActionResult> ObtenerTarjetasAsync()
        {
            var tarjetas = await repositorio.ObtenerTarjetasAsync();
            return Ok(tarjetas);
        }
    }
}
