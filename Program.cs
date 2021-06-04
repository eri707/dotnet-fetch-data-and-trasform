using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace dotnet_fetch_data_and_transform
{
    class Program
    {
        static async Task Main(string[] args)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://restcountries.eu");
                var response = await client.GetAsync("rest/v2/all?fields=name;capital;currencies;region;population");
                // Gets a value that indicates if the HTTP response was successful
                if (!response.IsSuccessStatusCode)
                {
                    Console.WriteLine("There was an error fetching data.");
                    return;
                }// This is the json string from api
                var content = await response.Content.ReadAsStringAsync();
                // Transform json string into list of class
                //Console.WriteLine(content);
                var countryList = JsonSerializer.Deserialize<List<Country>>(content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                var map = countryList.Select(i => new CountryMap
                {
                    Name = i.Name,
                    CapitalCity = i.Capital,
                    Population = i.Population,
                    Region = i.Region,
                    // Use Selecet to get only "Code"
                    Currencies = i.Currencies.Select(j => j.Code)
                });
                var serialize = JsonSerializer.Serialize(map, new JsonSerializerOptions{ WriteIndented = true });
                Console.WriteLine(serialize);
            }
        }
    }
}
