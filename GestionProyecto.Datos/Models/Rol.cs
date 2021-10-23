using System;
using System.Collections.Generic;

#nullable disable

namespace GestionProyecto.Datos.Models
{
    public partial class Rol
    {
        public int IdRol { get; set; }
        public string Descripcion { get; set; }
        public bool? Estado { get; set; }
    }
}
