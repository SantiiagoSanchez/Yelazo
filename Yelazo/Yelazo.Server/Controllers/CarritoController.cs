using Microsoft.AspNetCore.Mvc;
using Yelazo.BD.Data.Entity;
using Yelazo.Server.Repositorios;

namespace Yelazo.Server.Controllers
{
    [ApiController]
    [Route("api/Carrito")]
    public class CarritoController : ControllerBase
    {
        private readonly ICarritoRepositorio repositorio;

        public CarritoController(ICarritoRepositorio repositorio)
        {
            this.repositorio = repositorio;
        }

        // Obtener el carrito activo de un usuario
        [HttpGet("Activo/{usuarioId}")]
        public async Task<ActionResult<Carrito>> ObtenerCarritoActivo(string usuarioId)
        {
            var carrito = await repositorio.ObtenerCarritoActivoAsync(usuarioId);
            if (carrito is null)
            {
                return NotFound();
            }
            return Ok(carrito);
        }

        // Crear un nuevo carrito para un usuario
        [HttpPost]
        public async Task<ActionResult<Carrito>> CrearCarrito([FromBody] Carrito carrito)
        {
            var existente = await repositorio.ObtenerCarritoActivoAsync(carrito.UsuarioId);
            if (existente != null)
            {
                return Conflict("El usuario ya tiene un carrito activo.");
            }

            var nuevoCarrito = await repositorio.CrearCarritoAsync(carrito);
            return Ok(nuevoCarrito);
        }
    }
}
