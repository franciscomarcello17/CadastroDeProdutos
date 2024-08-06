using Exercise142_InheritanceAndPolymorphism.Entities;
using System.Globalization;

namespace Exercise142_InheritanceAndPolymorphism;

class Program
{
    static void Main(string[] args)
    {
        List<Product> list = new List<Product>();

        Console.Write("Enter the number of products: ");
        int n = int.Parse(Console.ReadLine());

        for (int i = 1; i <= n; i++) 
        {
            Console.WriteLine($"Product #{i} data:");
            Console.Write("Common, used or imported (c/u/i)? ");
            char ch = char.Parse(Console.ReadLine());
            Console.Write("Name: ");
            String name = Console.ReadLine();
            Console.Write("Price: ");
            double price = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
            if (ch == 'U' || ch == 'u')
            {
                Console.Write("Manufacture date (DD/MM/YYYY): ");
                DateTime manufacturedDate = DateTime.Parse(Console.ReadLine());
                list.Add(new UsedProduct(name, price, manufacturedDate));
            }
            else if (ch == 'I' || ch == 'i')
            {
                Console.Write("Customs Fee: ");
                double customsFee = double.Parse (Console.ReadLine(), CultureInfo.InvariantCulture);
                list.Add(new ImportedProduct(name, price, customsFee));
            }
            else
            {
                list.Add(new Product(name, price));
            }
        }
        Console.WriteLine();
        Console.WriteLine("PRICE TAGS:");

        foreach (Product product in list)
        {
            Console.WriteLine(product.PriceTag());
        }
    }
}