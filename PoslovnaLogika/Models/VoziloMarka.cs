using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoslovnaLogika.Models
{
    public class VoziloMarka : Vozilo, IVoziloMarka
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Naziv { get; set; }
        public string Kratica { get; set; }

        public virtual ICollection<VoziloModel> VoziloModels { get; set; }
    }
}
