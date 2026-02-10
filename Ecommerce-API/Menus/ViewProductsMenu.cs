using Ecommerce_API.Filters;
using Ecommerce_API.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce_API.Menus
{
    internal class ViewProductsMenu : Menu
    {
        internal void ShowProducts(List<Product> products)
        {
            ShowMenuLogo("Produtos Disponíveis");

            foreach (var product in products)
            {
                FormatProduct(product);
            }

            Console.WriteLine("\nTotal de produtos: " + products.Count);
            Console.WriteLine("=============================================");

            while (true)
            {
                Console.WriteLine("Deseja Ordenar ou Filtrar os produtos? (s/n)");
                string option = (Console.ReadLine() ?? "").Trim().ToLower();

                if (option == "s")
                { 
                    LinqMenu linqMenu = new LinqMenu();
                    linqMenu.ShowLinqMenu(products);
                    break;
                }
                else if (option == "n")
                {
                    Console.WriteLine("\nPressione qualquer tecla para voltar ao menu principal...");
                    Console.ReadKey();
                    Console.Clear();
                    break;
                }
                else
                {
                    Console.WriteLine("Opção inválida. Digite novamente...\n");
                }
            }
        }
    }
}
