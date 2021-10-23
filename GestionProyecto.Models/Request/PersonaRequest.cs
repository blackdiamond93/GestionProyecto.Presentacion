using System.ComponentModel.DataAnnotations;

namespace GestionProyecto.Models.Request
{
    public class PersonaRequest
    {
        public int IdPersona { get; set; }
        public int IdUsuario { get; set; }
        [Required]
        public string Nombre { get; set; }
        [Required]
        public string Apellido { get; set; }
        [Required]
        public bool? Sexo { get; set; }
        [Required]
        public string Direccion { get; set; }
    }
}
