using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yelazo.BD.Data.Entity
{
    public class DetalleActividadMantenimiento : EntityBase
    {
       
        public int Cantidad { get; set; }

        public int InsumoId { get; set; }
        public Insumo Insumo { get; set; }

        public int ActividadMantenimientoId { get; set; }
        public ActividadMantenimiento ActividadMantenimiento { get; set; }
    }
}
