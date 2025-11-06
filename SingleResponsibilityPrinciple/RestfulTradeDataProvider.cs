using SingleResponsibilityPrinciple.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace SingleResponsibilityPrinciple
{
    public class RestfulTradeDataProvider : ITradeDataProvider
    {
        string url;
        ILogger logger;
        public RestfulTradeDataProvider(string url, ILogger logger)
        {
            this.url = url;
            this.logger = logger;
        }

        public IEnumerable<string> GetTradeData()
        {
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    // Perform the HTTP GET request synchronously
                    HttpResponseMessage response = client.GetAsync(url).Result;
                    response.EnsureSuccessStatusCode();

                    // Read the response body as a string
                    string json = response.Content.ReadAsStringAsync().Result;

                    // Deserialize the JSON array into a list of strings
                    List<string>? tradeData = JsonSerializer.Deserialize<List<string>>(json);

                    return tradeData ?? new List<string>();
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error reading trade data: {ex.Message}");
                    return new List<string>();
                }
            }
        }
    }
}
