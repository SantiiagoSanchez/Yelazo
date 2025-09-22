using Microsoft.AspNetCore.Mvc;
using Yelazo.BD.Data.Entity;

namespace Yelazo.Server.Repositorios
{
    public interface IStockRepositorio
    {
        Task crearAsync(Stock stock);
        Task<List<Stock>> GetStockInclude();
    }
}