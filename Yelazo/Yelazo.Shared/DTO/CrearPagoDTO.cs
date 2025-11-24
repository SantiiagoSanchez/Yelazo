using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yelazo.Shared.DTO
{
    public class CrearPagoDTO
    {
        public int PedidoId { get; set; }
        public int MetodoPagoId { get; set; }
        public decimal Monto { get; set; }

        public DateTime FechaPago { get; set; }
    }
}
