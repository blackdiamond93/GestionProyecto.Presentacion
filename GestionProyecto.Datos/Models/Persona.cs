using System;
using System.Collections.Generic;

#nullable disable

namespace GestionProyecto.Datos.Models
{
    public partial class Persona
    {
        public int IdPersona { get; set; }
        public int IdUsuario { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public bool? Sexo { get; set; }
        public string Direcccion { get; set; }
    }
}
