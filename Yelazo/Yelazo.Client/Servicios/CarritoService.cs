using Yelazo.Shared.DTO;

namespace Yelazo.Client.Servicios
{
    public class CarritoService : ICarritoService
    {
        private readonly IHttpServicio http;

        public CarritoService(IHttpServicio http)
        {
            this.http = http;
        }

        public async Task AgregarProductoAsync(int carritoId, int productoId, int cantidad)
        {
            var dto = new AgregarProductoDTO
            {
                ProductoId = productoId,
                Cantidad = cantidad
            };

            var respuesta = await http.Post<AgregarProductoDTO, object>($"api/Carrito/{carritoId}/AgregarProducto", dto);

            if (respuesta.Error)
            {
                throw new Exception($"No se pudo agregar el producto al carrito. {respuesta.Error}");
            }
        }

        public async Task QuitarProductoAsync(int carritoId, int productoId)
        {
            var respuesta = await http.Delete($"api/Carrito/{carritoId}/QuitarProducto/{productoId}");

            if (respuesta.Error)
            {
                throw new Exception($"No se pudo quitar el producto del carrito. {respuesta.Error}");
            }
        }
    }
}
