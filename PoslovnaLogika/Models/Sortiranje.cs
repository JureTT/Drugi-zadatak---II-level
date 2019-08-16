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
        public string Sort { get => sort; set => sort = value; }

        public void OdrediSortiranje(string sort)
        {            
            switch (sort)
            {
                case "A_Id":
                    Sort = " ORDER BY Id ASC ";
                    break;
                case "D_Id":
                    Sort = " ORDER BY Id DESC ";
                    break;
                case "A_IdMarke":
                    Sort = " ORDER BY IdMarke ASC ";
                    break;
                case "D_IdMarke":
                    Sort = " ORDER BY IdMarke DESC ";
                    break;
                case "A_Naziv":
                    Sort = " ORDER BY Naziv ASC";
                    break;
                case "D_Naziv":
                    Sort = " ORDER BY Naziv DESC";
                    break;
                case "A_Kratica":
                    Sort = " ORDER BY Kratica ASC";
                    break;
                case "D_Kratica":
                    Sort = " ORDER BY Kratica DESC";
                    break;
                default:     // -- moguće da je default višak i da ja dovoljno sam staviti asc Id
                    Sort = "";
                    break;
            }
        }
    }
}
