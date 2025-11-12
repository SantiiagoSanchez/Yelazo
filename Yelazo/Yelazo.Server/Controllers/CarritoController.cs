using Microsoft.AspNetCore.Mvc;
using Yelazo.BD.Data.Entity;
using Yelazo.Server.Repositorios;
using Yelazo.Shared.DTO;

namespace Yelazo.Server.Controllers
{
    [ApiController]
    [Route("api/Carrito")]
    public class CarritoController : ControllerBase
    {
        private readonly ICarritoRepositorio repositorio;
        private readonly IDetalleCarritoRepositorio detalleCarritoRepositorio;

        public CarritoController(ICarritoRepositorio repositorio, IDetalleCarritoRepositorio detalleCarritoRepositorio)
        {
            this.repositorio = repositorio;
            this.detalleCarritoRepositorio = detalleCarritoRepositorio;
        }

        // Obtener el carrito activo de un usuario
        [HttpGet("Activo/{usuarioId}")]
        public async Task<ActionResult<CarritoDTO>> ObtenerCarritoActivo(string usuarioId)
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
        public async Task<ActionResult<Carrito>> CrearCarrito([FromBody] CrearCarritoDTO carrito)
        {
            if (carrito == null || string.IsNullOrEmpty(carrito.UsuarioId))
                return BadRequest("Datos inválidos");

            var existente = await repositorio.ObtenerCarritoActivoAsync(carrito.UsuarioId);
            if (existente != null)
                return Conflict("El usuario ya tiene un carrito activo.");

            var nuevoCarrito = new Carrito
            {
                UsuarioId = carrito.UsuarioId,
                FechaCreacion = carrito.FechaCreacion,
                Finalizado = false,
                Detalles = new List<DetalleCarrito>()
            };

            var creado = await repositorio.CrearCarritoAsync(nuevoCarrito);
            return Ok(creado);
        }

        // Agregar un producto al carrito
        [HttpPost("{carritoId}/AgregarProducto")]
        public async Task<IActionResult> AgregarProducto(int carritoId, [FromBody] AgregarProductoDTO dto)
        {
            await detalleCarritoRepositorio.AgregarProductoAsync(carritoId, dto.ProductoId, dto.Cantidad);
            return Ok(new { mensaje = "Producto agregado al carrito" });
        }

        [HttpDelete("{carritoId}/QuitarProducto/{productoId}")]
        public async Task<IActionResult> QuitarProducto(int carritoId, int productoId)
        {
            try
            {
                await detalleCarritoRepositorio.QuitarProductoAsync(carritoId, productoId);
                return Ok(new { mensaje = "Producto quitado del carrito" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { mensaje = ex.Message });
            }
        }
    }
}
