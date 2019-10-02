using PagedList;
using PagedList.Mvc;

namespace PoslovnaLogika.Models
{
    public interface IOdgovor
    {
        IPagedList<object> ListaIspisa { get; set; }
        //IPagedList<IVoziloMarka> ListaMarke { get; set; }
        //IPagedList<IVoziloModel> ListaModela { get; set; }
        //IPagedList<IVozilo> ListaVozila { get; set; }
        int Redovi { get; set; }
    }
}