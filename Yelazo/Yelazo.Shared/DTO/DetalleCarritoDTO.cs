using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yelazo.Shared.DTO
{
    public class DetalleCarritoDTO
    {
        public int Id { get; set; }
        public int Cantidad { get; set; }

        public ProductoCarritosDTO Producto { get; set; } = new ProductoCarritosDTO();
    }
}
