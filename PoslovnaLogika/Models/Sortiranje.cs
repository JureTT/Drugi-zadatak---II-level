using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoslovnaLogika.Models
{
    public class Sortiranje : ISortiranje
    {
        string sort;
        string poredak;
        string stupac;
        public string Sort { get => sort; set => sort = value; }
        public string Poredak { get => poredak; set => poredak = value; }
        public string Stupac { get => stupac; set => stupac = value; }

        public void OdrediSortiranje(string sort)
        {            
            switch (sort)
            {
                case "A_Id":
                    Sort = " ORDER BY Id ASC ";
                    Stupac = "Id";
                    Poredak = "asc";
                    break;
                case "D_Id":
                    Sort = " ORDER BY Id DESC ";
                    Stupac = "Id";
                    Poredak = "desc";
                    break;
                case "A_IdMarke":
                    Sort = " ORDER BY IdMarke ASC ";
                    Stupac = "IdMarke";
                    Poredak = "asc";
                    break;
                case "D_IdMarke":
                    Sort = " ORDER BY IdMarke DESC ";
                    Stupac = "IdMarke";
                    Poredak = "desc";
                    break;
                case "A_Naziv":
                    Sort = " ORDER BY Naziv ASC";
                    Stupac = "Naziv";
                    Poredak = "asc";
                    break;
                case "D_Naziv":
                    Sort = " ORDER BY Naziv DESC";
                    Stupac = "Naziv";
                    Poredak = "desc";
                    break;
                case "A_Kratica":
                    Sort = " ORDER BY Kratica ASC";
                    Stupac = "Kratica";
                    Poredak = "asc";
                    break;
                case "D_Kratica":
                    Sort = " ORDER BY Kratica DESC";
                    Stupac = "Kratica";
                    Poredak = "desc";
                    break;
                default:     // -- moguće da je default višak i da ja dovoljno sam staviti asc Id
                    Sort = "";
                    Stupac = "";
                    Poredak = "";
                    break;
            }
        }
    }
}
