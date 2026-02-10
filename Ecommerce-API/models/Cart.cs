using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce_API.models
{
    internal class Cart
    {
        public List<Product> ProductsInCart { get; set; } = new List<Product>();
    
            public decimal TotalPrice
            {
                get
                {
                    return ProductsInCart.Sum(p => p.Price ?? 0);
                }
            }
    
            public void AddProduct(Product product)
            {
                ProductsInCart.Add(product);
            }
    
            public void RemoveProduct(Product product)
            {
                ProductsInCart.Remove(product);
            }
    
            public void ClearCart()
            {
                ProductsInCart.Clear();
        }
    }
}
