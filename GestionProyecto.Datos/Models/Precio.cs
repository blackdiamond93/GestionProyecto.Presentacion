using System;
using System.Collections.Generic;

#nullable disable

namespace GestionProyecto.Datos.Models
{
    public partial class Precio
    {
        public int IdPrecio { get; set; }
        public int IdProducto { get; set; }
        public double? Precio1 { get; set; }
    }
}
