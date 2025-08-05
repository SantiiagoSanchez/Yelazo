using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.CompilerServices;
using Yelazo.BD.Data.Entity;
using Yelazo.Server.Repositorios;
using Yelazo.Shared.DTO;

namespace Yelazo.Server.Controllers
{
    [ApiController]
    [Route("api/MetodoPago")]
    public class MetodoPagoController : ControllerBase
    {

        private readonly IRepositorio<MetodoPago> repositorio;
        private readonly IMapper mapper;

        public MetodoPagoController(IRepositorio<MetodoPago> repositorio, IMapper mapper)
        {
            this.repositorio = repositorio;
            this.mapper = mapper;
        }

        [HttpGet()]
        public async Task<ActionResult<List<MetodoPago>>> GetAll()
        {
            var productos = await repositorio.Select();
            var dto = mapper.Map<List<MetodoPago>>(productos);
            return Ok(dto);
        }

        // GET: api/MetodoPago/5
        [HttpGet("{id:int}")]
        public async Task<ActionResult<CrearMetodoPagoDTO>> Get(int id)
        {
            var categoria = await repositorio.SelectById(id);
            if (categoria == null) return NotFound();
            var dto = mapper.Map<CrearMetodoPagoDTO>(categoria);
            return Ok(dto);
        }

        [HttpPost]
        public async Task<ActionResult<int>> Post(CrearMetodoPagoDTO dto)
        {
            var entidad = mapper.Map<MetodoPago>(dto);
            var id = await repositorio.Insert(entidad);
            return Ok(id);
        }



        //PUT: api/MetodoPago/5
        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(int id, CrearMetodoPagoDTO DTO)
        {


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
