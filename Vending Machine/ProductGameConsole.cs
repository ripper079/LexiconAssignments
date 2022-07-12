using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vending_Machine
{
    public  class ProductGameConsole : Product
    {
        //Hard coded, to avoid inflation :D
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
