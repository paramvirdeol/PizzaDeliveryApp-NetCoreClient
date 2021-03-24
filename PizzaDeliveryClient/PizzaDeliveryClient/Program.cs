using PizzaServices;
using System;
using System.Threading.Tasks;

namespace PizzaDeliveryClient
{
    class Program
    {
        static async Task Main(string[] args)
        {
            int val = 0;
            bool flag = false;

            do
            {
                Console.WriteLine("Choose one of the following actions:");
                Console.WriteLine("1. Display a list of products.");
                Console.WriteLine("2. Display a list of customers.");
                Console.WriteLine("3. Exit menu.");

                var input = Console.ReadLine();

                if (int.TryParse(input, out val))
                {
                    switch (val)
                    {
                        case 1:
                            await DisplayProducts();
                            break;
                        case 2:
                            await DisplayCustomers();
                            break;
                        default:
                            flag = true;
                            return;
                    }
                }

            } while (!flag );            

        }
        

        private static async Task DisplayCustomers()
        {
            var client = new PizzaServiceClient(PizzaServiceClient.EndpointConfiguration.NetTcpBinding_IPizzaService);
            var result = await client.GetCustomersAsync();
            foreach (var item in result)
            {
                Console.WriteLine(item.FullName);
            }
            await client.CloseAsync();
        }

        private static async Task DisplayProducts()
        {
            var client = new PizzaServiceClient(PizzaServiceClient.EndpointConfiguration.BasicHttpBinding_IPizzaService);
            var result = await client.GetProductsAsync();
            foreach (var item in result)
            {
                Console.WriteLine(item.Name);
            }
            await client.CloseAsync();
        }
    }
}
