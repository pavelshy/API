using System;
using System.Text.Json;

namespace ApiExchangeRates
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var client = new HttpClient())
            {
                var endpoint = new Uri("http://api.exchangeratesapi.io/v1/latest?access_key=0f10eb34fd242a0c0e0025707136b73d&symbols=USD,PLN&format=1");
                var result = client.GetAsync(endpoint).Result;
                var json = result.Content.ReadAsStringAsync().Result;
                var jsonDeserialize = JsonSerializer.Deserialize<Exchange>(json);

                File.WriteAllText("ExchangeRates.json",json);
                

            }
        }
    }
    
    public class Exchange
    {
        public bool success { get; set; }
        public int timestamp { get; set; }
        public string @base { get; set; }
        public string date { get; set; }
        public Rates rates { get; set; }

        public class Rates
        {
            public double USD { get; set; }
            public double PLN { get; set; }
        }
    }
}
