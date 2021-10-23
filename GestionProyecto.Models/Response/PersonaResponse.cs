using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionProyecto.Models.Response
{
    public class PersonaResponse
    {
        public int IdPersona { get; set; }
        public string usuario { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public bool? Sexo { get; set; }
        public string Direcccion { get; set; }
    }
}
