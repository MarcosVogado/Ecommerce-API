using Ecommerce_API.Dtos;
using Ecommerce_API.models;
using System.Text.Json;
using System.Threading.Tasks;
using Ecommerce_API.Menus;
using System.Security.Cryptography.X509Certificates;

namespace Ecommerce_API
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    string response = await client.GetStringAsync("https://dummyjson.com/products?limit=100");
                    var data = JsonSerializer.Deserialize<ProductsResponse>(response, new JsonSerializerOptions { 
                        PropertyNameCaseInsensitive = true
                    });

                    var products = data?.Products ?? new List<Product>();
                    ShowMenuOptions(products);
                }
                catch (Exception excecao)
                {
                    Console.WriteLine("Ocorreu um erro: " + excecao.Message);
                }
            }
        }
        static void ShowProjectLogo()
        {
            Console.WriteLine(@"                                                                                                                                                                       
██      ▄▄▄    ▄▄ ▄▄ ▄▄  ▄▄ ▄▄ ▄▄  ▄▄▄    ▄▄  ▄▄  ▄▄▄    ▄█████  ▄▄▄  ▄▄  ▄▄  ▄▄▄▄  ▄▄▄  ▄▄    ▄▄▄▄▄ 
██     ██▀██   ██ ██ ███▄██ ██▄██ ██▀██   ███▄██ ██▀██   ██     ██▀██ ███▄██ ███▄▄ ██▀██ ██    ██▄▄  
██████ ▀███▀ ▄▄█▀ ██ ██ ▀██ ██ ██ ██▀██   ██ ▀██ ▀███▀   ▀█████ ▀███▀ ██ ▀██ ▄▄██▀ ▀███▀ ██▄▄▄ ██▄▄▄ 
                                                                                                     ");
            Console.WriteLine("***** Boas vindas a Lojinha no Console! *****");
        }
        static void ShowMenuOptions(List<Product> products)
        {
            ShowProjectLogo();
            Console.WriteLine("\n============== Menu de Opções: ==============\n");
            Console.WriteLine("> Digite 1 para visualizar todos os produtos");
            Console.WriteLine("> Digite 2 para buscar um produto");
            Console.WriteLine("> Digite -1 para sair");
            Console.WriteLine("\n=============================================");

            Console.Write("Selecione uma opção: ");
            string userInput = Console.ReadLine()!;
            int option = int.Parse(userInput);

            switch (option)
            {
                case 1:
                    ViewProductsMenu viewProductsMenu = new ViewProductsMenu();
                    viewProductsMenu.ShowProducts(products);
                    break;
            }
        }
    }
}
