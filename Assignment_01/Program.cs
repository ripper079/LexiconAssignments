using System;

namespace Assignment_01
{
    public class Program
    {
        static void Main(string[] args)
        {
            //Control meny loop
            bool keepRunning = true;
           
            int validatedChoice = 0;
                        
            do
            {
                Program.DisplayMenuChoices();

                //Force
                validatedChoice = ForceIntegerInput("Enter a menu option");

                //Perform user desired operation
                switch (validatedChoice)
                {
                    case 1:
                        DisplayAddition();
                        break;
                    case 2:
                        DisplaySubtraction();
                        break;
                    case 3:
                        DisplayDivision();
                        break;
                    case 4:
                        DisplayMultiplication();
                        break;
                    case 5:
                        DisplayAdditionWithArray();
                        break;
                    case 6:
                        DisplaySubtractionWithArray();
                        break;
                    case 7:
                        Console.WriteLine("Quit program");
                        keepRunning = false;
                        break;
                        // Add option for user to enter multiple inputs, sum and subtract
                    default:
                        Console.WriteLine("Invalid menu option!!!!");
                        Console.WriteLine("[Press any key for returning to meny]");
                        Console.ReadKey();
                        break;
                }
            }

            while (keepRunning);                                   
        }

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

        //User input
        // |
        // |
        // v   
        static int ForceIntegerInput(string title) 
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
       
        static void DisplayAddition() 
        {
            Console.WriteLine("Addition Calculation");                     
            
            //Force user to enter 2 correct math operand(s)
            int userInputNumber1 = ForceIntegerInput("Enter first operand");
            int userInputNumber2 = ForceIntegerInput("Enter second operand");

            int additionResult = Addition(userInputNumber1, userInputNumber2);
            Console.WriteLine(userInputNumber1 + "+" + userInputNumber2 + "= " + additionResult);
            Console.WriteLine("[Press any key for returning to meny]");
            Console.ReadKey();
        }

        static void DisplayAdditionWithArray() 
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

                int additionResult = Addition(arrayOfInts);
               
                Console.WriteLine($"The sum of all inputed int: {additionResult}");
            }
            else 
            {
                Console.WriteLine("Invalid data inputed!");
            }                                        
            
            Console.WriteLine("Press enter to continue");
            Console.ReadLine();
            
        }

        
        public static int Addition(int numberOne, int numberTwo) 
        {            
            return (numberOne + numberTwo);
        }

        public static int Addition(int[] arrayOfInts) 
        {
            int sumAddition = 0;
            foreach (int item in arrayOfInts) 
            {
                sumAddition += item;
            }

            return sumAddition;            
        }

        static void DisplaySubtraction() 
        {            
            Console.WriteLine("Subtraction Calculation");
            //Force user to enter 2 correct math operand(s)
            int userInputNumber1 = ForceIntegerInput("Enter first operand");
            int userInputNumber2 = ForceIntegerInput("Enter second operand");
            int subtractionResult = Subtraction(userInputNumber1,userInputNumber2);

            Console.WriteLine(userInputNumber1 + "-" + userInputNumber2 + "= " + subtractionResult);
            Console.WriteLine("[Press any key for returning to meny]");
            Console.ReadKey();
        }

        static void DisplaySubtractionWithArray()
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

                int subtractionResult = Subtraction(arrayOfInts);

                Console.WriteLine($"The sum of all inputed int: {subtractionResult}");
            }
            else
            {
                Console.WriteLine("Invalid data inputed!");
            }

            Console.WriteLine("Press enter to continue");
            Console.ReadLine();

        }

        public static int Subtraction(int numberOne, int numberTwo) 
        {
            return (numberOne - numberTwo);
        }

        public static int Subtraction(int[] arrayOfInts) 
        {
            int sumSubtraction = 0;
            foreach (int item in arrayOfInts)
            {
                sumSubtraction += item;
            }

            return -sumSubtraction;
        }

        static void DisplayMultiplication() 
        {
            Console.WriteLine("Multiplication Calculation");
            //Force user to enter 2 correct math operand(s)
            int userInputNumber1 = ForceIntegerInput("Enter first operand");
            int userInputNumber2 = ForceIntegerInput("Enter second operand");
            int multiplicationResult = Multiplication(userInputNumber1, userInputNumber2);

            Console.WriteLine(userInputNumber1 + "*" + userInputNumber2 + "= " + multiplicationResult);
            Console.WriteLine("[Press any key for returning to meny]");
            Console.ReadKey();
        }

        public static int Multiplication(int numberOne, int numberTwo) 
        {
            return (numberOne * numberTwo);
        }
       

        static void DisplayDivision() 
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
            
            double divisionResult = Division(userInputNumber1, userInputNumber2);
            //Round to 2 digits
            divisionResult = Math.Round(divisionResult, 2);

            Console.WriteLine(userInputNumber1 + "/" + userInputNumber2 + "= " + divisionResult);
            Console.WriteLine("[Press any key for returning to meny]");
            Console.ReadKey();
        }

        public static double Division(int numberOne, int numberTwo)
        {            
            double divisionResult = 0;

            try
            {
                divisionResult = (Convert.ToDouble(numberOne) / Convert.ToDouble(numberTwo));
            }
            catch (DivideByZeroException exp) 
            {
                Console.WriteLine("Exception caught!!! Division by zero not allowed");
                Console.WriteLine("Message: " + exp.Message);
            }

            return divisionResult;
        }

        public static bool ArrayContainsOnlyInts(String[] splittedArray)
        {
            bool flagIntsOnly = true;
            foreach (String stringItem in splittedArray)
            {
                if (! int.TryParse(stringItem, out _))
                {
                    flagIntsOnly = false;
                    break;
                }
            }

            return flagIntsOnly;
        }
    }
}

