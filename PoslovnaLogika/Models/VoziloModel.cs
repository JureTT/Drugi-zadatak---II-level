using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoslovnaLogika.Models
{
    public class VoziloModel : IVoziloModel
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int IdMarke { get; set; }
        public virtual VoziloMarka VoziloMarka { get; set; }
        [Required]
        public string Naziv { get; set; }
        public string Kratica { get; set; }
    }
}
