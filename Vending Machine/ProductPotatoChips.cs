using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vending_Machine
{
    public class ProductPotatoChips : Product
    {
        //Hard coded, to avoid inflation :D
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
