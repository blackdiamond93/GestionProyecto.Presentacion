using System.ComponentModel.DataAnnotations;

namespace GestionProyecto.Models.Request
{
    public class CategoriaRequest
    {
        public int Id{ get; set; }
        [Required]
        public string Descripcion { get; set; }
    }
}
