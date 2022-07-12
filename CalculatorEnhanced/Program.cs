using static ClassLibraryUtils.UtilsInput;

Calculator myCalculator = new Calculator(0, 0);


//Control meny loop
bool keepRunning = true;
int validatedChoice = 0;

do
{
    DisplayMenuChoices();

    //Force
    validatedChoice = ForceIntegerInput("Enter a menu option");

    //Perform user desired operation
    switch (validatedChoice)
    {
        case 1:
            DisplayAddition(myCalculator);
            break;
        case 2:
            DisplaySubtraction(myCalculator);
            break;
        case 3:
            DisplayDivision(myCalculator);
            break;
        case 4:
            DisplayMultiplication(myCalculator);
            break;
        case 5:
            DisplayAdditionWithArray(myCalculator);
            break;
        case 6:
            DisplaySubtractionWithArray(myCalculator);
            break;
        case 7:
            Console.WriteLine("Quit program");
            keepRunning = false;
            break;
        default:
            Console.WriteLine("Invalid menu option!!!!");
            Console.WriteLine("[Press any key for returning to meny]");
            Console.ReadKey();
            break;
    }
}

while (keepRunning);


//Meny System
static void DisplayMenuChoices()
{
    //Display meny
    Console.Clear();
    Console.WriteLine("Calculator Simulator");
    Console.WriteLine("Enter a choice");
    Console.WriteLine("1. Addition");
    Console.WriteLine("2. Subtraction");
    Console.WriteLine("3. Division");
    Console.WriteLine("4. Multiplication");
    Console.WriteLine("5. Addition with an array");
    Console.WriteLine("6. Subtraction with an array");
    Console.WriteLine("7. Quit");
}


//Addition
static void DisplayAddition(Calculator myCalculator)
{
    Console.WriteLine("Addition Calculation");

    //Force user to enter 2 correct math operand(s)
    int userInputNumber1 = ForceIntegerInput("Enter first operand");
    int userInputNumber2 = ForceIntegerInput("Enter second operand");

    myCalculator.InsertOperandValues(userInputNumber1, userInputNumber2);

    Console.WriteLine(myCalculator.OperandOne + "+" + myCalculator.OperandTwo + "= " + myCalculator.Addition());
    Console.WriteLine("[Press any key for returning to meny]");
    Console.ReadKey();
}
static void DisplayAdditionWithArray(Calculator myCalculator)
{
    Console.WriteLine("Addition array Calculation");

    Console.WriteLine("Enter an array of integers - seperate with ONE blank space");

    string[] splittedString = Console.ReadLine().Trim().Split(' ');
 
    if (ArrayContainsOnlyInts(splittedString))
    {
        int[] arrayOfInts = new int[splittedString.Length];

        for (int i = 0; i < arrayOfInts.Length; i++)
        {
            arrayOfInts[i] = int.Parse(splittedString[i]);
        }

        int additionResultOfArray = myCalculator.Addition(arrayOfInts);

        Console.WriteLine($"The sum of all inputed int: {additionResultOfArray}");
    }
    else
    {
        Console.WriteLine("Invalid data inputed!");
    }

    Console.WriteLine("Press enter to continue");
    Console.ReadLine();

}

//Subtraction
static void DisplaySubtraction(Calculator myCalculator)
{
    Console.WriteLine("Subtraction Calculation");
    //Force user to enter 2 correct math operand(s)
    int userInputNumber1 = ForceIntegerInput("Enter first operand");
    int userInputNumber2 = ForceIntegerInput("Enter second operand");
    myCalculator.InsertOperandValues(userInputNumber1, userInputNumber2);

    Console.WriteLine(myCalculator.OperandOne + "-" + myCalculator.OperandTwo + "= " + myCalculator.Subtraction());
    Console.WriteLine("[Press any key for returning to meny]");
    Console.ReadKey();
}
static void DisplaySubtractionWithArray(Calculator myCalculator)
{
    Console.WriteLine("Subtraction array Calculation");
    Console.WriteLine("Enter an array of integers - seperate with ONE blank space");

    string[] splittedString = Console.ReadLine().Trim().Split(' ');

    if (ArrayContainsOnlyInts(splittedString))
    {
        int[] arrayOfInts = new int[splittedString.Length];

        for (int i = 0; i < arrayOfInts.Length; i++)
        {
            arrayOfInts[i] = int.Parse(splittedString[i]);
        }

        int subtractionResultOfArray = myCalculator.Subtraction(arrayOfInts);

        Console.WriteLine($"The sum of all inputed int: {subtractionResultOfArray}");
    }
    else
    {
        Console.WriteLine("Invalid data inputed!");
    }

    Console.WriteLine("Press enter to continue");
    Console.ReadLine();

}

//Multiplication
static void DisplayMultiplication(Calculator myCalculator)
{
    Console.WriteLine("Multiplication Calculation");
    //Force user to enter 2 correct math operand(s)
    int userInputNumber1 = ForceIntegerInput("Enter first operand");
    int userInputNumber2 = ForceIntegerInput("Enter second operand");
    myCalculator.InsertOperandValues(userInputNumber1, userInputNumber2);

    Console.WriteLine(myCalculator.OperandOne + "*" + myCalculator.OperandTwo + "= " + myCalculator.Multiplication());
    Console.WriteLine("[Press any key for returning to meny]");
    Console.ReadKey();
}

//Division
static void DisplayDivision(Calculator myCalculator)
{
    Console.WriteLine("Division Calculation");

    //Force user to enter 2 correct math operand(s)
    int userInputNumber1 = ForceIntegerInput("Enter first operand");
    //Make Error check - Don't allow division by zero by enfocing user to enter anything but 0
    int userInputNumber2 = ForceIntegerInput("Enter second operand");

    bool flagDivisionByZero = false;
    if (userInputNumber2 == 0)
        flagDivisionByZero = true;

    //Flag is now true
    while (flagDivisionByZero)
    {
        Console.WriteLine("You can't divide by ZERO");
        userInputNumber2 = ForceIntegerInput("Enter second operand");
        if (userInputNumber2 == 0)
            flagDivisionByZero = true;
        else
            flagDivisionByZero = false;
    }

    myCalculator.InsertOperandValues(userInputNumber1, userInputNumber2);

    //Round off to 2 digits
    Console.WriteLine(myCalculator.OperandOne + "/" + myCalculator.OperandTwo + "= " + Math.Round(myCalculator.Division(), 2));
    Console.WriteLine("[Press any key for returning to meny]");
    Console.ReadKey();
}



public class Calculator
{
    //The thought here is that we set BOTH operands with ONE method call, InsertOperandValues
    //else user might forget som operands
    public int OperandOne { get ; private set; }
    public int OperandTwo { get; private set; }


    public Calculator(int initOperandOne, int initOperandTwo)
    {
        OperandOne = initOperandOne;
        OperandTwo = initOperandTwo;
    }

    public void InsertOperandValues(int operandOne, int operandTwo) 
    {
        OperandOne = operandOne;
        OperandTwo = operandTwo;
    }

    public int Addition()
    {
        return (OperandOne + OperandTwo);
    }

    public int Addition(int[] arrayOfInts) 
    {
        int sumAddition = 0;
        foreach (int item in arrayOfInts)
        {
            sumAddition += item;
        }

        return sumAddition;
    }

    public int Subtraction() 
    {
        return (OperandOne - OperandTwo);
    }

    public int Subtraction(int[] arrayOfInts)
    {
        int sumSubtraction = 0;
        foreach (int item in arrayOfInts)
        {
            sumSubtraction += item;
        }

        return -sumSubtraction;
    }

    public int Multiplication()
    {
        return (OperandOne * OperandTwo);
    }

    public double Division()
    {
        double divisionResult = 0;

        try
        {
            divisionResult = (Convert.ToDouble(OperandOne) / Convert.ToDouble(OperandTwo));
        }
        catch (DivideByZeroException exp)
        {
            Console.WriteLine("Exception caught!!! Division by zero not allowed");
            Console.WriteLine("Message: " + exp.Message);
        }

        return divisionResult;
    }
}



