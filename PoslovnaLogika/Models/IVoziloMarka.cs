using System.Collections.Generic;

namespace PoslovnaLogika.Models
{
    public interface IVoziloMarka
    {
        int Id { get; set; }
        string Kratica { get; set; }
        string Naziv { get; set; }
        ICollection<VoziloModel> VoziloModels { get; set; }
    }
}