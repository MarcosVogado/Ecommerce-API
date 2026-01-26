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
            ShowMenuLogo("Busque por um produto");

        }
    }
}
