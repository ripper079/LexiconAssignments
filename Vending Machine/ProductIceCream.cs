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
