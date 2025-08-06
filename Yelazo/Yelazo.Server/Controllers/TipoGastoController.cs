using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Yelazo.BD.Data.Entity;
using Yelazo.Server.Repositorios;
using Yelazo.Shared.DTO;

namespace Yelazo.Server.Controllers
{
    [ApiController]
    [Route("api/TipoGasto")]
    public class TipoGastoController : ControllerBase
    {
        private readonly IRepositorio<TipoGasto> repositorio;
        private readonly IMapper mapper;

        public TipoGastoController(IRepositorio<TipoGasto> repositorio, IMapper mapper)
        {
            this.repositorio = repositorio;
            this.mapper = mapper;
        }

        [HttpGet()]
        public async Task<ActionResult<List<TipoGasto>>> GetAll()
        {
            var tipogasto = await repositorio.Select();
            var dto = mapper.Map<List<TipoGasto>>(tipogasto);
            return Ok(dto);
        }

        // GET: api/TipoGasto/5
        [HttpGet("{id:int}")]
        public async Task<ActionResult<CrearTipoGastoDTO>> Get(int id)
        {
            var tipogasto = await repositorio.SelectById(id);
            if (tipogasto == null) return NotFound();
            var dto = mapper.Map<CrearTipoGastoDTO>(tipogasto);
            return Ok(dto);
        }

        [HttpPost]
        public async Task<ActionResult<int>> Post(CrearTipoGastoDTO dto)
        {
            var entidad = mapper.Map<TipoGasto>(dto);
            var id = await repositorio.Insert(entidad);
            return Ok(id);
        }



        //PUT: api/MetodoPago/5
        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(int id, CrearTipoGastoDTO DTO)
        {


            var existente = await repositorio.SelectById(id);
            if (existente == null)
                return NotFound("No existe el tipo de gasto");

            if (string.IsNullOrWhiteSpace(DTO.Nombre))
                return BadRequest("El nombre de el tipo de gasto es obligatorio.");

            // Mapeamos SOLO los datos actualizados sobre la entidad existente
            mapper.Map(DTO, existente);

            var ok = await repositorio.UpdateEntidad(id, existente);
            return ok ? Ok() : BadRequest();
        }


        // DELETE: api/MetodoPago/5
        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var existe = await repositorio.Existe(id);
            if (!existe) return NotFound();

            var ok = await repositorio.Delete(id);
            return ok ? Ok() : BadRequest();
        }
    }
}
