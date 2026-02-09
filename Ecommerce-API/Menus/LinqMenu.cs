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
        public void ShowLinqMenu()
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
                    string category = Console.ReadLine() ?? "";
                    // Aqui você pode implementar a lógica para filtrar os produtos por categoria usando LINQ
                    Console.WriteLine($"Filtrando produtos pela categoria: {category}");
                    break;
                case 2:

                    break;
            }
        }
    }
}
