namespace PoslovnaLogika.Models
{
    public interface IVoziloModel
    {
        int Id { get; set; }
        int IdMarke { get; set; }
        string Kratica { get; set; }
        string Naziv { get; set; }
        VoziloMarka VoziloMarka { get; set; }
    }
}