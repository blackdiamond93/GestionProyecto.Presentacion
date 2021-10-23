using System.ComponentModel.DataAnnotations;

namespace GestionProyecto.Models.Request
   
{
    public class UsuarioRequest
    {
        [Required]
        public string Usuario { get; set; }
        [Required]
        [MinLength(8,ErrorMessage ="Requiere un minimo de 8 caracteres")]
        public string Password { get; set; }
        [Required]
        public int Rol { get; set; }
    }
}
