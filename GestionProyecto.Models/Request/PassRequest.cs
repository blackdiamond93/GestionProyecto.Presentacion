using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionProyecto.Models.Request
{
    public class PassRequest
    {
        [Required]
        public string pass { get; set; }
        public int id { get; set; }
    }
}
