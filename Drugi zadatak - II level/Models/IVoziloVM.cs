namespace Drugi_zadatak___II_level.Models
{
    public interface IVoziloVM
    {
        int IdMarka { get; set; }
        int IdModel { get; set; }
        string Kratica { get; set; }
        string NazivMarka { get; set; }
        string NazivModel { get; set; }
    }
}