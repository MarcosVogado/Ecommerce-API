using Ecommerce_API.Menus;
using Ecommerce_API.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce_API.Filters
{
    internal class LinqOrder
    {
        internal static void OrderProductsByPrice(List<Product> products)
        {
            var orderedProducts = products.OrderBy(p => p.Price).ToList();

            foreach (var producy in orderedProducts)
            {
                Menu.FormatProduct(producy);
            }

            Console.WriteLine("\nPressione qualquer tecla para voltar...");
            Console.ReadKey();
            Console.Clear();
        }

        internal static void OrderProductsByPriceDescending(List<Product> products)
        {
            var orderedProducts = products.OrderByDescending(p => p.Price).ToList();

            foreach (var producy in orderedProducts)
            {
                Menu.FormatProduct(producy);
            }

            Console.WriteLine("\nPressione qualquer tecla para voltar...");
            Console.ReadKey();
            Console.Clear();
        }
    }
}
