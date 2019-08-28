namespace PoslovnaLogika.Models
{
    public interface IVoziloSorter
    {
        string Poredak { get; set; }
        string Stupac { get; set; }

        void OdrediSortiranje(string sort);
    }
}