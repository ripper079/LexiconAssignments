namespace Vending_Machine
{
    public class ProductSodaBeverage : Product
    {
        public ProductSodaBeverage() : base(10, "Soda Beverage") { }

        public override void Use()
        {
            base.Use();
            Console.WriteLine("When you overheating consume this beverage to remedy this illness");
        }
        public override string ToString()
        {
            return base.ToString() + $"[ProductSodaBeverage - No fields]";
        }
    }
}
