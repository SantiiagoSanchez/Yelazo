using Microsoft.EntityFrameworkCore;
using Yelazo.BD.Data;
using Yelazo.BD.Data.Entity;
using Yelazo.Shared.DTO;

namespace Yelazo.Server.Repositorios
{
    public class ActividadMantenimientoRepositorio : Repositorio<ActividadMantenimiento>, IActividadMantenimientoRepositorio
    {
        private readonly Context context;
        public ActividadMantenimientoRepositorio(Context context) : base(context)
        {
            this.context = context;
        }

        public async Task<List<ActividadMantenimiento>> GetActividadMantenimientoInclude()
        {
            return await context.ActividadMantenimientos
                .Include(s => s.Proveedor).Include(s => s.Mantenimiento)// Incluir la entidad relacionada
                .ToListAsync();
        }

        public async Task<List<MantenimientoCardDTO>> ObtenerMantenimientosConUltimaActividad()
        {
            var mantenimientos = await context.Mantenimientos
        .Include(m => m.ActividadesMantenimiento) // Asegúrate de tener esta relación en el modelo
        .ToListAsync();

            var resultado = mantenimientos.Select(m =>
            {
                var ultimaActividad = m.ActividadesMantenimiento?
                    .OrderByDescending(a => a.FechaActividad)
                    .FirstOrDefault();

                return new MantenimientoCardDTO
                {
                    MantenimientoId = m.Id,
                    Nombre = m.Nombre,
                    Descripcion = m.Descripcion,
                    Frecuencia = m.Frecuencia,
                    Insumo = m.Insumo,
                    Estado = m.Estado,
                    UltimaFecha = ultimaActividad?.FechaActividad,
                    ProximaFecha = ultimaActividad != null
                        ? ultimaActividad.FechaActividad.AddDays(m.Frecuencia)
                        : (DateTime?)null
                };
            }).ToList();

            return resultado;

        }
    }
}

