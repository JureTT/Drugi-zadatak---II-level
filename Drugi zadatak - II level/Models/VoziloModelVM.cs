using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using PoslovnaLogika.Models;

namespace Drugi_zadatak___II_level.Models
{
    public class VoziloModelVM 
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [ForeignKey("VoziloMarka")]
        public int IdMarke { get; set; }
        public virtual VoziloMarkaVM VoziloMarka { get; set; }
        [Required]
        public string Naziv { get; set; }
        public string Kratica { get; set; }
    }
}