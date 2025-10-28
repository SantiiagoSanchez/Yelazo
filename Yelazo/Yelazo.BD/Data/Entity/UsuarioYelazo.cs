using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yelazo.BD.Data.Entity
{
    public class UsuarioYelazo : IdentityUser
    {
        [Required(ErrorMessage = "El nombre del usuario es obligatorio")]

        public string Nombre { get; set; }

        [Required(ErrorMessage = "El apellido del usuario es obligatorio")]
        public string Apellido { get; set; }

        [Required(ErrorMessage = "El telefono del usuario es obligatorio")]
        public string Telefono { get; set; }

        [Required(ErrorMessage = "La direccion del usuario es obligatoria")]
        public string Direccion { get; set; }

        public string? Zona { get; set; }

        public bool? Estado { get; set; }
    }
}
