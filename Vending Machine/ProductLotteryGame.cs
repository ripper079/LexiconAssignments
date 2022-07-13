namespace Vending_Machine
{
    public class ProductLotteryGame : Product
    {
        public ProductLotteryGame() : base(125, "Lottery Game") {}

        public override void Use()
        {
            base.Use();
            Console.WriteLine("Pick the right lottery and be a $$$ Millionaire $$$");
        }

        public override string ToString()
        {
            return base.ToString() + $"[ProductLotteryGame - No fields]";
        }
    }
}
