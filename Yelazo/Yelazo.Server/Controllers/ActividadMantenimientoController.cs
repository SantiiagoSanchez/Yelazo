using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Yelazo.BD.Data.Entity;
using Yelazo.Server.Repositorios;
using Yelazo.Shared.DTO;

namespace Yelazo.Server.Controllers
{
    [ApiController]
    [Route("api/ActividadMantenimiento")]
    public class ActividadMantenimientoController : ControllerBase
    {
        private readonly IActividadMantenimientoRepositorio repositorio;
        private readonly IRepositorio<Gasto> gastoRepositorio;
        private readonly IRepositorio<Mantenimiento> mantenimientoRepositorio;
        private readonly IMapper mapper;

        public ActividadMantenimientoController(IActividadMantenimientoRepositorio repositorio, IRepositorio<Gasto> gastoRepositorio, IRepositorio<Mantenimiento> mantenimientoRepositorio ,IMapper mapper)
        {
            this.repositorio = repositorio;
            this.gastoRepositorio = gastoRepositorio;
            this.mantenimientoRepositorio = mantenimientoRepositorio;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<List<ActividadMantenimiento>>> GetAll()
        {
            var actividades = await repositorio.GetActividadMantenimientoInclude();
            var dto = mapper.Map<List<ActividadMantenimiento>>(actividades);
            return Ok(dto);
        }

        [HttpPost]
        public async Task<ActionResult<int>> Post(CrearActividadMantenimientoDTO dto)
        {
            var entidad = mapper.Map<ActividadMantenimiento>(dto);
            var id = await repositorio.Insert(entidad);
            var mantenimiento = await mantenimientoRepositorio.SelectById(dto.MantenimientoId);
            if (mantenimiento == null) return NotFound("No existe el mantenimiento");

            var gasto = new Gasto
            {
                Fecha = dto.FechaActividad,
                Costo = dto.Precio,
                ProveedorId = dto.ProveedorId,
                tipoGastoId = dto.TipoGastoId,
                Descripcion = mantenimiento.Descripcion
            };

            await gastoRepositorio.Insert(gasto);

            return Ok(id);
        }
    }
}
