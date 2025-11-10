using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yelazo.BD.Data.Entity
{
    public class DetallePedido : EntityBase
    {
        public Pedido Pedido { get; set; }
        public int PedidoId { get; set; }

        public Producto Producto { get; set; }
        public int ProductoId { get; set; }

        public int Cantidad { get; set; }
        public decimal Total { get; set; } // Total = Precio * Cantidad
    }
}
