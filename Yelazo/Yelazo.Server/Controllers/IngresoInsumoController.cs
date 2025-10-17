using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Yelazo.BD.Data.Entity;
using Yelazo.Server.Repositorios;
using Yelazo.Shared.DTO;

namespace Yelazo.Server.Controllers
{
    [ApiController]
    [Route("api/IngresoInsumo")]
    public class IngresoInsumoController : ControllerBase
    {
        private readonly IIngresoInsumoRepositorio repositorio;
        private readonly IGastoRepositorio gastoRepositorio;
        private readonly IInsumoRepositorio insumoRepositorio;
        private readonly IMapper mapper;

        public IngresoInsumoController(IIngresoInsumoRepositorio repositorio,IGastoRepositorio gastoRepositorio, IInsumoRepositorio insumoRepositorio, IMapper mapper)
        {
            this.repositorio = repositorio;
            this.gastoRepositorio = gastoRepositorio;
            this.insumoRepositorio = insumoRepositorio;
            this.mapper = mapper;
        }

        [HttpGet()]
        public async Task<ActionResult<List<IngresoInsumo>>> GetInclude()
        {
            var ingresoInsumos = await repositorio.GetIngresoInsumoInclude();
            var dto = mapper.Map<List<IngresoInsumo>>(ingresoInsumos);
            return Ok(dto);
        }

        [HttpPost]
        public async Task<ActionResult<int>> Post(CrearIngresoInsumoDTO dto)
        {
            try
            {
                var entidad = mapper.Map<IngresoInsumo>(dto);
                var id = await repositorio.Insert(entidad);

                var gasto = new Gasto
                {
                    Fecha = dto.Fecha,
                    Costo = dto.Precio,
                    ProveedorId = dto.ProveedorId,
                    tipoGastoId = dto.TipoGastoId,
                    Descripcion = "Compra de insumos en la fabrica"
                };

                var insumo = await insumoRepositorio.SelectById(dto.InsumoId);
                if (insumo == null)
                {
                    return NotFound($"No se encontró el insumo con ID {dto.InsumoId}");
                }

                insumo.Stock += dto.Cantidad;
                insumo.FechaActualizacion = DateTime.Now;

                await insumoRepositorio.ActualizarAsync(insumo);
                await gastoRepositorio.Insert(gasto);

                return Ok(id);
            }
            catch (DbUpdateException ex)
            {
                var inner = ex.InnerException?.Message ?? "No inner exception.";
                return StatusCode(500, $"Error al guardar los cambios: {ex.Message}. Inner: {inner}");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error general del servidor: {ex.Message}");
            }

        }
    }
}
