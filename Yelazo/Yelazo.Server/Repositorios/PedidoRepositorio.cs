using Microsoft.EntityFrameworkCore;
using Yelazo.BD.Data;
using Yelazo.BD.Data.Entity;
using Yelazo.Client.Pages.Cliente;
using Yelazo.Shared.DTO;

namespace Yelazo.Server.Repositorios
{
    public class PedidoRepositorio : Repositorio<Pedido>, IPedidoRepositorio
    {
        private readonly Context context;

        public PedidoRepositorio(Context context) : base(context)
        {
            this.context = context;
        }

        public async Task<PedidoDTO> CrearPedidoDesdeCarrito(int carritoId)
        {
            var carrito = await context.Carritos
                       .Include(c => c.Detalles)
                       .ThenInclude(d => d.Producto)
                       .Include(c => c.Usuario)
                       .FirstOrDefaultAsync(c => c.Id == carritoId);

            if (carrito == null)
                throw new Exception("Carrito no encontrado");

            var pedido = new Pedido
            {
                CarritoId = carrito.Id,
                UsuarioId = carrito.UsuarioId,
                FechaPedido = DateTime.Now,
                Total = carrito.Total,
                Estado = "Pendiente",
                Saldo = carrito.Total,
                Usuario = carrito.Usuario
            };

            context.Pedidos.Add(pedido);
            await context.SaveChangesAsync();

            // Detalles del pedido
            foreach (var det in carrito.Detalles)
            {
                var dp = new DetallePedido
                {
                    PedidoId = pedido.Id,
                    ProductoId = det.ProductoId,
                    Cantidad = det.Cantidad,
                    Total = det.Total
                };
                context.DetallePedidos.Add(dp);
            }

            await context.SaveChangesAsync();

            // Mapear a DTO
            var pedidoDTO = new PedidoDTO
            {
                Id = pedido.Id,
                UsuarioId = pedido.UsuarioId,
                Direccion = pedido.Usuario?.Direccion ?? "",
                Total = pedido.Total,
                Estado = pedido.Estado,
                FechaPedido = pedido.FechaPedido
            };

            return pedidoDTO;
        }

        public async Task<List<PedidoDTO>> ObtenerPedidosActivos()
        {
            var pedidosDTO = await context.Pedidos
                .Include(p => p.Usuario) 
                .Where(p => p.Estado != "Entregado") // Filtrar pedidos no entregados
                .Select(p => new PedidoDTO
                {
                    Id = p.Id,
                    UsuarioId = p.UsuarioId,
                    UsuarioNombre = p.Usuario.Nombre + " " + p.Usuario.Apellido,
                    Direccion = p.Usuario.Direccion,
                    Total = p.Total,
                    Estado = p.Estado,
                    Zona = p.Usuario.Zona,
                    FechaPedido = p.FechaPedido
                })
                .ToListAsync();

            return pedidosDTO;
        }

        public async Task<List<DetallePedidoDTO>> ObtenerDetallesPorPedido(int pedidoId)
        {
            var detalles = await context.DetallePedidos
                .Include(d => d.Producto) 
                .Where(d => d.PedidoId == pedidoId)
                .Select(d => new DetallePedidoDTO
                {
                    NombreProducto = d.Producto.Nombre,
                    Cantidad = d.Cantidad,
                    FechaPedido = d.Pedido.FechaPedido,
                    TelefonoCliente = d.Pedido.Usuario.Telefono,
                    Ubicacion = d.Pedido.Usuario.Direccion,
                    Estado = d.Pedido.Estado,
                    Total = d.Total
                })
                .ToListAsync();

            return detalles;
        }

        public async Task<PedidoDTO> ObtenerUnPedido(int id) 
        {
            var pedido = await context.Pedidos
                .Include(p => p.Usuario)
                .FirstOrDefaultAsync(p => p.Id == id);
            if (pedido == null)
                throw new Exception("Pedido no encontrado");
            var pedidoDTO = new PedidoDTO
            {
                Id = pedido.Id,
                UsuarioId = pedido.UsuarioId,
                UsuarioNombre = pedido.Usuario.Nombre + " " + pedido.Usuario.Apellido,
                Direccion = pedido.Usuario.Direccion,
                Total = pedido.Total,
                Estado = pedido.Estado,
                FechaPedido = pedido.FechaPedido
            };
            return pedidoDTO;
        }

        public async Task<List<Pedido>> CuentaCorrientePorUsuario(string usuarioId)
        {
            var pedidos = await context.Pedidos
                .Where(p => p.UsuarioId == usuarioId && p.Saldo > 0)
                .OrderByDescending(p => p.FechaPedido).ToListAsync();
            return pedidos;
        }


    }
}
