namespace Vending_Machine
{
    public  class ProductIceCream : Product
    {        
        public ProductIceCream() : base(25, "Ice Cream") {}        

        public override void Use()
        {
            base.Use();
            Console.WriteLine("Ice Cream is only enjoyed on a hot summer day");
        }

        public override string ToString()
        {
            return base.ToString() + $"[ProductIceCream - No fields]";
        }
    }
}
