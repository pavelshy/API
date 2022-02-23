using System;

namespace ApiExchangeRates
{

    class Program
    {
        HttpClient client = new HttpClient();


        static async Task Main(string[] args)
        {
            Program program = new Program();
            await program.GetTodoItems();

            Console.ReadKey();
        }

        private async Task GetTodoItems()
        {
            string response = await client.GetStringAsync(
                "https://api.exchangeratesapi.io/v1/");

            Console.WriteLine(response);

        }

    }





}
