namespace Vending_Machine
{
    public abstract class Product
    {
        private static int _id;

        public Product(int price, string productName)
        {
            Price = price;
            ProductName = productName;
            Id = ++_id;
        }

        public int Id { get; private set; }
        public readonly int Price;
        public readonly string ProductName;

        public void Examine() 
        {
            Console.WriteLine("Product info specification");
            Console.WriteLine("----------------------------------------------------");
            string formattedName = "Product name: " + ProductName.PadRight(25);
            string formattedPrice = "Price: " + Price.ToString() + " kr".PadRight(15);
            Console.WriteLine(formattedName + formattedPrice);
        }

        public virtual void Use() 
        {
            Console.Write("Instruction usage - ");
        }

        //Implement for child classs - Be sure to print (abstract) base class info too        
        public override string ToString()
        {           
            return $"[Product] - Id: {Id} ProductName: {ProductName}\tPrice:{Price} kr";
        }         
    }

    
}
