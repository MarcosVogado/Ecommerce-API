using Ecommerce_API.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Ecommerce_API.Dtos
{
    internal class ProductsResponse
    {
        [JsonPropertyName("products")]
        public List<Product>? Products { get; set; } = new();
    }
}
