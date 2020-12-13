using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using proj.Models;

namespace proj.Repos
{
    public class FootballRepo
    {
        public FootballRepo()
        { }
        //sportsdb
        private const string _BASAPI = "https://www.thesportsdb.com/api/v1/json/1/searchteams.php?t=";

        //trello
        private const string _APIKEY = "b5128c8a3d416d0183221889892b6d2b";
        private const string _USERTOKEN = "5655cf5dd64410ec8f392ade7055f9bc0c6bca47b4dd467363bf55be8c465547";
        private const string _BASEURI = "https://api.trello.com/1";


        private static HttpClient GetHttpClient()
        {


            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Add("accept", "application/json");
            return client;
            //curl 'https://api.trello.com/1/members/me/boards?key={yourKey}&token={yourToken}'

        }

        public static async Task<List<FootbalClub>> GetTeam(string team)
        {
            using (HttpClient client = GetClient())
            {
                string url = $"{_BASAPI}{team}";
                try
                {
                    string json = await client.GetStringAsync(url);
                    if (json != null)
                    {
                        //object deserializeren naar JObject (< newtonsoft)
                        JObject fullObject = JsonConvert.DeserializeObject<JObject>(json);

                        //enkel gewenst pad opvragen
                        JToken data = fullObject.SelectToken("teams");

                        //deze token deserializeren naar gewenst object type
                        return data.ToObject <List<FootbalClub>> ();
                        
                    }
                    else
                    {
                        return null;
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            //return new List<Registration>();
        }

        public static async Task<List<Existingteam>> GetExistingteam(string team)
        {
            using (HttpClient client = GetClient())
            {
                string url = $"{_BASAPI}{team}";
                try
                {
                    string json = await client.GetStringAsync(url);
                    if (json != null)
                    {
                        //object deserializeren naar JObject (< newtonsoft)
                        JObject fullObject = JsonConvert.DeserializeObject<JObject>(json);

                        //enkel gewenst pad opvragen
                        JToken data = fullObject.SelectToken("teams");

                        //deze token deserializeren naar gewenst object type
                        return data.ToObject<List<Existingteam>>();

                    }
                    else
                    {
                        return null;
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            //return new List<Registration>();
        }
        public static async Task<List<Events>> GetEvents(string team)
        {
            using (HttpClient client = GetClient())
            {
                string url = $"https://www.thesportsdb.com/api/v1/json/1/eventsnext.php?id={team}";
                try
                {
                    string json = await client.GetStringAsync(url);
                    if (json != null)
                    {
                        //object deserializeren naar JObject (< newtonsoft)
                        JObject fullObject = JsonConvert.DeserializeObject<JObject>(json);

                        //enkel gewenst pad opvragen
                        JToken data = fullObject.SelectToken("events");

                        //deze token deserializeren naar gewenst object type
                        return data.ToObject<List<Events>>();

                    }
                    else
                    {
                        return null;
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            //return new List<Registration>();
        }

        public static async Task AddBetting(string listid, Trellocard card)
        {
            string url = $"{_BASEURI}/cards?idList={listid}&key={_APIKEY}&token={_USERTOKEN}";

            using (HttpClient client = GetHttpClient())
            {
                try
                {
                    string json = JsonConvert.SerializeObject(card);
                    StringContent content = new StringContent(json, Encoding.UTF8, "application/json");
                    var response = await client.PostAsync(url, content);
                    if (!response.IsSuccessStatusCode)
                    {
                        string errormsg = $"Unsucessfull POST to url {url} , object:{json}";
                        throw new Exception(errormsg); // Springt automatisch naar de catch function

                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }


            }
        }

        private static HttpClient GetClient()
        {
            HttpClient httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Add("Accept", "application/json");
            return httpClient;
        }
    }
    }

