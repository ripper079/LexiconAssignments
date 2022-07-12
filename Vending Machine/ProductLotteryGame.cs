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
        
        //Ok, you are responsible for the inflation and brand name
        //public ProductLotteryGame(int price, string productName) : base(price, productName) {}

        public override void Use()
        {
            base.Use();
            Console.WriteLine("Pick the lottery and be a $$$ Millionaire $$$");
        }
    }
}
