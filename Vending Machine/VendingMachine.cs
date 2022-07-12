using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//For enum containing blank spaces
using System.ComponentModel.DataAnnotations;

using static ClassLibraryUtils.UtilsInput;

namespace Vending_Machine
{
    public class VendingMachine : IVending
    {
        public VendingMachine() 
        {
            MoneyPool = 0;
            _shoppingCart = new List<Product>();
        }

        //Code requirement 2-0
        private readonly int[] denominations = new int[] {1000,500,100,50,20,10,5,1};

        //How much money the client has put in the vending machine
        public int MoneyPool { get; private set; }
        
        private List<Product> _shoppingCart;
        //Show meny item
        //Print correct denominations

        //      All interfaces (Code requirements)
        //              |
        //              |        
        //              v

        public string EndTransaction() 
        {
            int changeBack = MoneyPool - CalculatePayment();

            int coinsIn1000 = changeBack / (denominations[0]);        // Antal st 1000 lappar
            changeBack -= coinsIn1000 * (denominations[0]);           // Resterande växel

            int coinsIn500 = changeBack / (denominations[1]);          // Antal st 500 lappar
            changeBack -= coinsIn500 * (denominations[1]);             // Resterande växel

            int coinsIn100 = changeBack / (denominations[2]);
            changeBack -= coinsIn100 * (denominations[2]);

            int coinsIn50 = changeBack / (denominations[3]);
            changeBack -= coinsIn50 * (denominations[3]);

            int coinsIn20 = changeBack / (denominations[4]);
            changeBack -= coinsIn20 * (denominations[4]);

            int coinsIn10 = changeBack / (denominations[5]);
            changeBack -= coinsIn10 * (denominations[5]);

            int coinsIn5 = changeBack / (denominations[6]);
            changeBack -= coinsIn5 * (denominations[6]);

            int coinsIn1 = changeBack / (denominations[7]);
            changeBack -= coinsIn1 * (denominations[7]);

            string cashBackInString = "\n" +
                                "Coins distribution\n" +
                                $"1000".PadRight(6) + "coins : " + $"{coinsIn1000.ToString()}\n" +
                                $"500".PadRight(6) + "coins : " + $"{coinsIn500.ToString()}\n" +
                                $"100".PadRight(6) + "coins : " + $"{coinsIn100.ToString()}\n" +
                                $"50".PadRight(6) + "coins : " + $"{coinsIn50.ToString()}\n" +
                                $"20".PadRight(6) + "coins : " + $"{coinsIn20.ToString()}\n" +
                                $"10".PadRight(6) + "coins : " + $"{coinsIn10.ToString()}\n" +
                                $"5".PadRight(6) + "coins : " + $"{coinsIn5.ToString()}\n" +
                                $"1".PadRight(6) + "coins : " + $"{coinsIn1.ToString()}\n";

            return cashBackInString;
        }

        public void Purchase(Product aProduct) 
        {
            //Check if client has enough $$$ in moneypool
            _shoppingCart.Add(aProduct);
        }

        public void ShowAndCosumeProduct() 
        {
            Console.WriteLine();
            Console.WriteLine("Own product(s)");
            Console.WriteLine();
            Console.WriteLine("Index\tProductname");
            for (int i = 0; i < _shoppingCart.Count; i++) 
            {
                Console.WriteLine($"{i}\t{_shoppingCart[i].ProductName}");
            }

            Console.WriteLine();
            Console.WriteLine("Remove product by selecting its index");
            int removeItemAtIndex = ForceIntegerInput("Enter a valid index");

            
            if (_shoppingCart.Count > 0) 
            {
                //Error check to se that index is within range
                if (removeItemAtIndex < _shoppingCart.Count) 
                {
                    Console.WriteLine($"You removed the product {_shoppingCart[removeItemAtIndex].ProductName}");
                    Console.WriteLine("Press a key to enter");
                    Console.ReadKey();
                    _shoppingCart.RemoveAt(removeItemAtIndex);
                }
                //Invalid index
                else 
                {
                    Console.WriteLine("You inserted an invalid index");
                }
            }
            else 
            {
                Console.WriteLine("Cannot consume anything, the cart is empty");
            }
        }

        public void ShowCart()
        {
            Console.WriteLine("Current shoppingCart");
            Console.WriteLine("-----------------------------------------");

            string formattedProductName;
            string formattedPrice;

            foreach (Product aProduct in _shoppingCart)
            {
                formattedProductName = aProduct.ProductName.PadRight(25);
                formattedPrice = aProduct.Price.ToString() + " kr".PadRight(1);

                Console.WriteLine($"Product: {formattedProductName} {formattedPrice}");
            }

            Console.WriteLine();
            Console.WriteLine($"Total amount to pay: {CalculatePayment()} kr");
            Console.WriteLine();
        }

        //Shows all availible shopping items (demoproducts)
        public void ShowAll() 
        {            
            //We have demo options for this type of service :D
            List<Product> demoProducts = new List<Product>();
            demoProducts.Add(new ProductPotatoChips());
            demoProducts.Add(new ProductIceCream());
            demoProducts.Add(new ProductLotteryGame());
            demoProducts.Add(new ProductSodaBeverage());
            demoProducts.Add(new ProductGameConsole());

            string formattedProductName;
            string formattedPrice;
            
            for (int i = 0; i < demoProducts.Count(); i++) 
            {
                formattedProductName =  (i+1) + ". " + demoProducts[i].ProductName.PadRight(25);
                formattedPrice = demoProducts[i].Price.ToString() + " kr".PadRight(15);

                Console.WriteLine(formattedProductName + formattedPrice);
            }
            Console.WriteLine();

        }

        //Client puts money into the Vending Machine
        public void InsertMoney(int amountMoney) 
        {
            MoneyPool += amountMoney;
        }

        //  End interfaces

        //Return a string of a user friendly denominations
        /*
        public string CalculateValidDenomination() 
        {            
            int changeBack = MoneyPool - CalculatePayment();           

            int coinsIn1000 = changeBack / (denominations[0]);        // Antal st 1000 lappar
            changeBack -= coinsIn1000 * (denominations[0]);           // Resterande växel

            int coinsIn500 = changeBack / (denominations[1]);          // Antal st 500 lappar
            changeBack -= coinsIn500 * (denominations[1]);             // Resterande växel

            int coinsIn100 = changeBack / (denominations[2]);           
            changeBack -= coinsIn100 * (denominations[2]);              

            int coinsIn50 = changeBack / (denominations[3]);
            changeBack -= coinsIn50 * (denominations[3]);

            int coinsIn20 = changeBack / (denominations[4]);
            changeBack -= coinsIn20 * (denominations[4]);

            int coinsIn10 = changeBack / (denominations[5]);
            changeBack -= coinsIn10 * (denominations[5]);

            int coinsIn5 = changeBack / (denominations[6]);
            changeBack -= coinsIn5 * (denominations[6]);

            int coinsIn1 = changeBack / (denominations[7]);
            changeBack -= coinsIn1 * (denominations[7]);

            string cashBackInString = "\n" +
                                "Coins distribution\n" +
                                $"1000".PadRight(6) + "coins : " + $"{coinsIn1000.ToString()}\n" +
                                $"500".PadRight(6) + "coins : " + $"{coinsIn500.ToString()}\n" +
                                $"100".PadRight(6) + "coins : " + $"{coinsIn100.ToString()}\n" +
                                $"50".PadRight(6) + "coins : " + $"{coinsIn50.ToString()}\n" +
                                $"20".PadRight(6) + "coins : " + $"{coinsIn20.ToString()}\n" +
                                $"10".PadRight(6) + "coins : " + $"{coinsIn10.ToString()}\n" +
                                $"5".PadRight(6) + "coins : " + $"{coinsIn5.ToString()}\n" +
                                $"1".PadRight(6) + "coins : " + $"{coinsIn1.ToString()}\n";

            return cashBackInString;                                
        }

        */

        //Sum of all items in shopping cart
        public int CalculatePayment() 
        {
            int totalPayment = 0;
            foreach (Product aProduct in _shoppingCart)
            {
                totalPayment += aProduct.Price;
            }

            return totalPayment;
        }

        

        public void ItemPurchased() 
        {
            Console.WriteLine("Item(s) purchased");
            Console.WriteLine("-----------------------------------");
            foreach (Product aProduct in _shoppingCart)
            {
                Console.WriteLine($"Product: {aProduct.ProductName}");
            }
            Console.WriteLine();
            
        }

        public bool IsShoppingCartEmpty() 
        {
            return ((_shoppingCart.Count > 0) ? false : true);

        }

        public int CalculateReturnChange() 
        {
            return MoneyPool - CalculatePayment();
        }

        //Checks that the buyer have enough money for the item
        public bool EnoughMoneyToBuyOneMoreProduct(Product product) 
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

    }
}
