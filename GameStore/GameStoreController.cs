using System;
using System.Collections.Generic;
using System.Data;
using System.Web.Http;

namespace GameStore
{
    public class GameStoreController : System.Web.Http.ApiController
    {
        public List<string> GetGenreNames()
        {
            DataTable lcResult = clsDbConnection.GetDataTable("SELECT GenreName FROM Genre", null);
            List<string> lcNames = new List<string>();
            foreach (DataRow dr in lcResult.Rows)
                lcNames.Add((string)dr[0]);
            return lcNames;
        }

        public clsGenre GetGenre(string Name)
        {
            Dictionary<string, object> par = new Dictionary<string, object>(1);
            par.Add("Name", Name);
            DataTable lcResult = clsDbConnection.GetDataTable("SELECT * FROM Genre WHERE GenreName = @Name", par);
            if (lcResult.Rows.Count > 0)
                return new clsGenre()
                {
                    GenreID = (int)lcResult.Rows[0]["GenreID"],
                    GenreName = (string)lcResult.Rows[0]["GenreName"],
                    SubGenres = (string)lcResult.Rows[0]["SubGenres"],
                    GameList = getGenreGame((int)lcResult.Rows[0]["GenreID"])
                };
            else
                return null;
        }

        private List<clsAllGame> getGenreGame(int ID)
        {
            Dictionary<string, object> par = new Dictionary<string, object>(1);
            par.Add("ID", ID);
            DataTable lcResult = clsDbConnection.GetDataTable("SELECT * FROM Game WHERE GenreID = @ID", par);
            List<clsAllGame> lcGames = new List<clsAllGame>();
            foreach (DataRow dr in lcResult.Rows)
                lcGames.Add(dataRow2AllGame(dr));
            return lcGames;
        }

        private clsAllGame dataRow2AllGame(DataRow dr)
        {
            return new clsAllGame()
            {
                GameID = Convert.ToInt16(dr["GameID"]),
                GenreID = Convert.ToInt16(dr["GenreID"]),
                Title = Convert.ToString(dr["Title"]),
                Price = Convert.ToDouble(dr["Price"]),
                DateTimeModified = dr["DateTimeModified"] is DBNull ? (string)null : Convert.ToString(dr["DateTimeModified"]),
                Quantity = Convert.ToInt16(dr["Quantity"]),
                ReleaseDate = Convert.ToString(dr["ReleaseDate"]),
                GameType = Convert.ToString(dr["GameType"]),
                Warranty = dr["Warranty"] is DBNull ? (string)null : Convert.ToString(dr["Warranty"]),
                Discount = dr["Discount"] is DBNull ? (double?)null : Convert.ToDouble(dr["Discount"])
            };
        }

        public List<int> GetOrdersList()
        {
            DataTable lcResult = clsDbConnection.GetDataTable("SELECT OrderID FROM [Order]", null);
            List<int> lcOrders = new List<int>();
            foreach (DataRow dr in lcResult.Rows)
                lcOrders.Add((int)dr[0]);
            return lcOrders;
        }

        public clsOrder GetOrderDetails(int ID)
        {
            Dictionary<string, object> par = new Dictionary<string, object>(1);
            par.Add("ID", ID);
            DataTable lcResult = clsDbConnection.GetDataTable("SELECT * FROM [Order] WHERE OrderID = @ID", par);
            if (lcResult.Rows.Count > 0)
                return new clsOrder()
                {
                    OrderID = (int)lcResult.Rows[0]["OrderID"],
                    GameID = (int)lcResult.Rows[0]["GameID"],
                    Quantity = (int)lcResult.Rows[0]["Quantity"],
                    OrderPrice = (double)lcResult.Rows[0]["OrderPrice"],
                    OrderDate = (string)lcResult.Rows[0]["OrderDate"],
                    CustomerName = (string)lcResult.Rows[0]["CustomerName"],
                    City = (string)lcResult.Rows[0]["City"]
                };
            else
                return null;
        }

        public List<double> GetTotalOrdersValue()
        {
            DataTable lcResult = clsDbConnection.GetDataTable("SELECT OrderPrice FROM [Order]", null);
            List<double> lcPrice = new List<double>();
            foreach (DataRow dr in lcResult.Rows)
                lcPrice.Add((double)dr[0]);
            return lcPrice;
        }

        public string PostOrder(clsOrder prOrder)
        { // insert
            try
            {
                int lcRecCount = clsDbConnection.Execute("INSERT INTO [Order] (GameID, Quantity, OrderPrice, OrderDate, CustomerName, City)" +
                    " VALUES (@GameID, @Quantity, @OrderPrice, @OrderDate, @CustomerName, @City)", prepareOrderParameters(prOrder));
                if (lcRecCount == 1)
                    return "New order created";
                else
                    return "Unexpected order creation count: " + lcRecCount;
            }
            catch (Exception ex)
            {
                return ex.GetBaseException().Message;
            }
        }

        public string DeleteOrder(int ID)
        { // Delete
            try
            {
                Dictionary<string, object> par = new Dictionary<string, object>(1);
                par.Add("ID", ID);
                int lcRecCount = clsDbConnection.Execute(
                "DELETE FROM [Order] WHERE OrderID = @ID;", par);
                if (lcRecCount == 1)
                    return "Order Removed";
                else
                    return "Unexpected order removal count: " + lcRecCount;
            }
            catch (Exception ex)
            {
                return ex.GetBaseException().Message;
            }
        }

        public List<string> GetGameTitle(int ID)
        {
            Dictionary<string, object> par = new Dictionary<string, object>(1);
            par.Add("ID", ID);
            DataTable lcResult = clsDbConnection.GetDataTable("SELECT Title FROM Game WHERE GameID = @ID;", par);
            List<string> lcTitle = new List<string>();
            foreach (DataRow dr in lcResult.Rows)
                lcTitle.Add((string)dr[0]);
            return lcTitle;
        }

        public string PostGame(clsAllGame prGame)
        { // insert
            try
            {
                int lcRecCount = clsDbConnection.Execute("INSERT INTO Game " +
                "(GenreID, Title, Price, DateTimeModified, Quantity, ReleaseDate, GameType, Warranty, Discount) " +
                "VALUES (@GenreID, @Title, @Price, @DateTimeModified, @Quantity, @ReleaseDate, @GameType, @Warranty, @Discount)",
                prepareGameParameters(prGame));
                if (lcRecCount == 1)
                    return "New game record created";
                else
                    return "Unexpected game creation count: " + lcRecCount;
            }
            catch (Exception ex)
            {
                return ex.GetBaseException().Message;
            }
        }

        public string PutGame(clsAllGame prGame)
        { // update
            try
            {
                int lcRecCount = clsDbConnection.Execute(
               "UPDATE Game SET GenreID = @GenreID, Title = @Title, Price = @Price, DateTimeModified = @DateTimeModified," +
               "Quantity = @Quantity, ReleaseDate = @ReleaseDate, GameType = @GameType, Warranty = @Warranty," +
               "Discount = @Discount WHERE GameID = @GameID",
               prepareGameParameters(prGame));
                if (lcRecCount == 1)
                    return "Game details updated";
                else
                    return "Unexpected game update count: " + lcRecCount;
            }
            catch (Exception ex)
            {
                return ex.GetBaseException().Message;
            }
        }

        public string DeleteGame(string GameTitle)
        { // Delete
            try
            {
                Dictionary<string, object> par = new Dictionary<string, object>(1);
                par.Add("Title", GameTitle);
                int lcRecCount = clsDbConnection.Execute(
                "DELETE FROM Game WHERE Title = @Title", par);
                if (lcRecCount == 1)
                    return "Record removed";
                else
                    return "Unexpected game removal count: " + lcRecCount;
            }
            catch (Exception ex)
            {
                return ex.GetBaseException().Message;
            }
        }

        private Dictionary<string, object> prepareGameParameters(clsAllGame prGame)
        {
            Dictionary<string, object> par = new Dictionary<string, object>(9);
            par.Add("GameID", prGame.GameID);
            par.Add("GenreID", prGame.GenreID);
            par.Add("Title", prGame.Title);
            par.Add("Price", prGame.Price);
            par.Add("DateTimeModified", prGame.DateTimeModified);
            par.Add("Quantity", prGame.Quantity);
            par.Add("ReleaseDate", prGame.ReleaseDate);
            par.Add("GameType", prGame.GameType);
            par.Add("Warranty", prGame.Warranty);
            par.Add("Discount", prGame.Discount);
            return par;
        }

        private Dictionary<string, object> prepareOrderParameters(clsOrder prOrder)
        {
            Dictionary<string, object> par = new Dictionary<string, object>(5);
            par.Add("GameID", prOrder.GameID);
            par.Add("Quantity", prOrder.Quantity);
            par.Add("OrderPrice", prOrder.OrderPrice);
            par.Add("OrderDate", prOrder.OrderDate);
            par.Add("CustomerName", prOrder.CustomerName);
            par.Add("City", prOrder.City);
            return par;
        }
    }
}
