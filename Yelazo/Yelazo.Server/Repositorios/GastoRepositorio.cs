using Microsoft.EntityFrameworkCore;
using Yelazo.BD.Data;
using Yelazo.BD.Data.Entity;

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
    }
}
