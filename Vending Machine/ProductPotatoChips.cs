namespace Vending_Machine
{
    public class ProductPotatoChips : Product
    {        
        public ProductPotatoChips() : base(15, "Potato Chips") {}        

        public override void Use() 
        {
            base.Use();
            Console.WriteLine("You eat the potato chip and watches the stomach gets bigger and bigger");
        }

        public override string ToString()
        {
            return base.ToString() + $"[ProductPotatoChips - No fields]";
        }

    }
}
