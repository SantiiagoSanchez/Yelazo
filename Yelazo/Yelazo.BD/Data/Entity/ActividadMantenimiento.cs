using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yelazo.BD.Data.Entity
{
    public class ActividadMantenimiento : EntityBase
    {

        public DateTime FechaActividad { get; set; } = DateTime.Now; //Por defecto, la fecha actual
        public decimal Precio { get; set; }

        public int ProveedorId { get; set; }
        public Proveedor Proveedor { get; set; }

        public int MantenimientoId { get; set; }
        public Mantenimiento Mantenimiento { get; set; }
    }
}
