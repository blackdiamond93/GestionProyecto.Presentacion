using System;
using System.Collections.Generic;

#nullable disable

namespace GestionProyecto.Datos.Models
{
    public partial class Categorium
    {
        public int IdCategoria { get; set; }
        public string Descripcion { get; set; }
        public bool? Estado { get; set; }
    }
}
