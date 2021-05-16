using System;
using System.Collections.Generic;

#nullable disable

namespace PruebasDeConexion.Model
{
    public partial class Persona
    {
        public Guid Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Telefono { get; set; }
        public string Ciudad { get; set; }
        public string Correo { get; set; }
    }
}
