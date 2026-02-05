using Ecommerce_API.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce_API.Menus
{
    internal class Menu
    {
        public static void ShowMenuLogo(string title)
        {
            Console.Clear();
            int length = title.Length;
            string border = string.Empty.PadLeft(length + 6, '=');
            Console.WriteLine(border);
            Console.WriteLine($"   {title}   ");
            Console.WriteLine($"{border}\n");
        }

        internal void FormatProduct(Product product)
        {
            int length = product.Title.Length;
            string border = string.Empty.PadLeft(length + 10, '-');
            Console.WriteLine(border);
            Console.WriteLine($"ID: {product.Id}");
            Console.WriteLine($"Título: {product.Title}");
            Console.WriteLine($"Preço: $ {product.Price}");
            Console.WriteLine(border);
        }
    }
}
