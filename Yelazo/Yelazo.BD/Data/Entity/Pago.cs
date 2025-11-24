using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yelazo.BD.Data.Entity
{
    public class Pago : EntityBase
    {
        public int PedidoId { get; set; }
        public Pedido Pedido { get; set; } 
        public decimal Monto { get; set; }
        public DateTime FechaPago { get; set; }
        public int MetodoPagoId { get; set; }
        public MetodoPago MetodoPago { get; set; } 
    }
}
