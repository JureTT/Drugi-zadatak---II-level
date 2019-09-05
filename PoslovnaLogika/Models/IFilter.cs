namespace PoslovnaLogika.Models
{
    public interface IFilter
    {
        int? IdMarke { get; set; }
        string PretragaUpita { get; set; }
    }
}