using Yelazo.BD.Data;
using Yelazo.BD.Data.Entity;
using Yelazo.Shared.DTO;

namespace Yelazo.Server.Repositorios
{
    public class PagoRepositorio : Repositorio<Pago>, IPagoRepositorio
    {
        private readonly Context context;

        public PagoRepositorio(Context context) : base(context)
        {
            this.context = context;
        }

        public async Task<Pago> CrearPagoAsync(CrearPagoDTO dto)
        {
            var pedido = await context.Pedidos.FindAsync(dto.PedidoId);

            if (pedido == null)
            {
                throw new Exception("Pedido no encontrado");
            }

            if (dto.Monto > pedido.Saldo)
                dto.Monto = pedido.Saldo;

            var pago = new Pago
            {
                PedidoId = pedido.Id,
                FechaPago = DateTime.Now,
                Monto = dto.Monto,
                MetodoPagoId = dto.MetodoPagoId
            };
            context.Pagos.Add(pago);

            pedido.Saldo -= dto.Monto;
            pedido.Estado = "Entregado";

            await context.SaveChangesAsync();
            return pago;
        }
    }
}
