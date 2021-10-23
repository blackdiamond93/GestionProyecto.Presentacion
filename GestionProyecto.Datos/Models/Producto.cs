using System;
using System.Collections.Generic;

#nullable disable

namespace GestionProyecto.Datos.Models
{
    public partial class Producto
    {
        public int IdProducto { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public int IdCategoria { get; set; }
        public bool? Estado { get; set; }
    }
}
