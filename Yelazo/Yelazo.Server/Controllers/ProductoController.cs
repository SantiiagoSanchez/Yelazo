using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Yelazo.BD.Data.Entity;
using Yelazo.Server.Repositorios;
using Yelazo.Shared.DTO;

namespace Yelazo.Server.Controllers
{
    [ApiController]
    [Route("api/Productos")]
    public class ProductoController : ControllerBase
    {
        private readonly IRepositorio<Producto> repositorio;
        private readonly IMapper mapper;

        public ProductoController(IRepositorio<Producto> repositorio, IMapper mapper)
        {
            this.repositorio = repositorio;
            this.mapper = mapper;
        }

        // GET: api/productos
        [HttpGet()]
        public async Task<ActionResult<List<CrearProductoDTO>>> GetAll()
        {
            var productos = await repositorio.Select();
            var dto = mapper.Map<List<CrearProductoDTO>>(productos);
            return Ok(dto);
        }

        // GET: api/productos/5
        [HttpGet("{id:int}")]
        public async Task<ActionResult<CrearProductoDTO>> Get(int id)
        {
            var categoria = await repositorio.SelectById(id);
            if (categoria == null) return NotFound();
            var dto = mapper.Map<CrearProductoDTO>(categoria);
            return Ok(dto);
        }

        [HttpPost]
        public async Task<ActionResult<int>> Post(CrearProductoDTO dto)
        {
            var entidad = mapper.Map<Producto>(dto);
            var id = await repositorio.Insert(entidad);
            return Ok(id);
        }

        // POST: api/productos


        //PUT: api/producto/5
        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(int id, EditarProductoDTO productoDTO)
        {
            if (id != productoDTO.Id)
                return BadRequest("IDs no coinciden");

            var existente = await repositorio.SelectById(id);
            if (existente == null)
                return NotFound("No existe la categoría");

            if (string.IsNullOrWhiteSpace(productoDTO.Nombre))
                return BadRequest("El nombre de la categoría es obligatorio.");

            // Mapeamos SOLO los datos actualizados sobre la entidad existente
            mapper.Map(productoDTO, existente);

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
