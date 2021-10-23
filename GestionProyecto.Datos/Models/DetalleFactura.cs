using System;
using System.Collections.Generic;

#nullable disable

namespace GestionProyecto.Datos.Models
{
    public partial class DetalleFactura
    {
        public int IdDetalle { get; set; }
        public int IdProducto { get; set; }
        public int Cantidad { get; set; }
        public double Precio { get; set; }
        public int IdFactura { get; set; }
    }
}
