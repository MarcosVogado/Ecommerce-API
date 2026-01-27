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

            Console.WriteLine("\nPressione qualquer tecla para voltar ao menu principal...");
            Console.ReadKey();
            Console.Clear();
        }
    }
}
