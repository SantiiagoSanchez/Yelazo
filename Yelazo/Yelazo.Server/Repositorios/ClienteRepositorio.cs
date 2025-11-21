using Microsoft.EntityFrameworkCore;
using Yelazo.BD.Data;
using Yelazo.BD.Data.Entity;
using Yelazo.Client.Pages.Pedido;
using Yelazo.Shared.DTO;

namespace Yelazo.Server.Repositorios
{
    public class ClienteRepositorio : IClienteRepositorio
    {
        private readonly Context context;

        public ClienteRepositorio(Context context)
        {
            this.context = context;
        }

        public async Task<List<PedidoDTO>> ObtenerHistorialPorId(string id)
        {
            var pedidos = await context.Pedidos.
                Include(p => p.Usuario).
                Where(p => p.UsuarioId == id).
                Select(p => new PedidoDTO
                {
                    Id = p.Id,
                    UsuarioId = p.UsuarioId,
                    UsuarioNombre = p.Usuario.Nombre + " " + p.Usuario.Apellido,
                    Total = p.Total,
                    Estado = p.Estado,
                    FechaPedido = p.FechaPedido
                }).ToListAsync();

            return pedidos;
        }
    }
}
