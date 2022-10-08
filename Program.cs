using System;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace WebAPIClient
{
    class GoT
    {
        [JsonProperty("name")]
        public string name { get; set; }

        [JsonProperty("gender")]
        public string gender { get; set; }

        [JsonProperty("culture")]
        public string culture { get; set; }

        [JsonProperty("father")]
        public string father { get; set; }

        [JsonProperty("mother")]
        public string mother { get; set; }
    }


    //public class Type
    //{
    //    [JsonProperty("name")]
    //    public string name { get; set; }
    //}


    //public class Types
    //{
    //    [JsonProperty("type")]
    //    public Type Type;
    //}


    class Program
    {
        //static allows u to use className.method() to call function, no need to create and object of it
        private static readonly HttpClient client = new HttpClient();

        static async Task Main(string[] args)
        {
            await ProcessRepositories();
        } 

        private static async Task ProcessRepositories()
        {
            while (true)
            {
                try
                {
                    Console.WriteLine("Enter Game of Thrones id. Press Enter without writing to quit the program.");
                    var user_GOTid = Console.ReadLine();

                    if (user_GOTid == null || user_GOTid == "")
                    {
                        break;
                    }

                    var result = await client.GetAsync("https://anapioficeandfire.com/api/characters/" + user_GOTid);
                    var resultRead = await result.Content.ReadAsStringAsync();

                    var GOTchar = JsonConvert.DeserializeObject<GoT>(resultRead);

                    Console.WriteLine("---");
                    Console.WriteLine("Name: " + GOTchar.name);
                    Console.WriteLine("Gender: " + GOTchar.gender);
                    Console.WriteLine("Culture: " + GOTchar.culture);
                    Console.WriteLine("Father: " + GOTchar.father);
                    Console.WriteLine("Mother: " + GOTchar.mother);
                    Console.WriteLine("---");
                }
                catch (Exception)
                {
                    Console.WriteLine("ERROR. Please enter a valid id!");
                }
            }
        }
    }
}
