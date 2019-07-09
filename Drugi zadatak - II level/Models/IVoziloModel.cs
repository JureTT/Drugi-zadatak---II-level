namespace Drugi_zadatak___II_level.Models
{
    public interface IVoziloModel
    {
        int Id { get; set; }
        int IdMarke { get; set; }
        string Kratica { get; set; }
        string Naziv { get; set; }
    }
}