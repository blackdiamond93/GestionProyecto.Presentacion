using System.ComponentModel.DataAnnotations;

namespace GestionProyecto.Models.Request
{
    public class ProductoRequest
    {
        public int IdProducto { get; set; }
        [Required]
        public string Nombre { get; set; }
        [Required]
        public string Descripcion { get; set; }
        [Required]
        public int IdCategoria { get; set; }
    }
}
