using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yelazo.Shared.DTO
{
    public class CrearCarritoDTO
    {
        public string UsuarioId { get; set; } = string.Empty;
        public DateTime FechaCreacion { get; set; }
    }
}
