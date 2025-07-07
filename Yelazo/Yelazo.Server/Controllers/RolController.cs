using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Yelazo.BD.Data.Entity;
using Yelazo.Server.Repositorios;
using Yelazo.Shared.DTO;

namespace Yelazo.Server.Controllers
{
    [ApiController]
    [Route("api/Roles")]
    public class RolController : ControllerBase
    {
        private readonly IRepositorio<Rol> repositorio;
        private readonly IMapper mapper;

        public RolController(IRepositorio<Rol> repositorio, IMapper mapper)
        {
            this.repositorio = repositorio;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<List<Rol>>> GetAll()
        {
            var roles = await repositorio.Select();
            var dto = mapper.Map<List<Rol>>(roles);
            return Ok(dto);
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<CrearRolDTO>> Get(int id)
        {
            var rol = await repositorio.SelectById(id);
            if (rol == null) return NotFound();
            var dto = mapper.Map<CrearRolDTO>(rol);
            return Ok(dto);
        }

        [HttpPost]
        public async Task<ActionResult<int>> Post(CrearRolDTO dto)
        {
            var entidad = mapper.Map<Rol>(dto);
            var id = await repositorio.Insert(entidad);
            return Ok(id);
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(int id, CrearRolDTO rolDTO)
        {
            //if (id != productoDTO.Id)
            //    return BadRequest("IDs no coinciden");

            var existente = await repositorio.SelectById(id);
            if (existente == null)
                return NotFound("No existe el rol");

            if (string.IsNullOrWhiteSpace(rolDTO.Nombre))
                return BadRequest("El nombre de la categoría es obligatorio.");

            // Mapeamos SOLO los datos actualizados sobre la entidad existente
            mapper.Map(rolDTO, existente);

            var ok = await repositorio.UpdateEntidad(id, existente);
            return ok ? Ok() : BadRequest();
        }

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
