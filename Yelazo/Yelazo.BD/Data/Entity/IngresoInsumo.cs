using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yelazo.BD.Data.Entity
{
    public class IngresoInsumo : EntityBase
    {
        [Required(ErrorMessage = "La cantidad de insumos comprada es obligatoria")]
        public int Cantidad { get; set; }

        [Required(ErrorMessage = "La fecha de compra es obligatoria")]
        public DateTime Fecha { get; set; } = DateTime.Now; 

        [Required(ErrorMessage = "El precio de la compra de insumo es obligatorio")]
        public decimal Precio { get; set; }

        [Required(ErrorMessage = "El insumo es obligatorio")]
        public int InsumoId { get; set; }

        public Insumo Insumo { get; set; }

        [Required(ErrorMessage = "El proveedor es obligatorio")]
        public int ProveedorId { get; set; }

        public Proveedor Proveedor { get; set; }
    }
}
