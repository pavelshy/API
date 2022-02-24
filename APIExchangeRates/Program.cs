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
                Console.WriteLine(json);
                Exchange? exchange = JsonSerializer.Deserialize<Exchange>(json);
                Console.WriteLine(exchange?.success);
                Console.WriteLine(exchange?.timestamp);
                Console.WriteLine(exchange?.date);
                Console.WriteLine(exchange?.rates);
                Console.WriteLine(exchange?.USD);
                Console.WriteLine(exchange?.PLN);


                Console.ReadKey();
                
            }

        }

    }
    class Exchange
    {
        public object success { get; set; }
        public object timestamp { get; set; }
        public object date { get; set; }
        public object rates { get; set; }
        public object USD { get; set; }
        public object PLN { get; set; }



    }
}
