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
        public void ShowProducts(List<Product> products)
        {
            Console.Clear();
            ShowMenuLogo("Produtos Disponíveis");

            foreach (var product in products)
            {
                Console.WriteLine($"ID: {product.Id}, Nome: {product.Title}, Preço: {product.Price}");
            }
        }
    }
}
