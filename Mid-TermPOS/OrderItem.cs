namespace Mid_TermPOS
{
    public class OrderItem 
    {
        public Product Item { get; set; }
        public int Quantity { get; set; }
        public double ItemTotal { get; set; }

        public OrderItem(Product item, int quantity, double itemTotal  )
        {
            Item = item;
            Quantity = quantity;
            ItemTotal = itemTotal;

        }

    }

}


 
