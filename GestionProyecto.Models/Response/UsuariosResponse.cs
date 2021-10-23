using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionProyecto.Models.Response
{
    public class UsuariosResponse
    {
        public int Id { get; set; }
        public string Usuarios { get; set; }

        public string Nombre { get; set; }
        public  string Rols { get; set; }
    }
}
