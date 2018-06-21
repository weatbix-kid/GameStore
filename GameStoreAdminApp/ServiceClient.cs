using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace GameStoreAdminApp
{
    public static class ServiceClient
    {
        internal async static Task<List<string>> GetGenreNamesAsync()
        {
            using (HttpClient lcHttpClient = new HttpClient())
                return JsonConvert.DeserializeObject<List<string>>
                (await lcHttpClient.GetStringAsync("http://localhost:60064/api/gamestore/GetGenreNames/"));
        }

        internal async static Task<clsGenre> GetGenreAsync(string prGenreName)
        {
            using (HttpClient lcHttpClient = new HttpClient())
                return JsonConvert.DeserializeObject<clsGenre>
                (await lcHttpClient.GetStringAsync
               ("http://localhost:60064/api/gamestore/GetGenre?Name=" + prGenreName));
        }

        internal async static Task<List<int>> GetOrdersListAsync()
        {
            using (HttpClient lcHttpClient = new HttpClient())
                return JsonConvert.DeserializeObject<List<int>>
                (await lcHttpClient.GetStringAsync("http://localhost:60064/api/gamestore/GetOrdersList/"));
        }

        internal async static Task<clsOrder> GetOrderDetailsAsync(int prID)
        {
            using (HttpClient lcHttpClient = new HttpClient())
                return JsonConvert.DeserializeObject<clsOrder>
                (await lcHttpClient.GetStringAsync
               ("http://localhost:60064/api/gamestore/GetOrderDetails?ID=" + prID));
        }

        internal async static Task<List<double>> GetTotalOrdersValueAsync()
        {
            using (HttpClient lcHttpClient = new HttpClient())
                return JsonConvert.DeserializeObject<List<double>>
                (await lcHttpClient.GetStringAsync("http://localhost:60064/api/gamestore/GetTotalOrdersValue/"));
        }

        internal async static Task<List<string>> GetGameTitleAsync(int prID)
        {
            using (HttpClient lcHttpClient = new HttpClient())
                return JsonConvert.DeserializeObject<List<string>>
                (await lcHttpClient.GetStringAsync("http://localhost:60064/api/gamestore/GetGameTitle?ID=" + prID));
        }

        internal async static Task<string> PostOrderAsync(clsOrder prOrder)
        {
            return await InsertOrUpdateAsync(prOrder, "http://localhost:60064/api/gamestore/PostOrder", "POST");
        }

        internal async static Task<string> DeleteOrderAsync(int prID)
        {
            using (HttpClient lcHttpClient = new HttpClient())
            {
                HttpResponseMessage lcRespMessage = await lcHttpClient.DeleteAsync
                ($"http://localhost:60064/api/gamestore/DeleteOrder?ID={prID}");
                return await lcRespMessage.Content.ReadAsStringAsync();
            }
        }

        internal async static Task<List<clsAllGame>> GetGamesFrom(int prID)
        {
            using (HttpClient lcHttpClient = new HttpClient())
                return JsonConvert.DeserializeObject<List<clsAllGame>>
                (await lcHttpClient.GetStringAsync("http://localhost:60064/api/gamestore/GetGamesFrom?ID=" + prID));
        }

        internal async static Task<List<clsAllGame>> GetGenreGameAsync(int prID)
        {
            using (HttpClient lcHttpClient = new HttpClient())
                return JsonConvert.DeserializeObject<List<clsAllGame>>
                (await lcHttpClient.GetStringAsync("http://localhost:60064/api/gamestore/GetGenreGame?ID=" + prID));
        }

        internal async static Task<string> UpdateGameAsync(clsAllGame prGame)
        {
            return await InsertOrUpdateAsync(prGame, "http://localhost:60064/api/gamestore/PutGame", "PUT");
        }

        internal async static Task<string> PostGameAsync(clsAllGame prGame)
        {
            return await InsertOrUpdateAsync(prGame, "http://localhost:60064/api/gamestore/PostGame", "POST");
        }

        internal async static Task<string> DeleteGameAsync(clsAllGame prGame)
        {
            using (HttpClient lcHttpClient = new HttpClient())
            {
                HttpResponseMessage lcRespMessage = await lcHttpClient.DeleteAsync
                ($"http://localhost:60064/api/gamestore/DeleteGame?GameTitle={prGame.Title}");
                return await lcRespMessage.Content.ReadAsStringAsync();
            }
        }

        private async static Task<string> InsertOrUpdateAsync<TItem>(TItem prItem, string prUrl, string prRequest)
        {
            using (HttpRequestMessage lcReqMessage = new HttpRequestMessage(new HttpMethod(prRequest), prUrl))
            using (lcReqMessage.Content =
           new StringContent(JsonConvert.SerializeObject(prItem), Encoding.Default, "application/json"))
            using (HttpClient lcHttpClient = new HttpClient())
            {
                HttpResponseMessage lcRespMessage = await lcHttpClient.SendAsync(lcReqMessage);
                return await lcRespMessage.Content.ReadAsStringAsync();
            }
        }
    }
}
