using Ecommerce_API.Dtos;
using Ecommerce_API.models;
using System.Text.Json;
using System.Threading.Tasks;

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

                    Console.WriteLine("Lista de Produtos:");
                    foreach (var product in products)
                    {
                        Console.WriteLine($"ID: {product.Id}, Nome: {product.Title}, Preço: {product.Price}");
                    }

                }
                catch (Exception excecao)
                {
                    Console.WriteLine("Ocorreu um erro: " + excecao.Message);
                }
            }
        }
    }
}
