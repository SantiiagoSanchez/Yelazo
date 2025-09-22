using Yelazo.BD.Data;
using Yelazo.BD.Data.Entity;

namespace Yelazo.Server.Repositorios
{
    public class ProductoRepositorio : Repositorio<Producto>, IProductoRepositorio
    {
        private readonly Context context;

        public ProductoRepositorio(Context context) : base(context)
        {
            this.context = context;
        }

        public async Task<Producto> GetById(int id)
        {
            return await context.Productos.FindAsync(id);
        }

        public async Task actualizarAsync(Producto producto)
        {
            context.Productos.Update(producto);
            await context.SaveChangesAsync();
        }
    }
}
