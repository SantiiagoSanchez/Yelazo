using Yelazo.BD.Data;
using Yelazo.BD.Data.Entity;

namespace Yelazo.Server.Repositorios
{
    public class InsumoRepositorio : Repositorio<Insumo>, IInsumoRepositorio
    {
        private readonly Context context;
        public InsumoRepositorio(Context context) : base(context)
        {
            this.context = context;
        }

        public async Task ActualizarAsync(Insumo insumo)
        {
            context.Insumos.Update(insumo);
            await context.SaveChangesAsync();
        }
    }
}
