using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yelazo.Shared.DTO
{
    public class PedidoDTO
    {
        public int Id { get; set; } 
        public string UsuarioId { get; set; } = string.Empty;
        public string Direccion { get; set; } = string.Empty;
        public decimal Total { get; set; }
        public string Estado { get; set; } = string.Empty;
        public DateTime FechaPedido { get; set; }
    }
}
