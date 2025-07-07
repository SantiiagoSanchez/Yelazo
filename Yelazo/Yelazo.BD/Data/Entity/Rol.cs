using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yelazo.BD.Data.Entity
{
    public class Rol : EntityBase
    {
        [Required(ErrorMessage = "El nombre del rol es obligatorio")]
        public string Nombre { get; set; }

    }
}
