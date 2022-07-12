using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//For enum containing blank spaces
using System.ComponentModel.DataAnnotations;

namespace Vending_Machine
{
    public class VendingMachine : IVending
    {
        public VendingMachine() 
        {
            MoneyPool = 0;
            _productClientBuy = new List<Product>();
            /*
            _productClientBuy.Add(new ProductPotatoChips(100, "Cheese Chips"));
            _productClientBuy.Add(new ProductPotatoChips(200, "Peanut Chips"));
            _productClientBuy.Add(new ProductPotatoChips(50, "Peppar Chips"));
            _productClientBuy.Add(new ProductPotatoChips());
            */
            //Lets fake it here
        }

        //Code requirement 2-0
        private readonly int[] denominations = new int[] {1000,500,100,50,20,10,5,1};

        //How much money the client has put in the vending machine
        public int MoneyPool { get; private set; }

        //      All interfaces (Code requirements)
        //              |
        //              |        
        //              v
        public void Purchase(Product aProduct) 
        {
            _productClientBuy.Add(aProduct);
        }


        
        public void ShowAll() 
        {
            //Console.WriteLine("\nCurrently available products to buy\n");
            //Console.WriteLine("-----------------------------------------------");
            //We have demo options for this type of service
            List<Product> demoProducts = new List<Product>();
            demoProducts.Add(new ProductPotatoChips());
            demoProducts.Add(new ProductIceCream());
            demoProducts.Add(new ProductLotteryGame());
            demoProducts.Add(new ProductSodaBeverage());
            demoProducts.Add(new ProductGameConsole());

            string formattedName;// = "Product name: " + ProductName.PadRight(25);
            string formattedPrice;// = "Price: " + Price.ToString() + " kr".PadRight(15);
            /*
            foreach (Product product in demoProducts)
            {
                formattedName = product.ProductName.PadRight(25);
                formattedPrice = "Price: " + product.Price.ToString() + " kr".PadRight(15);

                Console.WriteLine(formattedName + formattedPrice);
            }
            */
            

            for (int i = 0; i < demoProducts.Count(); i++) 
            {
                formattedName =  (i+1) + ". " + demoProducts[i].ProductName.PadRight(25);
                formattedPrice = demoProducts[i].Price.ToString() + " kr".PadRight(15);

                Console.WriteLine(formattedName + formattedPrice);
            }
            Console.WriteLine();

            //Console.WriteLine("\n[Press any key for returning to meny]");
            //Console.ReadKey();
        }

        public void InsertMoney(int amountMoney) 
        {
            MoneyPool += amountMoney;
        }




        //  End interface        

        public int CalculatePayment() 
        {
            int totalPayment = 0;
            foreach (Product aProduct in _productClientBuy)
            {
                totalPayment += aProduct.Price;
            }

            return totalPayment;
        }

        public void ShowCart() 
        {
            Console.WriteLine("Current shoppingCart");
            Console.WriteLine("-----------------------------------");
            foreach (Product aProduct in _productClientBuy)
            {
                Console.WriteLine($"Product: {aProduct.ProductName} [{aProduct.Price} kr]");
            }
            Console.WriteLine($"Total amount to pay: {CalculatePayment()} kr");
            Console.WriteLine();
        }

        public int CalculateReturnChange() 
        {
            return MoneyPool - CalculatePayment();
        }

        //Checks that the buyer have enough money for the item
        public bool EnoughMoney(Product product) 
        {
            if ((CalculatePayment() + product.Price) > MoneyPool)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        //List of products

        private List<Product> _productClientBuy;
        //Show meny item
        //Print correct denominations

    }
}
