using System.ComponentModel.DataAnnotations;

namespace GestionProyecto.Models.Request
{
    public class DetalleRequest
    {
        public int IdDetalle { get; set; }
        
        public int IdFactura { get; set; }
        [Required]
        public int IdProducto { get; set; }
        [Required]
        public int Cantidad { get; set; }
        [Required]
        public double Precio { get; set; }
    }
}
