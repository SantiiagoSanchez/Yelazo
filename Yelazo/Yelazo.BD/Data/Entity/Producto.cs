using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yelazo.BD.Data.Entity
{       
    public class Producto : EntityBase
    {
        [Required(ErrorMessage = "El nombre del producto es obligatorio")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "La presentacion del producto es obligatoria")]
        public string Presentacion { get; set; }

        [Required(ErrorMessage = "El precio del producto es obligatorio")]

        public decimal Precio { get; set; }

        [Required(ErrorMessage = "La descripcion del producto es obligatoria")]

        public string Descripcion { get; set; }

        [Required(ErrorMessage = "La cantidad del producto es obligatoria")]

        public int Cantidad { get; set; } = 0;

    }
}
