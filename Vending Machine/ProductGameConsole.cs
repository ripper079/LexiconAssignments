namespace Vending_Machine
{
    public  class ProductGameConsole : Product
    {        
        public ProductGameConsole() : base(750, "Game Console") { }        

        public override void Use()
        {
            base.Use();
            Console.WriteLine("This item is absolutly needed when you want to set a new high score");
        }

        public override string ToString()
        {
            return base.ToString() + $"[ProductGameConsole - No fields]";
        }
    }
}
