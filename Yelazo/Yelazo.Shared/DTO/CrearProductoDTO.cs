using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yelazo.Shared.DTO
{
    public class CrearProductoDTO
    {
        public string Nombre { get; set; }
        public string Presentacion { get; set; }

        public decimal Precio { get; set; }

        public int Cantidad { get; set; }

        public string Descripcion { get; set; }

    }
}
