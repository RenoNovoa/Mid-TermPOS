using System;
using System.Collections.Generic;

namespace Mid_TermPOS
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Our Store!");
            do
            {
                DisplayProducts();
                Console.WriteLine();
                Shopping.GoShopping();

            } while (ContinueAddingProducts());
            Shopping.CheckoutCartForUser();
            Console.ReadKey();
        }

        public static bool ContinueAddingProducts()
        {
            do
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\nWould you like to Add More Items? (y/n)");

                var userInput = Console.ReadLine();
                if (userInput.Equals("Y", StringComparison.OrdinalIgnoreCase) || userInput.Equals("yes", StringComparison.OrdinalIgnoreCase))
                {
                    return true;
                }
                else if (userInput.Equals("N", StringComparison.OrdinalIgnoreCase) || userInput.Equals("no", StringComparison.OrdinalIgnoreCase))
                {
                    return false;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("Please enter a valid Response ");
                }

            } while (true);
        }

        private static void DisplayProducts()
        {
            var products = TextFile.GetAllProducts();

            int counter = 1;

            foreach (var product in products)
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine($"{counter}. { product.Category }, { product.Name }, { product.Description }, { product.PriceOfItems }");
                counter++;
            }
        }

        public static List<Product> GetAllProducts()
        {
            List<Product> output = new List<Product>();

            List<string> storeItems = TextFile.GetItems(filePath);

            foreach (var merch in storeItems)
            {
                if (string.IsNullOrWhiteSpace(merch))
                {
                    continue;
                }
                string[] item = merch.Split(',');
                Product products = new Product();

                products.Name = item[0];
                products.Category = item[1];
                products.Description = item[2];
                decimal.TryParse(item[3], out decimal PriceOfItems);
                products.PriceOfItems = PriceOfItems;


                output.Add(products);
            };
            return output;
        }

        public static void Cash(decimal cartTotal)
        {
            decimal tendered = 0;
            do
            {

                Console.WriteLine("Your total is $" + cartTotal + ". How much cash is tendered?");
                decimal.TryParse(Console.ReadLine(), out tendered);
                if (tendered < cartTotal)
                {
                    Console.WriteLine("Inadequate funds, try again.");
                }

            }
            while (tendered < cartTotal);


            decimal change = tendered - cartTotal;
            Console.WriteLine("Your change back is: $" + change);
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}

