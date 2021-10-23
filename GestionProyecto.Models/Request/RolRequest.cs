using System.ComponentModel.DataAnnotations;

namespace GestionProyecto.Models.Request
{
    public class RolRequest
    {
        public int Id { get; set; }
        [Required]
        [MinLength(10,ErrorMessage ="Requiere una descripcion")]
        public string Descripcion { get; set; }
    }
}
