using Ecommerce_API.Menus;
using Ecommerce_API.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce_API.Filters
{
    internal class LinqFilter
    {
        internal static void filterProductsByCategory(List<Product> products, string category)
        {
            var filteredProducts = products.Where
            (
                p => p.Category!.Contains(category)
            ).ToList();

            Console.WriteLine("\nProdutos filtrados por categoria: " + category);

            if (filteredProducts.Count == 0)
            {
                Console.WriteLine("Nenhum produto encontrado para essa categoria.");
            }

            foreach ( var product in filteredProducts )
            {
                Menu.FormatProduct(product);
            }

            Console.WriteLine("\nPressione qualquer tecla para voltar...");
            Console.ReadKey();
            Console.Clear();
        }
    }
}
