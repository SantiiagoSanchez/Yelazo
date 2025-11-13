using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yelazo.Shared.DTO
{
    public class CarritoDTO
    {
        public int Id { get; set; }
        public List<DetalleCarritoDTO> Detalles { get; set; } = new();

        public decimal Total { get; set; }
    }
}
