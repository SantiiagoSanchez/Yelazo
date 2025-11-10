using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yelazo.BD.Data.Entity
{
    public class Pedido : EntityBase
    {
        public UsuarioYelazo Usuario { get; set; }
        public string UsuarioId { get; set; } // Llave foranea de UsuarioYelazo string porque IdentityUser usa string como Id

        public Carrito Carrito { get; set; }
        public int CarritoId { get; set; }

        public DateTime FechaPedido { get; set; }
        public decimal Total { get; set; }
        public string Estado { get; set; } // Ejemplo: "Pendiente", "Enviado", "Entregado"

        public decimal Saldo { get; set; }

        public ICollection<DetallePedido> Detalles { get; set; } = new List<DetallePedido>();

    }
}
