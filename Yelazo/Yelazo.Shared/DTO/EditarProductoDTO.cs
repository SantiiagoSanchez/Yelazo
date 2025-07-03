using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yelazo.Shared.DTO
{
    public class EditarProductoDTO
    {
        public int Id { get; set; } 
        public string Nombre { get; set; }
        public string Presentacion { get; set; }

        public decimal Precio { get; set; }

        public string Descripcion { get; set; }

        //Falta poner la tabla Stock y hacer la relacion
        public int Stock { get; set; }
    }
}
