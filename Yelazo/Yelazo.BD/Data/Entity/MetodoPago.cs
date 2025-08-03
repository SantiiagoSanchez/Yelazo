using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yelazo.BD.Data.Entity
{
    public class MetodoPago : EntityBase
    {
        [Required(ErrorMessage = "El nombre del Metodo de pago es obligatorio")]
        public string Nombre { get; set; }
    }
}
