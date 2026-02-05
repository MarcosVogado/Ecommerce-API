using Ecommerce_API.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce_API.Menus
{
    internal class SearchProductMenu : Menu
    {
        public void SearchProduct(List<Product> products)
        {
            ShowMenuLogo("Busque por um Produto");
            Console.Write("Digite o termo de busca: ");
            string searchTerm = Console.ReadLine()!.ToLower();
            Console.WriteLine($"\nResultados para '{searchTerm}':\n");

            var mathedProducts = products.Where
            (
                p => p.Title!.ToLower().Contains(searchTerm)
            ).ToList();

            foreach (var product in mathedProducts)
            {
                FormatProduct(product);
            }

            Console.WriteLine("\nPressione qualquer tecla para voltar ao menu principal...");
            Console.ReadKey();
            Console.Clear();
        }
    }
}
