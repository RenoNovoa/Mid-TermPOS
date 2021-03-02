using System;
using System.Collections.Generic;

namespace Mid_TermPOS
{
    partial class Program
    {
        public class Shopping
        {
            //public double Total { get; set; }

            public static List<OrderItem> ShoppingCart { get; set; } = new List<OrderItem>();



            public static void GoShopping()
            {

                var productList = TextFile.GetAllProducts();

                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("Please Select a  product from the list, to add to your shoping cart" +
                  "Enter number of the product");
                var userSelection = int.Parse(Console.ReadLine());

                var item = productList[userSelection - 1];

                Console.WriteLine("\nHow many items do you need today buddy?");
                var userAmountSelection = int.Parse(Console.ReadLine());
                Console.WriteLine();
                var itemTotal = item.PriceOfItems * userAmountSelection;

                OrderItem orderItem = new OrderItem(item, userAmountSelection, itemTotal);

                //if (do you want to add this to cart?)
                //{
                        ShoppingCart.Add(orderItem);
                //}


                Console.WriteLine($"You have Selected {userAmountSelection} {item.Name} totaling : $ {orderItem.ItemTotal}  ");

                DisplayRunningTotal(ShoppingCart);
                //Receipt.PrintTotal(ShoppingCart);

                //ShoppingCart.Add(new OrderItem());
                //var userSelection = Console.ReadLine();
            }
            public static string CheckoutCartForUser()
            {
                //bool isPaymentCorrect = false;
                bool StillLooping = true;
                string paymentImput;


                do
                {
                    Console.WriteLine(" How would you like to pay \n1.Cash  \n2.Credit \n3.Check ");
                    Console.Write("Enter a Num Option here: ");
                    paymentImput = Console.ReadLine();
                    Console.WriteLine();
                    //--------------------------------------------------------------
                    while (paymentImput != "1" && paymentImput != "2" && paymentImput != "3")
                    {
                        Console.WriteLine("Sorry, " + paymentImput + " is not an option. \nHow would ypu like to pay \n1.Cash  \n2.Credit \n3.Check");
                        paymentImput = Console.ReadLine();
                    }
                    //-------------------------------------------------------------
                    if (paymentImput.Equals("1", StringComparison.OrdinalIgnoreCase))
                    {
                        StillLooping = false;
                        Console.WriteLine("\nPlease Enter the Amount of Cash you will be paying with");

                        //You can validate in this later 
                    }
                    else if (paymentImput.Equals("2", StringComparison.OrdinalIgnoreCase))
                    {
                        StillLooping = false;
                        Console.WriteLine("\nPlease Enter Your Card Number:");
                        var userCardNumber = Console.ReadLine();
                        //---------------------------------------------------------
                        while (userCardNumber.Length != 16)
                        {
                            Console.WriteLine("Sorry, " + userCardNumber + " is not 16 numbers. \nWhat is your card number?");
                            userCardNumber = Console.ReadLine();
                        }
                        //---------------------------------------------------------
                        Console.WriteLine("\nPlease Enter the Expiration Date of your card (MMYY)");
                        var userExpDate = Console.ReadLine();
                        //--------------------------------------------------------
                        while (userExpDate.Length != 4)
                        {
                            Console.WriteLine("Sorry, " + userExpDate + " is not 4 numbers. \nPlease Enter the Expiration Date of your card (MMYY)?");
                            userExpDate = Console.ReadLine();
                        }
                        //--------------------------------------------------------
                        Console.WriteLine("\nPlease Enter the CVV of your credit card");
                        var userCW = Console.ReadLine();
                        while (userCW.Length != 3)
                        {
                            Console.WriteLine("Sorry, " + userCW + " is not 3 numbers. \nPlease Enter the CVV of your credit card? ");
                            userCW = Console.ReadLine();
                        }
                    }
                    else if (paymentImput.Equals("3", StringComparison.OrdinalIgnoreCase))
                    {
                        StillLooping = false;
                        Console.WriteLine("Please enter your First name & Last Name " +
                            " like in your ID please:");
                        var FnameLname = Console.ReadLine();
                        Console.WriteLine("\nPlease Enter the Check Number ");
                        var userCheckNum = Console.ReadLine();
                        //Lets find ways to validate here a check later buddy 
                    }
                    else
                    {
                        Console.WriteLine("Sorry we don't accept Crypto at this moment in this store  ");

                    }


                } while (StillLooping);



                return paymentImput;
            }

            public static void DisplayRunningTotal(List<OrderItem> shoppingCart)
            {
                var total = 0.00;

                foreach (var lineItem in shoppingCart)
                {
                    total += lineItem.ItemTotal;
                }

                Console.WriteLine("Your current total is: " + total.ToString("C2"));
            }

            public static void GenerateReceiptForUser()//List<Product> ShoppingCart 
            {
                //var total = 0;
                //var taxRate = 0.06;

                //ShoppingCart
            }
            //This is the method we creat if we want to Remove stuff from the list 
            //public static void ModifyShoppingCart()
            //{
            //    Console.WriteLine("Which item would you like to modify?");
            //    //Display All Items in Cart...
            //    int itemIndex = int.Parse(Console.ReadLine()) -1;

            //    var item = ShoppingCart[itemIndex];

            //    Console.WriteLine($"You currently have: {item.Item.Name}: Qty: {item.Quantity}");
            //    Console.WriteLine("How many items would like?");

            //    item.Quantity = int.Parse(Console.ReadLine());

            //    if(item.Quantity <= 0)
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

}
