using Ecommerce_API.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce_API.Menus
{
    internal class RemoveToCartMenu : Menu
    {
        internal void RemoveProductToCart(Cart cart)
        {
            while (true)
            {
                ShowMenuLogo("Remover Produtos do carrinho");

                if(cart.ProductsInCart.Count == 0)
                {
                    Console.WriteLine("Ainda não há produtos no seu carrinho. Adicione produtos antes de tentar remover.");
                    break;
                }

                Console.WriteLine("> Itens no carrinho: \n");

                foreach (var products in cart.ProductsInCart)
                {
                    FormatProduct(products);
                }

                Console.WriteLine("\nDigite o ID do produto que deseja remover do carrinho: ");
                string userInput = (Console.ReadLine() ?? "").Trim();

                if (!int.TryParse(userInput, out int productId))
                {
                    Console.WriteLine("ID inválido.");
                    return;
                }

                Product? selectedProduct = cart.ProductsInCart.FirstOrDefault(p => p.Id == productId);

                if (selectedProduct is null)
                {
                    Console.WriteLine("Produto não encontrado.");
                    return;
                }

                cart.RemoveProduct(selectedProduct);

                Console.WriteLine($"\nO Produto '{selectedProduct?.Title}' foi removido do carrinho.");

                Console.WriteLine("\nDeseja remover outro produto? (s/n)");
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
