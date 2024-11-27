using System.Diagnostics.Metrics;
using System.Xml.Linq;
using miniProject2_Real;

ProductList finalList = new ProductList();

finalList.AddProduct();//Start by adding new products. So we dont have an empty list.

bool stay = true;
while (stay)// Main loop. We land here after quitting the first time. Methods in class file.
{
    Console.ForegroundColor = ConsoleColor.Blue;
    Console.WriteLine(
    "To enter a new product - enter \"p\" | " +
    "To search for a product - enter: \"s\" | " +
    "To quit - enter: \"q\""
    );
    Console.ResetColor();

    string input = Console.ReadLine().Trim().ToLower();

    switch (input)
    {
        case "p":
            finalList.AddProduct();
            continue;
        case "s":
            finalList.SearchProduct();
            break;
        case "q":
            finalList.PrintList();
            stay = false;
            break;
        default:
            Console.WriteLine("Invalid input, try again");
            break;
    }
}

Console.ForegroundColor = ConsoleColor.Blue;
Console.WriteLine("You have exited the program.");
Console.ResetColor();