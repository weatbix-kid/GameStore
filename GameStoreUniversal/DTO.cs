using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStoreUniversal
{
    public class clsGenre
    {
        public int GenreID { get; set; }
        public string GenreName{ get; set; }
        public string SubGenres { get; set; }

        public List<clsAllGame> GameList { get; set; }
    }

    public class clsOrder
    {
        public int OrderID { get; set; }
        public int GameID { get; set; }
        public int Quantity { get; set; }
        public double OrderPrice { get; set; }
        public string OrderDate { get; set; }
        public string CustomerName { get; set; }
        public string City { get; set; }

        public override string ToString()
        {
            return string.Format("{0} {1} {2} {3} {4} {5}", GameID, Quantity, OrderPrice, OrderDate, CustomerName, City);
        }

        // public List<clsAllWork> WorksList { get; set; }
    }

    public class clsAllGame
    {
        public int GameID { get; set; }
        public int GenreID { get; set; }
        public string Title { get; set; }
        public double Price { get; set; }
        public string DateTimeModified { get; set; }
        public int Quantity { get; set; }
        public string ReleaseDate { get; set; }
        public string GameType { get; set; }
        public string Warranty { get; set; }
        public double? Discount { get; set; }


        public override string ToString()
        {
            return string.Format("{0}\t ${1}\t {2}", Title, Price, GameType[0]);
        }

        // public delegate void LoadGameFormDelegate(clsAllGame prGame);
        // public static LoadGameFormDelegate LoadGameForm;
        // 
        // public void EditDetails()
        // {
        //     LoadGameForm(this);
        // }
    }

}
