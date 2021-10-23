using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GestionProyecto.Models.Request
{
    public class FacturaRequest
    {
        public int IdFactura { get; set; }
        [Required]
        public int IdUsuario { get; set; }
        [Required]
        public int IdCliente { get; set; }
        [Required]
        public double Iva { get; set; }
        [Required]
        public double Total { get; set; }
        public double Descuento { get; set; }
        [Required]
        public DateTime Fecha { get; set; }

    }
}
