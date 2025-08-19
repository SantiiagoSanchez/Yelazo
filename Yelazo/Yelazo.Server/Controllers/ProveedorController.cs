using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Yelazo.BD.Data.Entity;
using Yelazo.Server.Repositorios;
using Yelazo.Shared.DTO;

namespace Yelazo.Server.Controllers
{
    [ApiController]
    [Route("api/Proveedor")]
    public class ProveedorController : ControllerBase
    {
        private readonly IRepositorio<Proveedor> repositorio;
        private readonly IMapper mapper;

        public ProveedorController(IRepositorio<Proveedor> repositorio, IMapper mapper)
        {
            this.repositorio = repositorio;
            this.mapper = mapper;
        }

        [HttpGet()]
        public async Task<ActionResult<List<Proveedor>>> GetAll()
        {
            var proveedores = await repositorio.Select();
            var dto = mapper.Map<List<Proveedor>>(proveedores);
            return Ok(dto);
        }

        // GET: api/productos/5
        [HttpGet("{id:int}")]
        public async Task<ActionResult<CrearProveedorDTO>> Get(int id)
        {
            var proveedor = await repositorio.SelectById(id);
            if (proveedor == null) return NotFound();
            var dto = mapper.Map<CrearProveedorDTO>(proveedor);
            return Ok(dto);
        }

        [HttpPost]
        public async Task<ActionResult<int>> Post(CrearProveedorDTO dto)
        {
            var entidad = mapper.Map<Proveedor>(dto);
            var id = await repositorio.Insert(entidad);
            return Ok(id);
        }

        // POST: api/productos


        //PUT: api/producto/5
        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(int id, CrearProveedorDTO DTO)
        {
            //if (id != productoDTO.Id)
            //    return BadRequest("IDs no coinciden");

            var existente = await repositorio.SelectById(id);
            if (existente == null)
                return NotFound("No existe el proveedor");

            if (string.IsNullOrWhiteSpace(DTO.Nombre))
                return BadRequest("El nombre de el proveedor es obligatorio.");

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
