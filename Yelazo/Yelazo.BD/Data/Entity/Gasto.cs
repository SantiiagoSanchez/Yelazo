using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yelazo.BD.Data.Entity
{
    public class Gasto : EntityBase
    {
        [Required(ErrorMessage = "La descripcion del gasto es necesario")]
        public string Descripcion { get; set; }

        [Required(ErrorMessage = "El costo del gasto es necesario")]

        public decimal Costo { get; set; }

        [Required(ErrorMessage = "La fecha del gasto es necesaria")]

        public DateTime Fecha { get; set; } = DateTime.Now; //Por defecto, la fecha actual

        [Required(ErrorMessage = "El tipo de gasto para el costo es necesario")]
        public TipoGasto TipoGasto { get; set; }

        public int tipoGastoId { get; set; }

        [Required(ErrorMessage = "El proveedor para el costo, es necesario")]
        public Proveedor Proveedor { get; set; } 

        public int ProveedorId { get; set; }   


    }
}
