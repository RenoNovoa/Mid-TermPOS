using System;

namespace Mid_TermPOS
{
    partial class Program
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
    }

}

