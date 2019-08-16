namespace PoslovnaLogika.Models
{
    public interface IStranice
    {
        int BrIspisa { get; set; }
        int Strana { get; set; }

        void UnesiStranice(int? strana);
    }
}