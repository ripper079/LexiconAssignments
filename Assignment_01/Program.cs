using System;


namespace Assignment_01
{
    class Program
    {
        static void Main(string[] args)
        {
            //Control meny loop
            bool keepRunning = true;
           
            int validatedChoice = 0;
                        
            do
            {
                Program.displayMenuChoices();

                //Force
                validatedChoice = forceIntegerInput("Enter a menu option");

                //Perform user desired operation
                switch (validatedChoice)
                {
                    case 1:                        
                        performAddition();
                        break;
                    case 2:                       
                        performSubtraction();
                        break;
                    case 3:                       
                        performDivision();
                        break;
                    case 4:                       
                        performMultiplication();
                        break;
                    case 5:
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
           
        }

        static void displayMenuChoices() 
        {
            //Display meny
            Console.Clear();                        
            Console.WriteLine("Calculator Simulator");
            Console.WriteLine("Enter a choice");
            Console.WriteLine("1. Addition");
            Console.WriteLine("2. Subtraction");
            Console.WriteLine("3. Division");
            Console.WriteLine("4. Multiplication");
            Console.WriteLine("5. Quit");
        }   

        //User input
        // |
        // |
        // v   
        static int forceIntegerInput(string title) 
        {
            Console.WriteLine(title);
            var numbAsString = Console.ReadLine();
            int validatedNumber;

            while (!int.TryParse(numbAsString, out validatedNumber))
            {
                Console.WriteLine("That not a number. " + title);
                numbAsString = Console.ReadLine();
            }            

            return validatedNumber;
        } 

        //Calculation operations 
        // |
        // |
        // v  

        static void performAddition() 
        {
            int userInputNumber1 = 0;
            int userInputNumber2 = 0;

            int calculationResult = 0;

            Console.WriteLine("Addition Calculation");
            //Force user to enter 2 correct math operand(s)
            userInputNumber1 = forceIntegerInput("Enter first operand");
            userInputNumber2 = forceIntegerInput("Enter second operand");            
            calculationResult = userInputNumber1 + userInputNumber2;
            
            Console.WriteLine(userInputNumber1 + "+" + userInputNumber2 + "= " + calculationResult);
            Console.WriteLine("[Press any key for returning to meny]");
            Console.ReadKey();
        }

        static void performSubtraction() 
        {
            int userInputNumber1 = 0;
            int userInputNumber2 = 0;

            int calculationResult = 0;

            Console.WriteLine("Subtraction Calculation");
            //Force user to enter 2 correct math operand(s)
            userInputNumber1 = forceIntegerInput("Enter first operand");
            userInputNumber2 = forceIntegerInput("Enter second operand");            
            calculationResult = userInputNumber1 -  userInputNumber2;
            
            Console.WriteLine(userInputNumber1 + "-" + userInputNumber2 + "= " + calculationResult);
            Console.WriteLine("[Press any key for returning to meny]");
            Console.ReadKey();
        }

        static void performMultiplication() 
        {
            int userInputNumber1 = 0;
            int userInputNumber2 = 0;

            int calculationResult = 0;

            Console.WriteLine("Multiplication Calculation");
            //Force user to enter 2 correct math operand(s)
            userInputNumber1 = forceIntegerInput("Enter first operand");
            userInputNumber2 = forceIntegerInput("Enter second operand");
            calculationResult = (userInputNumber1 * userInputNumber2);

            Console.WriteLine(userInputNumber1 + "*" + userInputNumber2 + "= " + calculationResult);
            Console.WriteLine("[Press any key for returning to meny]");
            Console.ReadKey();
        }

        static void performDivision() 
        {
            int userInputNumber1 = 0;
            int userInputNumber2 = 0;

            bool flagDivisionByZero = false;            

            Console.WriteLine("Division Calculation");
            
            //Force user to enter 2 correct math operand(s)
            userInputNumber1 = forceIntegerInput("Enter first operand");            
            //Make Error check - Don't allow divsion by zero
            userInputNumber2 = forceIntegerInput("Enter second operand");
            if (userInputNumber2 == 0)
                flagDivisionByZero = true;

            //Flag is now true
            while (flagDivisionByZero)
            {
                Console.WriteLine("You can't divide by ZERO");
                userInputNumber2 = forceIntegerInput("Enter second operand");
                if (userInputNumber2 == 0)
                    flagDivisionByZero = true;
                else
                    flagDivisionByZero = false;
            }

            //Conversion is needed
            double resultInDouble = Convert.ToDouble(userInputNumber1) / Convert.ToDouble(userInputNumber2);
            //Round to 2 digits
            resultInDouble = Math.Round(resultInDouble, 2);

            Console.WriteLine(userInputNumber1 + "/" + userInputNumber2 + "= " + resultInDouble);
            Console.WriteLine("[Press any key for returning to meny]");
            Console.ReadKey();
        }
    }
}

