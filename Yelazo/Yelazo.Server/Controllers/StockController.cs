using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Yelazo.BD.Data.Entity;
using Yelazo.Server.Repositorios;
using Yelazo.Shared.DTO;

namespace Yelazo.Server.Controllers
{
    [ApiController]
    [Route("api/Stock")]
    public class StockController : ControllerBase
    {
        private readonly IStockRepositorio repositorio;
        private readonly IMapper mapper;
        private readonly IProductoRepositorio productoRepositorio;

        public StockController(IStockRepositorio repositorio, IMapper mapper, IProductoRepositorio productoRepositorio)
        {
            this.repositorio = repositorio;
            this.mapper = mapper;
            this.productoRepositorio = productoRepositorio;
        }

        [HttpGet()]
        public async Task<ActionResult<List<Stock>>> GetAll()
        {
            var stock = await repositorio.GetStockInclude();
            var dto = mapper.Map<List<Stock>>(stock);
            return Ok(dto);
        }

        [HttpPost()]
        public async Task<ActionResult<int>> CrearStock([FromBody] CrearStockDTO dto)
        {
            //Validamos la cantidad que entra
            if (dto.Cantidad <= 0)
            {
                return BadRequest("La cantidad tiene que ser mayor a 0");
            }


            var producto = await productoRepositorio.GetById(dto.ProductoId);

            //Validamos que el producto exista
            if (producto == null) 
            {
                return BadRequest("El producto no existe");
            }

            if (dto.Movimiento == "Entrada") 
            {
                producto.Cantidad += dto.Cantidad;
            }
            else if (dto.Movimiento == "Salida") 
            {
                producto.Cantidad -= dto.Cantidad;
            }

            var historial = new Stock
            {
                ProductoId = dto.ProductoId,
                FechaActualizacio = dto.FechaActualizacio,
                Cantidad = dto.Cantidad,
                Movimiento = dto.Movimiento
            };

            await productoRepositorio.actualizarAsync(producto);
            await repositorio.crearAsync(historial);

            return Ok(historial.Id);

        }
    }
}
