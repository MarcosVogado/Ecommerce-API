using Ecommerce_API.models;
using OpenAI_API;
using System.Text.Json;

namespace Ecommerce_API.Menus
{
    internal class PaymentMenu : Menu
    {
        internal void PayCart(List<Product> products, Cart cart)
        {
            ShowMenuLogo("Pagamento do Carrinho");
            if (cart.ProductsInCart.Count == 0)
            {
                Console.Clear();
                Console.WriteLine("Seu carrinho está vazio. Adicione produtos antes de pagar.");

                Console.WriteLine("\nPressione qualquer tecla para voltar ao menu principal...");
                Console.ReadKey();
                Console.Clear();
                return;
            }
            else
            {

                Console.WriteLine($"Total a pagar: $ {cart.TotalPrice}\n");
                Console.WriteLine("> Itens a pagar: \n");

                foreach (var pInCart in cart.ProductsInCart)
                {
                    FormatProduct(pInCart);
                }

                var client = new OpenAIAPI
                (
                    Environment.GetEnvironmentVariable("OPENAI_API_KEY")
                );

                var chat = client.Chat.CreateConversation();

                chat.AppendSystemMessage
                (
                    "You are a helpful assistant. Return ONLY valid JSON. " +
                    "Return a JSON array at the root with 3 related product keywords in English. Example: [\"Gucci\",\"Chanel\",\"Parfum\"]"
                );

                var titles = string.Join(", ", cart.ProductsInCart.Select(x => x.Title));
                chat.AppendUserInput($"Bought products: {titles}. Suggest 3 related keywords.");

                string response = chat.GetResponseFromChatbotAsync().GetAwaiter().GetResult();

                List<string>? recommendedProducts = null;
                try
                {
                    recommendedProducts = JsonSerializer.Deserialize<List<string>>(response);
                }
                catch
                {
                    Console.WriteLine("Não consegui interpretar a recomendação (JSON inválido).");
                }

                if (recommendedProducts is not null && recommendedProducts.Count > 0)
                {
                    Console.WriteLine("Mais produtos relacionados para você:");

                    var matchedProducts = products
                        .Where(p => recommendedProducts.Any(r =>
                            (p.Title ?? "").Contains(r, StringComparison.OrdinalIgnoreCase)))
                        .ToList();

                    foreach (var product in matchedProducts)
                        FormatProduct(product);
                }

                Console.WriteLine("\nDeseja editar seu carrinho antes de prosseguir para o pagamento? (s/n)");
                var option = (Console.ReadLine() ?? "").Trim().ToLower();

                if (option == "s")
                {
                    Console.Clear();
                }

                if (option == "n")
                {
                    Console.WriteLine("Processando pagamento...");
                    Task.Delay(5000).Wait();
                    Console.WriteLine("\nPagamento realizado com sucesso! Obrigado pela sua compra.");
                    cart.ClearCart();
                    Console.WriteLine("\nPressione qualquer tecla para voltar ao menu principal...");
                    Console.ReadKey();
                    Console.Clear();
                }
            }
        }
    }
}
