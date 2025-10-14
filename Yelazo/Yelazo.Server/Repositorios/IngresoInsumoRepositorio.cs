using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using Yelazo.BD.Data;
using Yelazo.BD.Data.Entity;

namespace Yelazo.Server.Repositorios
{
    public class IngresoInsumoRepositorio : Repositorio<IngresoInsumo>, IIngresoInsumoRepositorio
    {
        private readonly Context context;
        public IngresoInsumoRepositorio(Context context) : base(context)
        {
            this.context = context;
        }

        public async Task<List<IngresoInsumo>> GetIngresoInsumoInclude()
        {
             return await context.IngresoInsumos
                 .Include(ii => ii.Proveedor)
                 .Include(ii => ii.Insumo)
                 .ToListAsync();
        }
    }
}
