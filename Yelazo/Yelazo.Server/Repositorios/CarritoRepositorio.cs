using Microsoft.EntityFrameworkCore;
using Yelazo.BD.Data;
using Yelazo.BD.Data.Entity;

namespace Yelazo.Server.Repositorios
{
    public class CarritoRepositorio : Repositorio<Carrito>, ICarritoRepositorio
    {
        private readonly Context context;

        public CarritoRepositorio(Context context) : base(context)
        {
            this.context = context;
        }

        public async Task<Carrito?> ObtenerCarritoActivoAsync(string usuarioId)
        {
            return await context.Carritos
                .Include(c => c.Detalles) // si un carrito tiene productos, incluirlos
                .FirstOrDefaultAsync(c => c.UsuarioId == usuarioId && !c.Finalizado);
        }

        public async Task<Carrito> CrearCarritoAsync(Carrito carrito)
        {
            context.Carritos.Add(carrito);
            await context.SaveChangesAsync();
            return carrito;
        }
    }
}
