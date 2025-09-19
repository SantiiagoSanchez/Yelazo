using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yelazo.BD.Data.Entity
{
    public class Stock : EntityBase
    {
        public int ProductoId { get; set; }
        public Producto Producto { get; set; }


        [Required(ErrorMessage = "La fecha de actualizacion es obligatoria")]

        public DateTime FechaActualizacio { get; set; } = DateTime.Now; //Por defecto, la fecha actual

        [Required(ErrorMessage = "La cantidad es obligatoria")]
        public int Cantidad { get; set; }

        [Required(ErrorMessage = "El tipo de movimiento es obligatorio")]
        public string Movimiento { get; set; } //Entrada o Salida
    }
}
