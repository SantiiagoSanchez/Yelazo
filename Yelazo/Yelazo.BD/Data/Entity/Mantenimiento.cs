using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yelazo.BD.Data.Entity
{
    public class Mantenimiento : EntityBase
    {
        [Required(ErrorMessage = "El nombre del mantenimiento es obligatorio")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "La frecuencia del mantenimiento es obligatoria")]

        public int Frecuencia { get; set; }

        [Required(ErrorMessage = "El precio del producto es obligatorio")]

        public decimal Precio { get; set; }

        [Required(ErrorMessage = "La descripcion del mantenimiento es obligatoria")]
        public string Descripcion { get; set; }

        [Required(ErrorMessage = "El estado del mantenimiento es obligatorio")]
        public bool Estado { get; set; }
    }
}
