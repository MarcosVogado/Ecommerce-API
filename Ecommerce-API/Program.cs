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

                    Cart cart = new Cart();
                    ShowMenuOptions(products, cart);
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
        public static void ShowMenuOptions(List<Product> products, Cart cart)
        {
            ShowProjectLogo();
            Console.WriteLine("\n============== Menu de Opções: ==============\n");
            Console.WriteLine("> Digite 1 para visualizar todos os produtos");
            Console.WriteLine("> Digite 2 para buscar um produto");
            Console.WriteLine("> Digite 3 para adicionar um produto ao carrinho");
            Console.WriteLine("> Digite 4 para remover um produto do carrinho");
            Console.WriteLine("> Digite 5 para pagar");
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
                    ShowMenuOptions(products, cart);
                    break;
                case 2:
                    SearchProductMenu searchProductMenu = new SearchProductMenu();
                    searchProductMenu.SearchProduct(products);
                    ShowMenuOptions(products, cart);
                    break;
                case 3:
                    AddToCartMenu addToCartMenu = new AddToCartMenu();
                    addToCartMenu.AddProductToCart(products, cart);
                    ShowMenuOptions(products, cart);
                    break;
                case 4:
                    RemoveToCartMenu removeToCartMenu = new RemoveToCartMenu();
                    removeToCartMenu.RemoveProductToCart(cart);
                    ShowMenuOptions(products, cart);
                    break;
                case 5:
                    PaymentMenu paymentMenu = new PaymentMenu();
                    paymentMenu.PayCart(cart);
                    ShowMenuOptions(products, cart);
                    break;
                case -1:
                    Console.WriteLine("\n=> Obrigado por usar a Lojinha no Console! Até a próxima.");
                    Thread.Sleep(2000);
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Opção inválida. Tente novamente.");
                    Thread.Sleep(2000);
                    Console.Clear();
                    ShowMenuOptions(products, cart);
                    break;
            }
        }
    }
}
