using System;

namespace GestionProyecto.Models.Response
{
    public class FacturaResponse
    {
        public int IdFactura { get; set; }
        public string Usuarios { get; set; }
        public string Clientes { get; set; }
        public double Iva { get; set; }
        public double Total { get; set; }
        public double Descuento { get; set; }
        public DateTime Fecha { get; set; }
        public bool Estado { get; set; }
    }
}
