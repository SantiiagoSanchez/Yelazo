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
    }
}
