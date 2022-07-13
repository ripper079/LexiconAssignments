using static ClassLibraryUtils.UtilsInput;

using Vending_Machine;


VendingMachine myVendingMachine = new VendingMachine();

// Free money to start out with
//myVendingMachine.InsertMoney(10000);


//Control meny loop
bool keepRunning = true;
int validatedChoice = 0;

do
{
    Console.Clear();
    DisplayMenuChoices(myVendingMachine);

    //Force
    validatedChoice = ForceIntegerInput("Enter a menu option [1-8]");

    //Perform user desired operation
    switch (validatedChoice)
    {
        case 1:
            DisplayInsertMoneyIntoVendingMachine(myVendingMachine);
            break;
        case 2:
            DisplayAllProducts(myVendingMachine);
            break;
        case 3:
            DisplayExamineProduct();
            break;
        case 4:
            DisplayBuyAProduct(myVendingMachine);
            break;
        case 5:
            DisplayUsageInfoProducts(myVendingMachine);
            break;
        case 6:
            DisplayShoppingCart(myVendingMachine);
            break;
        case 7:
            DisplayRemoveItemFromShoppingCart(myVendingMachine);
            break;
        case 8:
            DisplayChange(myVendingMachine);
            Console.WriteLine("Quit program");
            keepRunning = false;
            break;
        default:
            Console.WriteLine("Invalid menu option!!!!");            
            break;
    }
    Console.WriteLine("[Press any key for returning to main meny]");
    Console.ReadKey();
}

while (keepRunning);





//Main Meny System
static void DisplayMenuChoices(VendingMachine vendingMachine)
{
    //Display meny
    Console.Clear();
    Console.Write($"Vending Machine - You have inserted ");
    Console.ForegroundColor = ConsoleColor.Green;
    Console.Write($"{vendingMachine.MoneyPool} kr ");
    Console.ForegroundColor = ConsoleColor.White;
    Console.Write($"and you have purchased {vendingMachine.CountInShoppingCart()} item(s) for ");
    Console.ForegroundColor = ConsoleColor.Red;
    Console.Write($"{vendingMachine.CalculatePayment()} ");
    Console.ForegroundColor = ConsoleColor.White;
    Console.Write("kr. Balance is ");
    int balance = vendingMachine.MoneyPool - vendingMachine.CalculatePayment();

    Console.ForegroundColor = (balance < 0) ? ConsoleColor.Red : ConsoleColor.Green;
    Console.Write($"{balance}");
    Console.WriteLine(" kr");
    Console.ForegroundColor = ConsoleColor.White;

    Console.WriteLine();
    Console.WriteLine("Meny Selection");    
    Console.WriteLine("1. Insert money");
    Console.WriteLine("2. See all products");
    Console.WriteLine("3. Examine product");
    Console.WriteLine("4. Buy a product");
    Console.WriteLine("5. Use manual of product(s) in shopping cart");
    Console.WriteLine("6. Show shopping cart");
    Console.WriteLine("7. Delete item from shopping cart");
    Console.WriteLine("8. Quit [Done shopping]");
    Console.WriteLine();
}


//Sub meny systems
static void DisplayInsertMoneyIntoVendingMachine(VendingMachine vendingMachine) 
{
    Console.WriteLine();
    Console.WriteLine();
    Console.Write("Valid fixed denomintions [ ");
    foreach (int validDenomination in vendingMachine.denominations)
    {
        Console.Write($"{validDenomination} ");
    }
    Console.WriteLine("]");

    int insertedMoney = ForceIntegerInput("Insert money into machine");

    //Check for valid denomination
    bool validDenominationFlag = false;
    
    foreach (int validDenomination in vendingMachine.denominations)
    {
        if (validDenomination == insertedMoney)
        {
            validDenominationFlag = true;
            break;
        }
    }
    
    if (validDenominationFlag) 
    {
        Console.WriteLine($"You inserted {insertedMoney} kr");
        Console.WriteLine();
        vendingMachine.InsertMoney(insertedMoney);    
    }
    else
    {
        Console.WriteLine("That is INVALID fixed Denomination");
    }
    //Console.WriteLine("[Press any key for returning to meny]");
    //Console.ReadKey();
}

static void DisplayAllProducts(VendingMachine vendingMachine) 
{
    Console.WriteLine();
    Console.WriteLine();
    Console.WriteLine("Displaying all products");
    Console.WriteLine("-------------------------------------");
    vendingMachine.ShowAll();
}

static void DisplayExamineProduct() 
{
    Console.WriteLine();
    Console.WriteLine();
    
    int validatedChoice = 0;

    Console.WriteLine("Which product would you want to examine");
    Console.WriteLine("-------------------------------------");
    Console.WriteLine("1. Potato Chips");
    Console.WriteLine("2. Ice Cream");
    Console.WriteLine("3. Lottery Game");
    Console.WriteLine("4. Soda Beverage");
    Console.WriteLine("5. Game Console");
    Console.WriteLine();

    validatedChoice = ForceIntegerInput("Enter a product option [integer value 1-5]");
    Console.WriteLine();

    //Refactor with a switch expression better
    //All valid options should call base class
    /*switch (validatedChoice) 
    {
        case 1:
            new ProductPotatoChips().Examine();
            break;
        case 2:
            new ProductIceCream().Examine();
            break;
        case 3:
            new ProductLotteryGame().Examine();
            break;
        case 4:
            new ProductSodaBeverage().Examine();
            break;
        case 5:
            new ProductGameConsole().Examine();
            break;
        default:
            Console.WriteLine("Invalid product menu option!!!!");            
            break;
    }
    */

    //validatedChoice is only an integer for sure, we don't know the range 
    Product? userProductExamine = validatedChoice switch
    {
        1 => new ProductPotatoChips(),
        2 => new ProductIceCream(),
        3 => new ProductLotteryGame(),
        4 => new ProductSodaBeverage(),
        5 => new ProductGameConsole(),
        _ => null
    };

    if (userProductExamine == null) 
    {
        Console.WriteLine("Invalid product menu option!!!!");
    }
    else 
    {
        //Polymorfic behaviour
        userProductExamine.Examine();
    }

    Console.WriteLine();
}

static void DisplayBuyAProduct(VendingMachine vendingMachine) 
{
    Console.WriteLine();
    Console.WriteLine("Which product do you wish to buy [1-5]");
    Console.WriteLine("--------------------------------------");
    vendingMachine.ShowAll();

    int optionValue = ForceIntegerInput("Enter a valid integer");

    Product? productUserChoose = optionValue switch
    {
        1 => new ProductPotatoChips(),
        2 => new ProductIceCream(),
        3 => new ProductLotteryGame(),
        4 => new ProductSodaBeverage(),
        5 => new ProductGameConsole(),
        _ => null
    };

    if (productUserChoose == null) 
    {
        Console.WriteLine("Invalid input of product selection!");
    }
    else 
    {
        if (vendingMachine.EnoughMoneyToBuyOneMoreProduct(productUserChoose)) 
        {
            Console.WriteLine($"You bought a {productUserChoose.ProductName} for {productUserChoose.Price} kr");
            Console.WriteLine("The item was added to your shopping cart");
            Console.WriteLine();
            vendingMachine.Purchase(productUserChoose);     
        }
        else 
        {
            Console.WriteLine("You dont have enough money. Please insert some more money");
        }

        
    }
}

static void DisplayUsageInfoProducts(VendingMachine vendingMachine)
{    
    if (vendingMachine.IsShoppingCartEmpty())
    {
        Console.WriteLine("Shopping cart is empty");
    }
    else
    {
        Console.WriteLine();
        //Console.WriteLine("Which product do you wish to use/consume?");
        //vendingMachine.ShowAndCosumeProduct();
        vendingMachine.ShowUsageOfAllProductsInCart();
    }
}

static void DisplayShoppingCart(VendingMachine vendingMachine) 
{
    if (vendingMachine.IsShoppingCartEmpty()) 
    {
        Console.WriteLine("Shopping cart is empty");
    }
    else 
    {
        Console.WriteLine();
        vendingMachine.ShowCart();
    }
    
}

static void DisplayRemoveItemFromShoppingCart(VendingMachine vendingMachine) 
{
    if (vendingMachine.IsShoppingCartEmpty())
    {
        Console.WriteLine("Shopping cart is empty");
    }
    else
    {
        Console.WriteLine();
        vendingMachine.RemoveProduct();
    }

    
}

static void DisplayChange(VendingMachine vendingMachine) 
{
    Console.WriteLine();
    vendingMachine.ItemPurchased();
    Console.WriteLine($"Cash back: {vendingMachine.CalculateReturnChange()} kr");
    Console.WriteLine($"{vendingMachine.EndTransaction()}");
}



