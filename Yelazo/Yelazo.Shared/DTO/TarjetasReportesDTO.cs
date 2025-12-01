using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yelazo.Shared.DTO
{
    public class TarjetasReportesDTO
    {
        public string TopCliente { get; set; } = null!;

        public string TopProducto { get; set; } = null!;

        public string TopZona { get; set; } = null!;

        public int TotalClientes { get; set; } = 0;
    }
}
