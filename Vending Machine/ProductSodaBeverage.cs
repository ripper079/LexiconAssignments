using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vending_Machine
{
    public class ProductSodaBeverage : Product
    {
        //Hard coded, to avoid inflation :D
        public ProductSodaBeverage() : base(10, "Soda Beverage") { }
        //Ok, you are responsible for the inflation and brand name
        //public ProductSodaBeverage(int price, string productName) : base(price, productName) { }

        public override void Use()
        {
            base.Use();
            Console.WriteLine("When you overheating consume this beverage to remedy this illness");
        }
    }
}
