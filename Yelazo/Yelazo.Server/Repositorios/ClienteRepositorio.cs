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

        public async Task<List<GetHistorialPedidosDTO>> ObtenerHistorialPorId(string id)
        {
            var pedidos = await context.Pedidos.
                Include(p => p.Usuario).
                Include(p => p.Detalles).
                ThenInclude(d => d.Producto).
                Where(p => p.UsuarioId == id).
                Select(p => new GetHistorialPedidosDTO
                {
                    Id = p.Id,
                    UsuarioId = p.UsuarioId,
                    UsuarioNombre = p.Usuario.Nombre + " " + p.Usuario.Apellido,
                    Total = p.Total,
                    Estado = p.Estado,
                    FechaPedido = p.FechaPedido,
                    Detalles = p.Detalles.Select(d => new DetallePedidoDTO
                    {
                        NombreProducto = d.Producto.Nombre,
                        Cantidad = d.Cantidad,
                        Total = d.Total,
                        FechaPedido = p.FechaPedido,
                        Estado = p.Estado
                    }).ToList()
                }).ToListAsync();



            return pedidos;
        }
    }
}
