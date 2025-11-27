using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yelazo.Shared.DTO
{
    public class DetalleIngresosDTO
    {
        public DateTime Fecha { get; set; }

        public decimal Monto { get; set; }

        public string MetodoPago { get; set; }

        public string Cliente { get; set; }
    }
}
