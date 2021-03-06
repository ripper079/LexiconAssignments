using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vending_Machine
{
    public class ProductLotteryGame : Product
    {
        //Hard coded, to avoid inflation :D
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
