using Microsoft.EntityFrameworkCore;
using Yelazo.BD.Data;
using Yelazo.BD.Data.Entity;

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
    }
}
