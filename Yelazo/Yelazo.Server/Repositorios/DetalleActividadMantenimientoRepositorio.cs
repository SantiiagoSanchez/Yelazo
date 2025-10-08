using Microsoft.EntityFrameworkCore;
using Yelazo.BD.Data;
using Yelazo.BD.Data.Entity;

namespace Yelazo.Server.Repositorios
{
    public class DetalleActividadMantenimientoRepositorio : Repositorio<DetalleActividadMantenimiento>, IDetalleActividadMantenimientoRepositorio
    {
        private readonly Context context;

        public DetalleActividadMantenimientoRepositorio(Context context) : base(context)
        {
            this.context = context;
        }

        public async Task InsertarDetalleActividad(DetalleActividadMantenimiento detalle)
        {
            var insumo = await context.Insumos.FirstOrDefaultAsync(i => i.Id == detalle.InsumoId);
            if (insumo == null)
            {
                throw new Exception($"No existe el insumo con Id {detalle.InsumoId}");
            }

            insumo.Stock -= detalle.Cantidad;

            await context.DetalleActividadMantenimientos.AddAsync(detalle);
            await context.SaveChangesAsync();
        }
    }
}
