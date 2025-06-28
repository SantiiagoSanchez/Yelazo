using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yelazo.BD.Data.Entity
{
    public class Producto : EntityBase
    {
        public string Nombre { get; set; }
        public string Presentacion { get; set; }

        public decimal Precio { get; set; }

        public string Descripcion { get; set; }

        //Falta poner la tabla Stock y hacer la relacion
        public int Stock { get; set; }

    }
}
