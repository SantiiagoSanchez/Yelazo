using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Yelazo.BD.Data.Entity;
using Yelazo.Server.Repositorios;
using Yelazo.Shared.DTO;

namespace Yelazo.Server.Controllers
{
    [ApiController]
    [Route("api/Gastos")]
    public class GastoController : ControllerBase
    {
        private readonly IGastoRepositorio repositorio;
        private readonly IMapper mapper;

        public GastoController(IGastoRepositorio  repositorio, IMapper mapper)
        {
         
            this.repositorio = repositorio;
            this.mapper = mapper;
        }

        // GET: api/productos
        [HttpGet()]
        public async Task<ActionResult<List<Gasto>>> GetAll()
        {
            var categoriainsumos = await repositorio.GetGastoInclude();
            var dto = mapper.Map<List<Gasto>>(categoriainsumos);
            return Ok(dto);
        }

        // GET: api/productos/5
        [HttpGet("{id:int}")]
        public async Task<ActionResult<CrearInsumosDTO>> Get(int id)
        {
            var categoria = await repositorio.SelectById(id);
            if (categoria == null) return NotFound();
            var dto = mapper.Map<CrearInsumosDTO>(categoria);
            return Ok(dto);
        }

        [HttpPost]
        public async Task<ActionResult<int>> Post(CrearGastoDTO dto)
        {
            var entidad = mapper.Map<Gasto>(dto);
            var id = await repositorio.Insert(entidad);
            return Ok(id);
        }

        // POST: api/productos


        //PUT: api/producto/5
        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(int id, CrearInsumosDTO DTO)
        {
            //if (id != productoDTO.Id)
            //    return BadRequest("IDs no coinciden");

            var existente = await repositorio.SelectById(id);
            if (existente == null)
                return NotFound("No existe la categoría");

            if (string.IsNullOrWhiteSpace(DTO.Nombre))
                return BadRequest("El nombre de la categoría es obligatorio.");

            // Mapeamos SOLO los datos actualizados sobre la entidad existente
            mapper.Map(DTO, existente);

            var ok = await repositorio.UpdateEntidad(id, existente);
            return ok ? Ok() : BadRequest();
        }


        // DELETE: api/categorias/5
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

