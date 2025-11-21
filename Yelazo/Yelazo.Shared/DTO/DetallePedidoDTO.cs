using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yelazo.Shared.DTO
{
    public class DetallePedidoDTO
    {
        public string NombreProducto { get; set; }
        public int Cantidad { get; set; }
        public decimal Total { get; set; }

        public DateTime FechaPedido { get; set; }

        public string TelefonoCliente { get; set; }

        public string Ubicacion { get; set; }

        public string Estado { get; set; }
    }
}
