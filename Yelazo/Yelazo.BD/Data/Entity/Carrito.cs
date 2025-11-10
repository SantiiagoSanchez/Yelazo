using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yelazo.BD.Data.Entity
{
    public class Carrito : EntityBase
    {
        public UsuarioYelazo Usuario { get; set; }
        public string UsuarioId { get; set; } // Llave foranea de UsuarioYelazo string porque IdentityUser usa string como Id

        public DateTime FechaCreacion { get; set; } = DateTime.Now;
        public DateTime? FechaModificacion { get; set; }

        public bool Finalizado { get; set; } = false; // Indica si el carrito ha sido finalizado (pedido realizado)

        public ICollection<DetalleCarrito> Detalles { get; set; } = new List<DetalleCarrito>();
    }
}
