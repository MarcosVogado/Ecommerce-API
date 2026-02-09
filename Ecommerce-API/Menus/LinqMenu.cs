using Ecommerce_API.Filters;
using Ecommerce_API.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce_API.Menus
{
    internal class LinqMenu : Menu
    {
        public void ShowLinqMenu(List<Product> products)
        {
            ShowMenuLogo("Filtros e Ordenações");
            Console.WriteLine("\n============== Menu de filtros e ordenações: ==============\n");
            Console.WriteLine("> Digite 1 para filtrar os produtos por categoria");
            Console.WriteLine("> Digite 2 para ordenar os produtos em ordem crescente/preço");
            Console.WriteLine("> Digite -1 para sair");
            Console.WriteLine("\n=============================================");
            string userInput = (Console.ReadLine() ?? "").Trim().ToLower();
            int option = int.Parse(userInput);

            switch (option)
            {
                case 1: 
                    Console.Write("Digite a categoria para filtrar: ");
                    string category = (Console.ReadLine() ?? "").Trim().ToLower();
                    LinqFilter.filterProductsByCategory(products, category);
                    Console.Clear();
                    ShowLinqMenu(products);
                    break;
                case 2:

                    break;
                case -1:
                    Console.WriteLine("\nPressione qualquer tecla para voltar ao menu principal...");
                    Console.ReadKey();
                    Console.Clear();
                    break;
                default:
                    Console.WriteLine("Opção inválida. Por favor, tente novamente.");
                    Thread.Sleep(2000);
                    ShowLinqMenu(products);
                    break;
            }
        }
    }
}
