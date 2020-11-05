using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using proj.Models;

namespace proj.Repos
{
    public class FootballRepo
    {
        public FootballRepo()
        { }
        private const string _BASAPI = "https://www.thesportsdb.com/api/v1/json/1/searchteams.php?t=";

        public static async Task<List<FootbalClub>> GetRegistrationsAsync(string team)
        {
            using (HttpClient client = GetClient())
            {
                string url = $"{_BASAPI}{team}";
                try
                {
                    string json = await client.GetStringAsync(url);
                    if (json != null)
                    {
                        return JsonConvert.DeserializeObject<List<FootbalClub>>(json);
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

        private static HttpClient GetClient()
        {
            HttpClient httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Add("Accept", "application/json");
            return httpClient;
        }
    }
    }

