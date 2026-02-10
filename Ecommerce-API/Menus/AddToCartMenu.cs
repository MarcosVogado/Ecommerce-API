using Ecommerce_API.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce_API.Menus
{
    internal class AddToCartMenu : Menu
    {
        internal void AddProductToCart(List<Product> products, Cart cart)
        {
            while (true)
            {
                ShowMenuLogo("Adicionar ao carrinho");
                Console.WriteLine("\nDigite o ID do produto que deseja adicionar ao carrinho: ");
                string userInput = (Console.ReadLine() ?? "").Trim();

                if (!int.TryParse(userInput, out int productId))
                {
                    Console.WriteLine("ID inválido.");
                    return;
                }

                Product? selectedProduct = products.FirstOrDefault(p => p.Id == productId);

                if (selectedProduct is null)
                {
                    Console.WriteLine("Produto não encontrado.");
                    return;
                }

                cart.AddProduct(selectedProduct);

                Console.WriteLine($"\nProduto '{selectedProduct?.Title}' adicionado ao carrinho com sucesso!");
                
                Console.WriteLine("\nDeseja adicionar outro produto? (s/n)");
                var option = (Console.ReadLine() ?? "").Trim().ToLower();

                if (option == "s")
                {
                    Console.Clear();
                    continue;
                }

                if (option == "n")
                {
                    break;
                }
            }
            
            Console.WriteLine("\nPressione qualquer tecla para voltar ao menu principal...");
            Console.ReadKey();
            Console.Clear();
        }
    }
}
