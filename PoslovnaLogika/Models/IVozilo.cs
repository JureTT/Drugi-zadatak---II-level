namespace PoslovnaLogika.Models
{
    public interface IVozilo
    {
        int IdMarka { get; set; }
        int IdModel { get; set; }
        string Kratica { get; set; }
        string NazivMarka { get; set; }
        string NazivModel { get; set; }
    }
}