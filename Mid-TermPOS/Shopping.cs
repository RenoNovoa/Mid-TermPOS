using System;
using System.Collections.Generic;
using System.Text;

namespace Mid_TermPOS
{
    public class Shopping
    {
        private static double total = 0;
        public static List<OrderItem> ShoppingCart { get; set; } = new List<OrderItem>();

        public static void GoShopping()
        {

            var productList = TextFile.GetAllProducts();

            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Select a  product from the list, to add to your Spacecraft shopping cart" );
            Console.Write("\n\rPlease Enter Number Of The Product:  ");
            var userSelection = int.Parse(Console.ReadLine());

            var item = productList[userSelection - 1];

            Console.WriteLine("\nHow many items do you need today buddy?");
            var userAmountSelection = int.Parse(Console.ReadLine());
            Console.WriteLine();
            var itemTotal = item.PriceOfItems * userAmountSelection;

            OrderItem orderItem = new OrderItem(item, userAmountSelection, itemTotal);

           
            ShoppingCart.Add(orderItem);          


            Console.WriteLine($"You have Selected {userAmountSelection} {item.Name} Totaling : $ {orderItem.ItemTotal}  ");

            DisplayRunningTotal();
           
        }

        public static string CheckoutCartForUser()
        {
            bool StillLooping = true;
            string paymentImput;

            do
            {
                Console.WriteLine(" How would you like to pay \n1.Cash  \n2.Credit \n3.Check ");
                Console.Write("\n\rEnter a Number Option here: ");

                paymentImput = Console.ReadLine();

                
                while (paymentImput != "1" && paymentImput != "2" && paymentImput != "3")
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Sorry, " + paymentImput + " is not an option. \nHow would ypu like to pay \n1.Cash  \n2.Credit \n3.Check");
                    paymentImput = Console.ReadLine();
                }

                if (paymentImput.Equals("1", StringComparison.OrdinalIgnoreCase))
                {
                    StillLooping = false;
                    Console.WriteLine("\nPlease Enter the Amount of Cash you will be paying with: ");

                    GenerateReceiptCash(total);
                    
                }
                else if (paymentImput.Equals("2", StringComparison.OrdinalIgnoreCase))
                {
                    StillLooping = false;

                    Console.WriteLine("\nPlease Enter Your Card Number:");
                    Console.WriteLine("The card Number must have 16 Digits " +
                        "Ex" + "(1234568912365421\n\r)");

                    var userCardNumber = Console.ReadLine();
                    while (userCardNumber.Length != 16)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Sorry, " + userCardNumber + " is not 16 numbers. \nWhat is your card number?");
                        userCardNumber = Console.ReadLine();
                    }

                    Console.WriteLine("\nPlease Enter the Expiration Date of your card (MMYY)");
                    var userExpDate = Console.ReadLine();

                    while (userExpDate.Length != 4)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Sorry, " + userExpDate + " is not 4 numbers. \nPlease Enter the Expiration Date of your card (MMYY)?");
                        userExpDate = Console.ReadLine();
                    }
                    Console.WriteLine("\nPlease Enter the CVV of your credit card");
                    var userCW = Console.ReadLine();

                    while (userCW.Length != 3)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Sorry, " + userCW + " is not 3 numbers. \nPlease Enter the CVV of your credit card? Ex. 123");
                        userCW = Console.ReadLine();
                    }



                }
                else if (paymentImput.Equals("3", StringComparison.OrdinalIgnoreCase))
                {
                    StillLooping = false;
                    Console.WriteLine("\n\rPlease Enter Your Routing Number ");
                    Console.WriteLine("Routing Must have 9 DIgits:");
                    var userRouting = Console.ReadLine();

                    while (userRouting.Length != 9)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Sorry, " + userRouting + " is not 9 Digits. \n\rPlease Enter Your Routing Number ");
                        userRouting = Console.ReadLine();
                    }

                    Console.WriteLine("\nPlease Enter the Account Number ");
                    var userAccountNum = Console.ReadLine();

                    while (userAccountNum.Length != 10)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Sorry, " + userAccountNum + " is not 10 Digits. \n\rPlease Enter the Account NUmber ");
                        userAccountNum = Console.ReadLine();
                    }

                    Console.WriteLine("\n\rPlease Enter Your Check Number ");
                    var userCheckNUm = Console.ReadLine();

                    while (userCheckNUm.Length != 4)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Sorry, " + userCheckNUm + " is not 4 Digits. \n\rPlease Enter Your Check Number ");
                        userCheckNUm = Console.ReadLine();
                    }
                    // Call Check Receipt
                    GenerateReceiptCheck(userCheckNUm);
                }
                else
                {
                    Console.WriteLine("Sorry we don't accept Crypto at this moment in this store  ");

                }


            } while (StillLooping);



            return paymentImput;
            
        }

        public static void DisplayRunningTotal()
        {          

            foreach (var lineItem in ShoppingCart)
            {
                total += lineItem.ItemTotal;
            }

            Console.WriteLine("Your current total is: " + total.ToString("C2"));
        }

        public static void GenerateReceiptCash(double cartTotal)
        {
            ReceiptHeader();

            ReceiptBody();

            Console.WriteLine("How much are paying?");
            double cashTendered = double.Parse(Console.ReadLine());
            while(cashTendered < cartTotal)
            {

            }

            Console.WriteLine("Your change backis ....");

            ReceiptFooter(cartTotal);
        }

        public static void GenerateReceiptCredit(double cartTotal, string cardNumber)
        {
            ReceiptHeader();

            ReceiptBody();

            Console.WriteLine($"Card number {cardNumber}: was charged {cartTotal * 1.06} ");

            ReceiptFooter(cartTotal);
        }
        public static void GenerateReceiptCheck(string checkNumber)
        {
            ReceiptHeader();

            ReceiptBody();

            Console.WriteLine($"Check number {checkNumber}: was charged  ");

            ReceiptFooter(total);
        }

        public static string HideCardNumber(string credit)
        {
            StringBuilder sb = new StringBuilder("XXXX-XXXX-XXXX-");
            for (int i = 12; i < credit.Length; i++)
            {
                sb.Append(credit[i]);
            }

            return sb.ToString();
        }

        private static void ReceiptFooter(double total)
        { 
            var taxRate = 0.06;
            var taxTotal = (taxRate * total);
            var granTotal = (taxTotal + total);
            Console.WriteLine("\nYour Sub Total is :" + total.ToString("C2"));
            Console.WriteLine("\nYour Tax total is :" + taxTotal.ToString("C2"));
            Console.WriteLine("\nYour Final Total is :" + granTotal.ToString("C2"));
        }

        private static void ReceiptBody()
        {
            foreach (var product in ShoppingCart)
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine($"{product.Quantity} {product.Item.Name}-----${product.Item.PriceOfItems * product.Quantity}");
            }
        }

        public static void ReceiptHeader()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("\n\r\n\rThank for shopping with us.");
            Console.WriteLine("Register:Danny Novoa.");
            Console.WriteLine($"Date: {DateTime.Now.ToShortDateString()}");
            Console.WriteLine("\n\r\n\rOrder Description: ");
        }


        //This is the method we creat if we want to Remove stuff from the list
        //public static void ModifyShoppingCart()
        //{
        //    Console.WriteLine("Which item would you like to modify?");
        //    //Display All Items in Cart...
        //    int itemIndex = int.Parse(Console.ReadLine()) - 1;

        //    var item = ShoppingCart[itemIndex];

        //    Console.WriteLine($"You currently have: {item.Item.Name}: Qty: {item.Quantity}");
        //    Console.WriteLine("How many items would like?");

        //    item.Quantity = int.Parse(Console.ReadLine());

        //    if (item.Quantity <= 0)
        //    {

        //    }

        //    ShoppingCart.RemoveAt(itemIndex);

        //    ShoppingCart.Insert(itemIndex, item);
        //}

        //public static List<OrderItem> GetUserItems()
        //{
        //    return "";
        //}


        //AddToShoppingCart
    }

}
