using Ecommerce_API.models;
using OpenAI_API;
using System.Globalization;
using System.Text;
using System.Text.Json;

namespace Ecommerce_API.Menus
{
    internal class PaymentMenu : Menu
    {
        private static string NormalizeTitle(string? s)
        {
            if (string.IsNullOrWhiteSpace(s)) return "";

            s = s.Trim().ToLowerInvariant();

            var normalized = s.Normalize(NormalizationForm.FormD);
            var sb = new StringBuilder();
            foreach (var c in normalized)
                if (CharUnicodeInfo.GetUnicodeCategory(c) != UnicodeCategory.NonSpacingMark)
                    sb.Append(c);

            s = sb.ToString().Normalize(NormalizationForm.FormC);

            sb.Clear();
            foreach (var c in s)
                sb.Append(char.IsLetterOrDigit(c) || char.IsWhiteSpace(c) ? c : ' ');

            return string.Join(' ', sb.ToString().Split(' ', StringSplitOptions.RemoveEmptyEntries));
        }
        private static bool IsInCart(Product p, Cart cart)
        {
            if (p.Id.HasValue)
                return cart.ProductsInCart.Any(c => c.Id == p.Id.Value);

            var pTitle = NormalizeTitle(p.Title);
            return cart.ProductsInCart.Any(c => NormalizeTitle(c.Title) == pTitle);
        }
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
                    Console.WriteLine("\nCom base na sua compra, aqui estão algumas recomendações para você:\n");
                    Console.WriteLine("Mais produtos relacionados para você:");

                    var normalizedKeywords = recommendedProducts
                        .Where(r => !string.IsNullOrWhiteSpace(r))
                        .Select(NormalizeTitle)
                        .Distinct()
                        .ToList();

                    var matchedProducts = products
                        .Where(p => !IsInCart(p, cart))
                        .Where(p =>
                        {
                            var title = NormalizeTitle(p.Title);
                            return normalizedKeywords.Any(k => title.Contains(k));
                        })
                        
                        .GroupBy(p => NormalizeTitle(p.Title))
                        .Select(g => g.First())
                        .Take(3)
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
