using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yelazo.Shared.DTO
{
    public class CrearInsumosDTO
    {
        public string Nombre { get; set; }


        public int Stock { get; set; }


        public DateTime FechaActualizacion { get; set; } = DateTime.Now; //Por defecto, la fecha actual


        public string Categoria { get; set; }
    }
}
