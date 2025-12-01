using Microsoft.EntityFrameworkCore;
using Yelazo.BD.Data;
using Yelazo.Shared.DTO;

namespace Yelazo.Server.Repositorios
{
    public class EstadisticasRepositorio : IEstadisticasRepositorio
    {
        private readonly Context context;

        public EstadisticasRepositorio(Context context)
        {
            this.context = context;
        }

        public async Task<IngresosAnualesDTO> GetIngresosAnuales(int anio)
        {
            var pagos = context.Pagos.Where(p => p.FechaPago.Year == anio);

            var ingresosPorMes = await pagos
                .GroupBy(p => p.FechaPago.Month)
                .Select(g => new IngresosMesDTO
                {
                    Mes = g.Key,
                    TotalIngresos = g.Sum(p => p.Monto),
                    CantidadIngresos = g.Count()
                })
                .ToListAsync();

            return new IngresosAnualesDTO { IngresosPorMes = ingresosPorMes };

        }

        public async Task<List<DetalleIngresosDTO>> GetIngresosDetallados(int anio, int mes)
        {
            return await context.Pagos.Where(p => p.FechaPago.Year == anio && p.FechaPago.Month == mes).Select(p => new DetalleIngresosDTO
            {
                Fecha = p.FechaPago,
                Monto = p.Monto,
                MetodoPago = p.MetodoPago.Nombre,
                Cliente = p.Pedido.Usuario.Nombre + " " + p.Pedido.Usuario.Apellido
            })
                .ToListAsync();
        }

        public async Task<TarjetasReportesDTO> ObtenerTarjetasAsync()
        {
            var dto = new TarjetasReportesDTO();

            dto.TopCliente = await context.Pedidos
                .Include(p => p.Usuario)
                .GroupBy(p => new { p.Usuario.Id, p.Usuario.Nombre, p.Usuario.Apellido })
                .OrderByDescending(g => g.Sum(x => x.Total))
                .Select(g => g.Key.Nombre + " " + g.Key.Apellido)
                .FirstOrDefaultAsync() ?? "N/A";

            dto.TopProducto = await context.DetallePedidos
                .Include(d => d.Producto)
                .GroupBy(d => new { d.Producto.Id, d.Producto.Nombre })
                .OrderByDescending(g => g.Sum(x => x.Cantidad))
                .Select(g => g.Key.Nombre)
                .FirstOrDefaultAsync() ?? "N/A";

            dto.TopZona = await context.Pedidos
                .Include(p => p.Usuario)
                .Where(p => p.Usuario.Zona != null)
                .GroupBy(p => p.Usuario.Zona!)
                .OrderByDescending(g => g.Count())
                .Select(g => g.Key)
                .FirstOrDefaultAsync() ?? "N/A";

            dto.TotalClientes = await context.Users.CountAsync();

            return dto;
        }
    }
}
