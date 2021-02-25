using System;

namespace Mid_TermPOS
{
    class Program
    {
        static void Main(string[] args)
        {
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
        }
    }
}
