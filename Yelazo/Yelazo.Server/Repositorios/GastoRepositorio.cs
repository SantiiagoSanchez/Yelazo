using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Yelazo.BD.Data;
using Yelazo.BD.Data.Entity;
using Yelazo.Shared.DTO;

namespace Yelazo.Server.Repositorios
{
    public class GastoRepositorio : Repositorio<Gasto>, IGastoRepositorio
    {
        private readonly Context context;

        public GastoRepositorio(Context context) : base(context)
        {
            this.context = context;
        }

        public async Task<List<Gasto>> GetGastoInclude()
        {
            return await context.Gastos
                .Include(s => s.Proveedor).Include(s => s.TipoGasto)// Incluir la entidad relacionada Producto
                .ToListAsync();
        }

        public async Task<ActionResult<IEnumerable<FiltrarGastoDTO>>> BuscarGastos(string? nombreTipoGasto, DateTime? fecha)
        {
            var query = context.Gastos
        .Include(g => g.TipoGasto)
        .Include(g => g.Proveedor)
        .AsQueryable();

            // Filtro por nombre del Tipo de Gasto
            if (!string.IsNullOrWhiteSpace(nombreTipoGasto))
            {
                query = query.Where(g => g.TipoGasto.Nombre.Contains(nombreTipoGasto));
            }

            // Filtro por fecha del Gasto
            if (fecha.HasValue)
            {
                query = query.Where(g => g.Fecha.Date == fecha.Value.Date);
            }

            // Proyección al DTO
            var resultados = await query.Select(g => new FiltrarGastoDTO
            {
                Id = g.Id,
                Fecha = g.Fecha,
                Descripcion = g.Descripcion,
                Costo = g.Costo,
                TipoGasto = g.TipoGasto.Nombre,
                Proveedor = new ProveedorDTO
                {
                    Id = g.Proveedor.Id,
                    Nombre = g.Proveedor.Nombre,
                    Telefono = g.Proveedor.Telefono,
                    Correo = g.Proveedor.Correo,
                    Direccion = g.Proveedor.Direccion
                }
            }).ToListAsync();

            return resultados;
        }
    }
}
