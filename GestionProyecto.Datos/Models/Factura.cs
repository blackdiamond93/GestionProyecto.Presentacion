using System;
using System.Collections.Generic;

#nullable disable

namespace GestionProyecto.Datos.Models
{
    public partial class Factura
    {
        public int IdFactura { get; set; }
        public int IdUsuario { get; set; }
        public int IdCliente { get; set; }
        public double Iva { get; set; }
        public double Total { get; set; }
        public double Descuento { get; set; }
        public DateTime Fecha { get; set; }
        public bool? Estado { get; set; }
    }
}
