using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Yelazo.BD.Data.Entity;
using Yelazo.Server.Repositorios;

namespace Yelazo.Server.Controllers
{
    [ApiController]
    [Route("api/Stock")]
    public class StockController : ControllerBase
    {
        private readonly IStockRepositorio repositorio;
        private readonly IMapper mapper;

        public StockController(IStockRepositorio repositorio, IMapper mapper)
        {
            this.repositorio = repositorio;
            this.repositorio = repositorio;
            this.mapper = mapper;
        }

        [HttpGet()]
        public async Task<ActionResult<List<Stock>>> GetAll()
        {
            var stock = await repositorio.GetStockInclude();
            var dto = mapper.Map<List<Stock>>(stock);
            return Ok(dto);
        }
    }
}
