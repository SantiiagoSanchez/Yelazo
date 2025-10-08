using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yelazo.Shared.DTO
{
    public class RenovarMantenimiento
    {
        public DateTime FechaActividad { get; set; } = DateTime.Today;
        public decimal Precio { get; set; }
        public int ProveedorId { get; set; }
        public int TipoGastoId { get; set; }
        public List<DetalleInsumo> Insumos { get; set; } = new();
    }
}
