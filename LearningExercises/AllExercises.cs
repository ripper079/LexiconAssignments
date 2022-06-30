using System;
using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

using static ClassLibraryUtils.UtilsInput;


namespace LearningExercises
{
    public class AllExercises
    {
        #region Propertis
        public int MyProperty { get; set; }
        #endregion

        //Testing purposes
        public static void DisplayStaticAlive() 
        {
            Console.WriteLine("Static and It's alive and reachable");
        }

        //Testing purposes
        public void DisplayAlive() 
        {
            Console.WriteLine("The method in the object is reachable");
        }

        public void Exercise01()
        {
            string firstName = "Daniel";
            string lastName = "Oikarainen";
            //Console.WriteLine("Hello " + firstName + " " + lastName + "! I'm glad to inform you that you are the test subject of my very first assignmnet!");
            //Console.WriteLine("Hello {0} {1} ", firstName, lastName);
            //@@@
            Console.WriteLine($"Hello again {firstName} {lastName}");
        }
        public void Exercise02() 
        {
            DateTime currentDate = DateTime.Now;
            DateTime tomorrowDate = currentDate.AddDays(1);
            DateTime yesterdayDate = currentDate.AddDays(-1);
            
            //Without Time portion
            Console.WriteLine("Todays date is:\t\t" + currentDate.ToString("yyyy-MM-dd"));
            Console.WriteLine("Tomorrow date is:\t" + tomorrowDate.ToString("yyyy-MM-dd"));
            Console.WriteLine("Yesterday date was:\t" + yesterdayDate.ToString("yyyy-MM-dd"));
        }
        public void Exercise03() 
        {
            Console.Clear();
            Console.Write("Enter your first name: ");
            String firstName = Console.ReadLine();
            Console.Write("Enter your last name: ");
            String lastName = Console.ReadLine();

            Console.WriteLine($"Full name: {firstName} {lastName}");            
        }
        public void Exercise04()
        {
            //Original string
            String str = "The quick fox Jumped Over the DOG";

            //The desired result string
            // "The brown fox jumped over the lazy dog"                         

            //Worse than french :D
            // "The brown fox jumped over the dog"
            String replacedString = str.Replace("quick", "brown").
                                        Replace("DOG", "dog").
                                        Replace("Jumped", "jumped").
                                        Replace("Over", "over");

            //get index of dog and 
            int indexOfThe = replacedString.IndexOf("dog");
            //insert "lazy " there
            string resultString = replacedString.Insert(indexOfThe, "lazy ");
            Console.WriteLine(resultString);            
        }
        public void Exercise05() 
        {
            Console.WriteLine("Exercise 5");
            String str = "Arrays are very common in programming, the look something like: [1,2,3,4,5]";
            //String str = "[1,2,3,4,5]";
            int indexLeftBracket = str.IndexOf("[");
            int indexRightBracket = str.IndexOf("]");
            //Index array start at 0
            int lengthOfBracket = indexRightBracket - indexLeftBracket + 1;
            //Console.WriteLine("StarPos: " + indexLeftBracket + " EndPos: " + indexRightBracket);
            //Console.WriteLine("Length of Brackets:" + lengthOfBracket);

            // "[1,2,3,4,5]"
            String baseStringArray = str.Substring(indexLeftBracket, lengthOfBracket);
            
            //Remove "2" and "3",   "[1,4,5]"    
            String partialStringArray = baseStringArray.Replace("2,", "").Replace("3,", "");
            
            //Add 6-10 string elements
            String addedStringNumber = ",6,7,8,9,10";
            indexRightBracket = partialStringArray.IndexOf("]");

            String finalString = partialStringArray.Insert(indexRightBracket, addedStringNumber);

            Console.WriteLine(finalString);
        }
        public void Exercise06() 
        {
            Console.WriteLine("Exercise 6");
            int numberOne = forceIntegerInput("Enter an int number [first]");
            int numberTwo = forceIntegerInput("Enter a number [second]");
            Console.WriteLine();

            int smallestNumber =  ((numberOne < numberTwo) ? numberOne : numberTwo);
            int largestNumber = ((numberOne > numberTwo) ? numberOne : numberTwo);
            int differenceNumber = largestNumber - smallestNumber;
            int sumOfNumbers = smallestNumber + largestNumber;
            int productOfNumbers = smallestNumber * largestNumber;

            // Indicates Infinity
            bool flagDivisionByZero = ((numberTwo == 0) ? true : false);
            

            Console.WriteLine($"The smallest number is:\t\t{smallestNumber}");
            Console.WriteLine($"The largest number is:\t\t{largestNumber}");
            Console.WriteLine($"Delta between number:\t\t{ differenceNumber}");
            Console.WriteLine($"Sum of numbers:\t\t\t{sumOfNumbers}");
            Console.WriteLine($"The product of numbers:\t\t{productOfNumbers}");


            if (flagDivisionByZero) 
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Division by zero not allowed!");
                Console.ForegroundColor = ConsoleColor.Green;
            }
            
            else 
            {
                double ratio = (double)numberOne / (double)numberTwo;
                //3 Deciamls
                ratio = Math.Round(ratio, 3);
                Console.WriteLine($"The ratio between numbers:\t{ratio}");
            }
            
        }
        public void Exercise07() 
        {
            Console.WriteLine("Exercise 7");

            double radius = forceDoubleInput("Input radius of a circle [as an double]");
            
            double areaCircle = (2*Math.PI * Math.Pow(radius, 2));
            double volumeCircle = (4 * Math.PI * Math.Pow(radius, 3)) / 3;

            //Round of to 2 digits
            areaCircle = Math.Round(areaCircle, 2);
            volumeCircle = Math.Round(volumeCircle, 2);

            Console.WriteLine($"The area of a cirle with radius {radius} is {areaCircle}");
            Console.WriteLine($"The volume of a sphere with radius {radius} is {volumeCircle}");

        }
        public void Exercise08() 
        {
            Console.WriteLine("Exercise 8");
            //decimal number = AllExercises.forceDecimalInput("Input a decimal number");

            double number = forceDoubleInput("Input a decimal number");
            Console.WriteLine();

            Console.WriteLine($"The {number} squareRooted {(Math.Sqrt(number))}");
            Console.WriteLine($"The {number} raised to 2 is {(Math.Pow(number, 2))}");
            Console.WriteLine($"The {number} raised to 10 is {(Math.Pow(number, 10))}");

        }
        public void Exercise09() 
        {
            Console.WriteLine("Exercise 9");
            Console.WriteLine("Enter you name:");
            string name = Console.ReadLine();

            int birthYearOfCustomer = forceIntegerInput("Enter your birthday year");            
            //Extract current year
            int currentYear = DateTime.Now.Year;

            int ageOfCustomer = currentYear - birthYearOfCustomer;
            
            //Adult
            if (ageOfCustomer >= 18)
            {
                Console.WriteLine("Do you want to order a beer(y/n)?");
                String beerYesOrNo = Console.ReadKey().KeyChar.ToString();
                Console.WriteLine();

                //Convert to uppercase
                beerYesOrNo = beerYesOrNo.ToUpper();                
                //Beer?
                if (String.Equals(beerYesOrNo, "Y"))
                {
                    Console.WriteLine("The order for BEER has been done");
                }
                else if (String.Equals(beerYesOrNo, "N"))
                {
                    orderCoke();
                    /*
                    //Coke                     
                    Console.WriteLine("Do you want to order a coke(y/n)?");
                    String cokeYesOrNo = Console.ReadKey().KeyChar.ToString();
                    Console.WriteLine();
                    //Convert to uppercase
                    cokeYesOrNo = cokeYesOrNo.ToUpper();

                    if (String.Equals(cokeYesOrNo, "Y"))
                    {
                        Console.WriteLine("The order for COKE has been done");
                    }
                    else if (String.Equals(cokeYesOrNo, "N"))
                    {
                        Console.WriteLine("Sorry, no other options are availible");
                    }
                    else
                    {
                        Console.WriteLine("Invalid input option for coke selection");
                    }
                    */
                }
                else
                {

                    Console.WriteLine("Invalid input option for beer selection");
                }
            }
            //Underage
            else 
            {
                orderCoke();
                /*
                //Coke                     
                Console.WriteLine("Do you want to order a coke(y/n)?");
                String cokeYesOrNo = Console.ReadKey().KeyChar.ToString();
                Console.WriteLine();
                //Convert to uppercase
                cokeYesOrNo = cokeYesOrNo.ToUpper();

                if (String.Equals(cokeYesOrNo, "Y"))
                {
                    Console.WriteLine("The order for COKE has been done");
                }
                else if (String.Equals(cokeYesOrNo, "N"))
                {
                    Console.WriteLine("Sorry, no other options are availible");
                }
                else
                {
                    Console.WriteLine("Invalid input option for coke selection");
                }
                */
            }

        }
        private void orderCoke() 
        {
            //Coke                     
            Console.WriteLine("Do you want to order a coke(y/n)?");
            String cokeYesOrNo = Console.ReadKey().KeyChar.ToString();
            Console.WriteLine();
            //Convert to uppercase
            cokeYesOrNo = cokeYesOrNo.ToUpper();

            if (String.Equals(cokeYesOrNo, "Y"))
            {
                Console.WriteLine("The order for COKE has been done");
            }
            else if (String.Equals(cokeYesOrNo, "N"))
            {
                Console.WriteLine("Sorry, no other options are availible");
            }
            else
            {
                Console.WriteLine("Invalid input option for coke selection");
            }
        }

        private bool toogleColor = false;
        public void Exercise10() 
        {
            Console.WriteLine("Exercise 10");            
            Console.WriteLine("1. [Division Calc]");
            Console.WriteLine("2. [Invoke exercise 4]");
            Console.WriteLine("3. [Toogle color]");
            int optionChoice = forceIntegerInput("Choose an option");
            switch (optionChoice) 
            {
                case 1 :
                    ExecuteSub10_1();
                break;
                case 2 :
                    Exercise04();
                break;
                case 3 :
                    toogleColor = !toogleColor;
                    if (toogleColor)
                        Console.ForegroundColor = ConsoleColor.DarkBlue;
                    else
                        Console.ForegroundColor = ConsoleColor.Yellow;

                    Console.WriteLine("This text color should change each re-run");
                    break;
            }            
            

            
        }

        private void ExecuteSub10_1() 
        {
            int a = forceIntegerInput("Enter the first number");
            int b = forceIntegerInput("Enter the second number");

            if (b == 0)
            {
                Console.WriteLine("Division by zero not allowed");
            }
            else 
            {
                double resultDivision = (double)a / (double)b;
                resultDivision = Math.Round(resultDivision, 3);
                Console.WriteLine($"The division of {a}/{b} is {resultDivision}");
            }
        }

        public void Exercise11() 
        {
            int number = forceIntegerInput("Enter an interger[greater than 0]");
            Console.WriteLine();
            if (number <= 0) 
            {
                Console.WriteLine($"Told you to put a number greater than 0. You inputed {number}");
            }
            else
            {
                for (int i = 0; i <= number; i++) 
                {
                    Console.ForegroundColor = ((i % 2) == 0) ?  ConsoleColor.Red : ConsoleColor.Green;
                    Console.WriteLine(i);
                }
                Console.WriteLine("-----------------------------------------------");

                for (int i = number; i >= 0; i--)
                {
                    Console.ForegroundColor = ((i % 2) == 0) ? ConsoleColor.Red : ConsoleColor.Green;
                    Console.WriteLine(i);
                }
            }
        }

        public void Exercise12() 
        {
            for (int i = 1; i <= 10; i++)
                PrintMultiplicationRow(i);
        }

        private void PrintMultiplicationRow(int rowNumber) 
        {
            for (int i = 1; i <=10; i++)
                Console.Write($"{rowNumber * i}\t");
            Console.WriteLine();
        }

        public void Exercise13() 
        {
            Random random = new Random();
            int secretNumber = random.Next(1, 500);

            bool wrongGuess = true;
            int countGuesses = 0;
            string guessedNumberInString;
            int guessedNumber;
            Console.WriteLine("Guess the right number, 1-500");
            while (wrongGuess) 
            {
                Console.WriteLine("Take a guess");
                guessedNumberInString = Console.ReadLine();
                int.TryParse(guessedNumberInString, out guessedNumber);
                ++countGuesses;
                if (secretNumber > guessedNumber)
                    Console.WriteLine("You're guess is to LOW");
                else if (secretNumber < guessedNumber)
                    Console.WriteLine("You're guess is to HIGH");
                else 
                {
                    Console.WriteLine("Correct guessed");
                    Console.WriteLine($"You need {countGuesses} guesses");
                    wrongGuess = false;
                }
            }
        }

        public void Exercise14() 
        {
            Console.WriteLine("Exercise 14");
            int countNumberEntered = 0;
            int sumAllNumbers = 0;

            string userInputInString;
            int userInputNumber;

            bool keepRunning = true;

            while (keepRunning) 
            {
                Console.Write("Enter a number: ");
                userInputInString = Console.ReadLine();
                int.TryParse(userInputInString, out userInputNumber);

                if (userInputNumber == -1)
                {
                    Console.WriteLine($"Sum: {sumAllNumbers}");
                    Console.WriteLine($"Average: {(double)sumAllNumbers / (double)countNumberEntered}");
                    keepRunning = false;
                }
                else
                {
                    sumAllNumbers += userInputNumber;
                    ++countNumberEntered;
                }

            }
        }

        public void Exercise15() 
        {
            Console.WriteLine("Exercise 15");
            ExecuteSub15_1();
            Console.WriteLine();
            ExecuteSub15_2();

        }
        private void ExecuteSub15_1() 
        {
            int userInput = forceIntegerInput("Enter a valid integer number");
            Console.WriteLine("Displaying divisible numbers");

            //Skip 1 
            Console.Write("[");
            for (int i = 2; i <= userInput; i++)
            {
                if (userInput % i == 0)
                    Console.Write($" {userInput / i} ");
            }
            Console.Write("]");
            Console.WriteLine();
        }

        private void ExecuteSub15_2() 
        {
            Console.WriteLine("Finding perfect numbers...");
            int countMatch = 0;
            const int countMaxNumbersToFind = 3;

            for (int i = 1; i < int.MaxValue; i++) 
            {
                if (IsPerfectNumber(i))
                {
                    Console.WriteLine($"Match! {i} is a perfect number");
                    countMatch++;
                }

                if (countMaxNumbersToFind == countMatch)
                    break;
            }
            
        }

        private bool IsPerfectNumber(int prospect) 
        {
            // To store sum of divisors
            int sum = 1;

            // Find all divisors and add them
            for (int i = 2; i * i <= prospect; i++)
            {
                if (prospect % i == 0)
                {
                    if (i * i != prospect)
                        sum = sum + i + prospect / i;
                    else
                        sum = sum + i;
                }
            }
            // If sum of divisors is equal to
            // n, then n is a perfect number
            if (sum == prospect && prospect != 1)
                return true;

            return false;
        }

        public void Exercise16()
        {
            Console.WriteLine("Exercise 16");
            int number = forceIntegerInput("Enter a number [geater than 0] for Fibonacci series");

            int val1 = 0, val2 = 1, val3;

            Console.WriteLine("Fibonacci series:");
            //Prints first 3 numbers
            Console.Write(val1 + " " + val2 + " ");
            for (int i = 2; i < number; ++i)
            {
                val3 = val1 + val2;
                Console.Write(val3 + " ");
                val1 = val2;
                val2 = val3;

            }
            Console.WriteLine();
        }

        public void Exercise17() 
        {
            Console.WriteLine("Exercise 17");
            Console.WriteLine("Palimdrone test");
            Console.Write("Enter a word to check: ");
            string userInputString = Console.ReadLine();
                       
            Console.WriteLine();
            //Remove all blank spaces
            string removeBlanks = userInputString.Replace(" ", string.Empty);            

            char[] charArrayCopy = removeBlanks.ToCharArray();
            //reverse it
            Array.Reverse(charArrayCopy);

            //Copy to a new string
            string reverseString = new string(charArrayCopy);

            if (String.Equals(removeBlanks, reverseString))
                Console.WriteLine($"\"{userInputString}\" is  a palindrome");
            else
                Console.WriteLine($"\"{userInputString}\" is NOT  a palindrome");

        }

    }


}
