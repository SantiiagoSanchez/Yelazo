using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yelazo.Shared.DTO
{
    public class CrearProveedorDTO
    {
        public string Nombre { get; set; }
        public string Telefono { get; set; }
        public string? Correo { get; set; } //Puede ser nulo
        public string Direccion { get; set; }
        public string Descripcion { get; set; }
    }
}
