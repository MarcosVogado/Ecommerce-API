using Ecommerce_API.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce_API.Menus
{
    internal class PaymentMenu : Menu
    {
        internal void PayCart(Cart cart)
        {
            ShowMenuLogo("Pagamento do Carrinho");
            if (cart.ProductsInCart.Count == 0)
            {
                Console.Clear();
                Console.WriteLine("Seu carrinho está vazio. Adicione produtos antes de pagar.");

                Console.WriteLine("\nPressione qualquer tecla para voltar ao menu principal...");
                Console.ReadKey();
                Console.Clear();
            }
            else
            {
                Console.WriteLine($"Total a pagar: $ {cart.TotalPrice}\n");
                Console.WriteLine("> Itens a pagar: \n");

                foreach (var products in cart.ProductsInCart) 
                {
                    FormatProduct(products);
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
