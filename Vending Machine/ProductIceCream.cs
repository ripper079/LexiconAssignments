using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vending_Machine
{
    public  class ProductIceCream : Product
    {
        //Hard coded, to avoid inflation :D
        public ProductIceCream() : base(25, "Ice Cream") {}
        //Ok, you are responsible for the inflation and brand name
        //public ProductIceCream(int price, string productName) : base(price, productName) {}

        public override void Use()
        {
            base.Use();
            Console.WriteLine("Ice Cream is only enjoyed on a hot summer day");
        }
    }
}
