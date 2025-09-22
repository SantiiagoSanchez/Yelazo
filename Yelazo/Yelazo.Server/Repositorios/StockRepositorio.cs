using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Yelazo.BD.Data;
using Yelazo.BD.Data.Entity;

namespace Yelazo.Server.Repositorios
{
    public class StockRepositorio : Repositorio<Stock>, IStockRepositorio
    {
        private readonly Context context;

        public StockRepositorio(Context context) : base(context)
        {
            this.context = context;
        }

        public async Task<List<Stock>> GetStockInclude()
        {
            return await context.Stocks
                .Include(s => s.Producto) // Incluir la entidad relacionada Producto
                .ToListAsync();
        }

        public async Task crearAsync(Stock stock)
        {
            context.Stocks.Add(stock);
            await context.SaveChangesAsync();
        }
    }
}
