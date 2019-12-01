using PagedList;
using PagedList.Mvc;

namespace PoslovnaLogika.Models
{
    public interface IOdgovor<T>
    {
        IPagedList<T> ListaIspisa { get; set; }
    }
}