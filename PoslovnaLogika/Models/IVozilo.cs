namespace PoslovnaLogika.Models
{
    public interface IVozilo
    {
        int Id { get; set; }
        string Naziv { get; set; }
        string Kratica { get; set; }
    }
}