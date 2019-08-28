namespace PoslovnaLogika.Models
{
    public interface IVoziloFilter
    {
        int? IdMarke { get; set; }
        string Naziv { get; set; }

        void UnesiFiltere(string naziv);
        void UnesiFiltere(string naziv, int? idMarke);
    }
}