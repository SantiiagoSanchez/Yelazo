using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Yelazo.BD.Data.Entity;
using Yelazo.Server.Repositorios;
using Yelazo.Shared.DTO;

namespace Yelazo.Server.Controllers
{
    [ApiController]
    [Route("api/DetalleActividadMantenimiento")]
    public class DetalleActividadMantenimientoController : ControllerBase
    {
        private readonly IDetalleActividadMantenimientoRepositorio repositorio;
        private readonly IMapper mapper;

        public DetalleActividadMantenimientoController(IDetalleActividadMantenimientoRepositorio repositorio, IMapper mapper)
        {
            this.repositorio = repositorio;
            this.mapper = mapper;
        }

        [HttpPost]
        public async Task<ActionResult> Post(List<CrearDetalleActividadMantenimientoDTO> detalles)
        {
            if (detalles == null || !detalles.Any())
                return BadRequest("Debe enviar al menos un insumo");

            try
            {
                foreach (var dto in detalles)
                {
                    var entidad = mapper.Map<DetalleActividadMantenimiento>(dto);
                    await repositorio.InsertarDetalleActividad(entidad);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok();
        }
    }
}
