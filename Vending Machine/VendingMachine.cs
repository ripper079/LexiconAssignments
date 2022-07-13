using static ClassLibraryUtils.UtilsInput;

namespace Vending_Machine
{
    public class VendingMachine : IVending
    {
        public VendingMachine() 
        {
            MoneyPool = 0;
            _shoppingCart = new List<Product>();
            _availibleProductsForBuying = new List<Product>();

            PopulateProductsForBuying();            
        }        
        //Code requirement 2-0
        public readonly int[] denominations = new int[] {1000,500,100,50,20,10,5,2,1};

        //Shopping Cart
        private List<Product> _shoppingCart;        
        //Availible items in vending machine
        private List<Product> _availibleProductsForBuying;

        private void PopulateProductsForBuying() 
        {
            
            int i;

            for (i = 0; i < 5; i++) 
            {
                _availibleProductsForBuying.Add(new ProductPotatoChips());                
            }

            for (i = 0; i < 5; i++)
            {
                _availibleProductsForBuying.Add(new ProductIceCream());
            }

            for (i = 0; i < 5; i++)
            {
                _availibleProductsForBuying.Add(new ProductSodaBeverage());
            }
            
            for (i = 0; i < 3; i++) 
            {
                _availibleProductsForBuying.Add(new ProductLotteryGame());
            }

            _availibleProductsForBuying.Add(new ProductGameConsole());

        }        

        //How much money the client has put in the vending machine
        public int MoneyPool { get; private set; }
       
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

        public int CalculateReturnChange()
        {
            return MoneyPool - CalculatePayment();
        }

        //Numbers of item in shopping chart
        public int CountInShoppingCart() 
        {
            return _shoppingCart.Count;
        }

        public bool IsShoppingCartEmpty()
        {
            return ((_shoppingCart.Count > 0) ? false : true);

        }
        
        public bool IsIdValidForAvailibleProducts(int prospectId) 
        {
            bool flagFoundMatch = false;
            foreach(var aProduct in _availibleProductsForBuying) 
            {
                if (aProduct.Id == prospectId) 
                {
                    flagFoundMatch = true;
                    break;
                }
            }
            return flagFoundMatch;
        }


        //MAKE sure that the id is Valid BEFORE calling this func
        public Product GetProduct(int productId) 
        {
            Product productFound = null;
            foreach(Product product in _availibleProductsForBuying) 
            {
                if (productId == product.Id) 
                {
                    productFound = product;
                    break;
                }
            }

            return productFound;
        }

        public bool IsEmptyOfProducts()
        {
            if (_availibleProductsForBuying.Count == 0) 
            {
                return true;
            }
            return false;
        }

        //      All interfaces (Code requirements)
        //              |
        //              |        
        //              v

        //Client puts money into the Vending Machine
        public void InsertMoney(int amountMoney)
        {
            MoneyPool += amountMoney;
        }

        public string EndTransaction() 
        {
            int changeBack = MoneyPool - CalculatePayment();

            String cashBack = "\n";

            int coinsIn1000 = changeBack / (denominations[0]);        // Antal st 1000 lappar
            changeBack -= coinsIn1000 * (denominations[0]);           // Resterande växel
            if (coinsIn1000 != 0) 
            {
                cashBack += $"1000".PadRight(6) + "coins : " + $"{coinsIn1000.ToString()}\n";
            }

            int coinsIn500 = changeBack / (denominations[1]);          // Antal st 500 lappar
            changeBack -= coinsIn500 * (denominations[1]);             // Resterande växel
            if (coinsIn500 != 0) 
            {
                cashBack += $"500".PadRight(6) + "coins : " + $"{coinsIn500.ToString()}\n";
            }

            int coinsIn100 = changeBack / (denominations[2]);
            changeBack -= coinsIn100 * (denominations[2]);
            if (coinsIn100 != 0)
            {
                cashBack += $"100".PadRight(6) + "coins : " + $"{coinsIn100.ToString()}\n";
            }

            int coinsIn50 = changeBack / (denominations[3]);
            changeBack -= coinsIn50 * (denominations[3]);
            if (coinsIn50 != 0) 
            {
                cashBack += $"50".PadRight(6) + "coins : " + $"{coinsIn50.ToString()}\n";
            }

            int coinsIn20 = changeBack / (denominations[4]);
            changeBack -= coinsIn20 * (denominations[4]);
            if (coinsIn20 != 0) 
            {
                cashBack += $"20".PadRight(6) + "coins : " + $"{coinsIn20.ToString()}\n";
            }

            int coinsIn10 = changeBack / (denominations[5]);
            changeBack -= coinsIn10 * (denominations[5]);
            if (coinsIn10 != 0) 
            {
                cashBack +=  $"10".PadRight(6) + "coins : " + $"{coinsIn10.ToString()}\n";
            }

            int coinsIn5 = changeBack / (denominations[6]);
            changeBack -= coinsIn5 * (denominations[6]);
            if (coinsIn5 != 0)
            {
                cashBack += $"5".PadRight(6) + "coins : " + $"{coinsIn5.ToString()}\n";
            }

            int coinsIn2 = changeBack / (denominations[7]);
            changeBack -= coinsIn2 * (denominations[7]);
            if (coinsIn2 != 0)
            {
                cashBack += $"5".PadRight(6) + "coins : " + $"{coinsIn2.ToString()}\n";
            }

            int coinsIn1 = changeBack / (denominations[8]);
            changeBack -= coinsIn1 * (denominations[8]);
            if (coinsIn1 != 0)
            {
                cashBack += $"1".PadRight(6) + "coins : " + $"{coinsIn1.ToString()}\n";
            }      

            return cashBack;
        }

        public void Purchase(Product aProduct) 
        {
            //Check if client has enough $$$ in moneypool
            _shoppingCart.Add(aProduct);
            _availibleProductsForBuying.Remove(aProduct);
        }

        //Shows all availible shopping items 
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
                formattedProductName = (i + 1) + ". " + demoProducts[i].ProductName.PadRight(25);
                formattedPrice = demoProducts[i].Price.ToString() + " kr".PadRight(15);

                Console.WriteLine(formattedProductName + formattedPrice);
            }
            Console.WriteLine();
        }

        public void ShowUsageOfAllProductsInCart() 
        {
            Console.WriteLine();
            Console.WriteLine("Instruction usage for all items in shoping cart");
            Console.WriteLine("-------------------------------------------------");

            foreach(Product product in _shoppingCart) 
            {
                Console.Write($"Product \'{product.ProductName}\' : ");
                product.Use();
            }
            Console.WriteLine();
        }

        public void ShowCart()
        {
            Console.WriteLine("Current shoppingCart");
            Console.WriteLine("-----------------------------------------");

            foreach (Product productBought in _shoppingCart) 
            {
                Console.WriteLine(productBought);
            }

            Console.WriteLine();
        }

        public void ShowAllBuyableItems() 
        {
            Console.WriteLine("Buyable product(s)");
            Console.WriteLine("-----------------------------------------");

            string formattedProductName;
            string formattedPrice;

            foreach (Product aProduct in _availibleProductsForBuying)
            {
                formattedProductName = aProduct.ProductName.PadRight(25);
                formattedPrice = aProduct.Price.ToString() + " kr".PadRight(1);

                //Console.WriteLine($"Product: {formattedProductName} {formattedPrice}");
                Console.WriteLine(aProduct);
            }
            Console.WriteLine();
        }                
        //  End interfaces                     

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
