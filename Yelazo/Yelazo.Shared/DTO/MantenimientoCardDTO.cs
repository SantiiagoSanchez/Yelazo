using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yelazo.Shared.DTO
{
    public class MantenimientoCardDTO
    {
        public int MantenimientoId { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public int Frecuencia { get; set; }
        public bool Insumo { get; set; }
        public bool Estado { get; set; }

        public DateTime? UltimaFecha { get; set; }
        public DateTime? ProximaFecha { get; set; }
    }
}
