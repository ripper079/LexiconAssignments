using static ClassLibraryUtils.UtilsInput;

using Vending_Machine;


VendingMachine myVendingMachine = new VendingMachine();
//Simulate purchase
//myVendingMachine.ShowCart();

myVendingMachine.InsertMoney(100);


//Control meny loop
bool keepRunning = true;
int validatedChoice = 0;

do
{
    Console.Clear();
    DisplayMenuChoices(myVendingMachine);

    //Force
    validatedChoice = ForceIntegerInput("Enter a menu option");

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
            
            break;
        case 6:
            DisplayShowShoppingCart(myVendingMachine);
            break;
        case 7:
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
    Console.Write($"Vending Machine - Purchase everything you need - You have ");    
    Console.ForegroundColor = ConsoleColor.Green;
    Console.Write($"{vendingMachine.MoneyPool-vendingMachine.CalculatePayment()}");
    Console.ForegroundColor = ConsoleColor.White;
    Console.WriteLine(" kr left");
    
    Console.WriteLine("Enter a choice");
    Console.WriteLine("1. Insert money");
    Console.WriteLine("2. See all products");
    Console.WriteLine("3. Examine product");
    Console.WriteLine("4. Buy a product");
    Console.WriteLine("5. Use a product");
    Console.WriteLine("6. Show shopping cart");
    Console.WriteLine("7. Quit");
}


//Sub meny systems
static void DisplayInsertMoneyIntoVendingMachine(VendingMachine vendingMachine) 
{
    Console.WriteLine();
    Console.WriteLine();
    int insertedMoney = ForceIntegerInput("Insert money into machine");
    Console.WriteLine($"You inserted {insertedMoney} kr");
    Console.WriteLine();
    vendingMachine.InsertMoney(insertedMoney);
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

    validatedChoice = ForceIntegerInput("Enter a menu option [integer option]");

    //All valid options should call base class
    switch (validatedChoice) 
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
            Console.WriteLine("Invalid menu option!!!!");
            Console.WriteLine("[Press any key for returning to MAIN meny]");
            Console.ReadKey();
            break;
    }

}

static void DisplayBuyAProduct(VendingMachine vendingMachine) 
{
    Console.WriteLine("Which product do you wish to buy [1-5]");
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
        Console.WriteLine($"You bought a {productUserChoose.ProductName} for {productUserChoose.Price} kr");
        Console.WriteLine("The item was added to your shopping cart");
        vendingMachine.Purchase(productUserChoose);
        
    }



}

static void DisplayUseAProduct()
{
    Console.WriteLine("Which product do you wish to use?");
}

static void DisplayShowShoppingCart(VendingMachine vendingMachine) 
{
    vendingMachine.ShowCart();
}