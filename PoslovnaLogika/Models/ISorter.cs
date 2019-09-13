namespace PoslovnaLogika.Models
{
    public interface ISorter
    {
        string Poredak { get; set; }
        string Stupac { get; set; }

        //void OdrediSortiranje(string sort);
    }
}