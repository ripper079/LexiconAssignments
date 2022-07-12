using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vending_Machine
{
    public abstract class Product
    {

        public Product(int price, string productName)
        {
            Price = price;
            ProductName = productName;
        }

        public readonly int Price;
        public readonly string ProductName;



        public override string ToString()
        {           
            return $"ProductName: {ProductName}\tPrice:{Price} kr";
        }

        //  ^
        //  |
        public void Examine() 
        {
            string formattedName = "Product name: " + ProductName.PadRight(25);
            string formattedPrice = "Price: " + Price.ToString() + " kr".PadRight(15);
            Console.WriteLine(formattedName + formattedPrice);
        }

        public virtual void Use() 
        {
            Console.Write("Instruction usage - ");
        }

    }

    
}
