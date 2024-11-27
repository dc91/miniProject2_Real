using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace miniProject2_Real
{
    internal class ProductList
    {
        private List<ListItem> items = [];

        public string CheckString(bool expectInt = false)
        {
            while (true)
            {
                string input = Console.ReadLine().Trim();
                if (String.IsNullOrWhiteSpace(input))
                    Console.WriteLine("The input was empty, try again.");
                else if (input.ToLower() == "q")
                    return "q";
                else if (expectInt)
                {
                    if (int.TryParse(input, out int number))
                        return number.ToString();
                    else
                        Console.WriteLine("The input was not an integer, try again.");
                }
                else
                    return input;
            }
        }

        public void AddProduct()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("To enter a new product - follow the steps | To quit - enter: \"q\"");
            Console.ResetColor();
            string input;
            string category;
            string name;
            int price;

            while (true)
            {
                Console.Write("Enter a Category: ");
                category = CheckString();
                if (category == "q") break;

                Console.Write("Enter a Product Name: ");
                name = CheckString();
                if (name == "q") break;

                Console.Write("Enter a Price: ");
                input = CheckString(true);
                if (input == "q") break;
                price = Convert.ToInt32(input);

                items.Add(new ListItem
                {
                    Category = category,
                    Name = name,
                    Price = price
                });
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("The product was successfully added!");
                Console.ResetColor();
                Console.WriteLine("".PadRight(50, '-'));
            }
            PrintList();
        }

        public void PrintList(string n = "")
        {
            if (items.Count != 0)
            {
                Console.WriteLine("".PadRight(50,'-'));
                Console.WriteLine("Category".PadRight(20) + "Product".PadRight(20) + "Price");
                foreach (var i in items.OrderBy(x => x.Price))
                {
                    if (n.Equals(i.Name))
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                    }
                    Console.WriteLine(
                        i.Category.PadRight(20) +
                        i.Name.PadRight(20) +
                        i.Price.ToString());
                    Console.ResetColor();
                }

                if (n.Equals(""))
                {
                    Console.WriteLine();
                    Console.WriteLine("".PadRight(20) + "Total amount:".PadRight(20) + items.Sum(x => x.Price));
                }
                Console.WriteLine("".PadRight(50, '-'));
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("The list is empty.");
                Console.ResetColor();
                Console.WriteLine("".PadRight(50, '-'));
            }
            
        }

        public void SearchProduct()
        {
            if (items.Count != 0)
            {
                while (true)
                {
                    Console.WriteLine("Enter Product Name: ");
                    string input = Console.ReadLine().Trim().ToLower();

                    if (String.IsNullOrWhiteSpace(input))
                    {
                        Console.WriteLine("Input was empty, try again.");
                        continue;
                    }

                    var foundProducts = items.FindAll(x => x.Name
                        .Trim().ToLower().Equals(input, StringComparison.OrdinalIgnoreCase));

                    if (foundProducts.Count == 0)
                    {
                        Console.WriteLine("Could not find the product. Do you want to try again? (y/n)");
                        string retry = Console.ReadLine().Trim().ToLower();

                        if (retry == "n")
                        {
                            PrintList();
                            break;
                        }
                        else if (retry != "y")
                        {
                            Console.WriteLine("Invalid input, try again");
                        }
                    }
                    else
                    {
                        PrintList(foundProducts[0].Name);
                        break;
                    }
                }
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("The list is empty. Nothing to search...");
                Console.ResetColor();
                Console.WriteLine("".PadRight(50, '-'));
            }
            
        }

    }
}
