using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace workingPOS
{
    public class TextFile
    {
        public static readonly string filePath = @"C:\PosApp\Products.txt";

        public static List<string> GetItems(string filePath)
        {
            List<string> output = new List<string>();

            List<string> storeItems = File.ReadAllLines(filePath).ToList();
          
            return storeItems;
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
                double.TryParse(item[3], out double PriceOfItems);
                products.PriceOfItems = PriceOfItems;


                output.Add(products);
            };
            return output;
        }
    }
        
}
 //
//check if there is an empty space
//foreach (var item in storeItems)
//{
//    if(!string.IsNullOrWhiteSpace(item))
//    {
//        output.Add(item);
//    }
//}
