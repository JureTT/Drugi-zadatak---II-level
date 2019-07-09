using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Drugi_zadatak___II_level.Models
{
    public class VoziloMarka : IVoziloMarka
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Naziv { get; set; }
        public string Kratica { get; set; }
    }
}