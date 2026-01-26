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
        public static void FormatProduct(Product product)
        {
            int length = product.Title.Length;
            string border = string.Empty.PadLeft(length + 10, '-');
            Console.WriteLine(border);
            Console.WriteLine($"ID: {product.Id}");
            Console.WriteLine($"Título: {product.Title}");
            Console.WriteLine($"Preço: ${product.Price}");
            Console.WriteLine(border);
        }
        public void ShowProducts(List<Product> products)
        {
            Console.Clear();
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
