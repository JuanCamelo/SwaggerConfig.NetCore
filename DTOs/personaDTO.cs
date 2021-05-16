using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PruebasDeConexion.DTOs
{
    public class personaDTO
    {
        public Guid Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Telefono { get; set; }
        public string Ciudad { get; set; }
        public string Correo { get; set; }
    }
}
