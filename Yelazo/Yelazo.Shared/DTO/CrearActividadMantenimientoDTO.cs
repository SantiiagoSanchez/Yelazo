using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yelazo.Shared.DTO
{
    public class CrearActividadMantenimientoDTO
    {

        public DateTime FechaActividad { get; set; } = DateTime.Now; //Por defecto, la fecha actual

        public decimal Precio { get; set; }

        public int ProveedorId { get; set; }

        public int MantenimientoId { get; set; }

        public int TipoGastoId { get; set; }
    }
}
