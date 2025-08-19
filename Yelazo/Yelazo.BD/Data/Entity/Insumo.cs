using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace Yelazo.BD.Data.Entity
{
    public class Insumo : EntityBase
    {
        [Required(ErrorMessage = "El nombre de la categoria de insumos es obligatorio")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "El stock de insumos es obligatorio")]

        public int Stock { get; set; }

        [Required(ErrorMessage = "La fecha de ultima actualizacion es obligatoria")]

        public DateTime FechaActualizacion { get; set; } = DateTime.Now; //Por defecto, la fecha actual

        [Required(ErrorMessage = "La categoria de insumos es obligatoria")]

        public string Categoria { get; set; }


    }
}
