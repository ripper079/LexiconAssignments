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
            int numberOne = ForceIntegerInput("Enter an int number [first]");
            int numberTwo = ForceIntegerInput("Enter a number [second]");
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

            double radius = ForceDoubleInput("Input radius of a circle [as an double]");
            
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

            int birthYearOfCustomer = ForceIntegerInput("Enter your birthday year");            
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
            int optionChoice = ForceIntegerInput("Choose an option");
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
            int a = ForceIntegerInput("Enter the first number");
            int b = ForceIntegerInput("Enter the second number");

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
            int number = ForceIntegerInput("Enter an interger[greater than 0]");
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
            int userInput = ForceIntegerInput("Enter a valid integer number");
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
            int number = ForceIntegerInput("Enter a number [geater than 0] for Fibonacci series");

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

        public void Exercise18() 
        {
            Console.WriteLine("Exercise 18");
            const int sizeOfArray = 10;
            int[] arrayOfInt = new int[sizeOfArray];
            double[] arrayOfDouble = new double[sizeOfArray];
            Random random = new Random();

            for (int i = 0; i < sizeOfArray; i++)
            {
                arrayOfInt[i] = random.Next(1,100);
                arrayOfDouble[i] = 1.0D / (double)arrayOfInt[i];
            }

            Console.WriteLine("Int values");
            foreach (int i in arrayOfInt) 
            {
                Console.WriteLine($"{i}");
            }
            Console.WriteLine();
            Console.WriteLine("Double values");
            foreach (double i in arrayOfDouble)
            {
                Console.WriteLine($"{i}");
            }
        }

        public void Exercise19() 
        {
            Console.WriteLine("Exercise 19");
            Console.Write("Money to pay: ");
            String strMoneyToPay = Console.ReadLine();
            Console.Write("Enter the sum to pay: ");
            String strSumToPay = Console.ReadLine();
            
            int priceToPay;
            int userPays;
            

            int.TryParse(strMoneyToPay, out priceToPay);
            int.TryParse(strSumToPay, out userPays);

            int changeBack = userPays - priceToPay;
            if (changeBack < 0)
            {
                Console.WriteLine("You payed to little");
            }
            else 
            {            
                Console.WriteLine($"Calculated change: {changeBack}");

                int coinsIn1000 = changeBack / 1000;        // Antal st 1000 lappar
                changeBack -= coinsIn1000 * 1000;           // Resterande växel
            
                int coinsIn500 = changeBack / 500;          // Antal st 500 lappar
                changeBack -= coinsIn500 * 500;             // Resterande växel

                int coinsIn100 = changeBack / 100;
                changeBack -= coinsIn100 * 100;

                int coinsIn50 = changeBack / 50;
                changeBack -= coinsIn50 * 50;

                int coinsIn20 = changeBack / 20;
                changeBack -= coinsIn20 * 20;

                int coinsIn10 = changeBack / 10;
                changeBack -= coinsIn10 * 10;

                int coinsIn5 = changeBack / 5;
                changeBack -= coinsIn5 * 5;

                int coinsIn1 = changeBack / 1;
                changeBack -= coinsIn1 * 1;

                Console.WriteLine();
                Console.WriteLine("Coins distribution");
                Console.WriteLine($"1000 coins : {coinsIn1000}");
                Console.WriteLine($"500 coins : {coinsIn500}");
                Console.WriteLine($"100 coins : {coinsIn100}");
                Console.WriteLine($"50 coins : {coinsIn50}");
                Console.WriteLine($"20 coins : {coinsIn20}");
                Console.WriteLine($"10 coins : {coinsIn10}");
                Console.WriteLine($"5 coins : {coinsIn5}");
                Console.WriteLine($"1 coins : {coinsIn1}");
            }
        }

        public void Exercise20() 
        {
            Console.WriteLine("Exercise 20");
            const int arraySize = 21;

            int[] arrayOne = new int[arraySize];
            int[] arrayTwo = new int[arraySize];

            int leftIndex = 0;
            int rightIndex = arraySize - 1;

            Random random = new Random();

            for (int i = 0; i < arraySize; i++) 
            {
                arrayOne[i] = random.Next(1,100); 
            }

            
            foreach (int number in arrayOne)
            {
                //means even, put them to the right side of the array
                if ((number % 2) == 0)
                {
                    arrayTwo[rightIndex] = number;
                    rightIndex--;
                }
                else 
                {
                    arrayTwo[leftIndex] = number;
                    leftIndex++;
                }
            }
            
            Console.WriteLine("Odd number to the left and even to the right");
            foreach (int number in arrayTwo) 
            {
                Console.Write($" {number} ");
            }
            Console.WriteLine();

        }

        public void Exercise21() 
        {
            Console.WriteLine("Exercise 21");
            Console.WriteLine("Enter numbers - separated with comma");
            string numbersWithComma = Console.ReadLine();

            String[] splittedWords = numbersWithComma.Split(",");
            int[] numberArrays = new int[splittedWords.Length];                                        

            for (int i = 0; i < splittedWords.Length; i++) 
            {
                int.TryParse(splittedWords[i], out numberArrays[i]);
            }

            int sum = 0;
            //Any will do but we know that at least one element should exist
            int min = numberArrays[0];
            int max = numberArrays[0];

            foreach (int number in numberArrays) 
            {
                sum += number;
                if (min > number)
                {
                    min = number; 
                }
                if (max < number)
                {
                    max = number; 
                }

            }

            double average = (double)sum / (double)splittedWords.Length;

            Console.WriteLine();
            Console.WriteLine("Inputed number(s) in array");
            foreach (int number in numberArrays) 
            {
                Console.WriteLine($"Number {number}");
            }
            Console.WriteLine();
            Console.WriteLine($"Min value: {min}" );
            Console.WriteLine($"Max value: {max}");
            Console.WriteLine($"Average value: {average}");

        }

        public void Exercise22() 
        {            
            Console.WriteLine("Exercise 22");
            Console.WriteLine();
            int countSwearWords = 0;

            string[] swearWords = new string[] { "stupid", "ugly", "donkeyass", "idiot", "ass", "R", "as", "Å" };
            //Console.WriteLine("Say something mean");
            //string prospectBadWord = Console.ReadLine();

            //string prospectBadWord = "you are a ugly ugly.. an idiot    or .donkeyass";
            string prospectBadWord = "you are stupid and ugly apple. an .idiot. and donkeyass. learn c# and Å get smart idiot ass as";

            //Splitted words but still having .,;:
            char[] charToChopOff = { '.', ',', ';', ':' };
            string[] userAllWordsSplitted = prospectBadWord.Split(" ");

            /*
            string rebuildString = string.Join(" ", userAllWordsSplitted);
            Console.WriteLine("Rebuilded string");
            Console.WriteLine(rebuildString);
            */
            printStringArray(userAllWordsSplitted, "Splitted Array");
            
            string[] userSplittedWordFiltedAwayDots = GetWordsWithoutMatchPattern(userAllWordsSplitted);
            printStringArray(userSplittedWordFiltedAwayDots, " Filtered array[dots]");
            
            //Censur words [without dots]
            string[] userSplittedWordFiltedAwayDotsReplacedWord = new string[userSplittedWordFiltedAwayDots.Length];

            for (int i = 0; i < userSplittedWordFiltedAwayDots.Length; i++) 
            {
                //Match for swearwords
                if (IsSwearWord(userSplittedWordFiltedAwayDots[i], swearWords)) 
                {
                    countSwearWords++;
                    userSplittedWordFiltedAwayDotsReplacedWord[i] = GetNewCencuredWord(userSplittedWordFiltedAwayDots[i]);
                }
                else 
                {
                    userSplittedWordFiltedAwayDotsReplacedWord[i] = userSplittedWordFiltedAwayDots[i];
                }
            }

            printStringArray(userSplittedWordFiltedAwayDotsReplacedWord, "Cencured words");


            string[] correctCencoredString = buildCencuredStringsWithStars(userAllWordsSplitted, userSplittedWordFiltedAwayDotsReplacedWord);

            printStringArray(correctCencoredString, "Rebuilded string with dots");

            /*
            Console.WriteLine("Original input from user");
            Console.WriteLine(prospectBadWord);
            Console.WriteLine();
            Console.WriteLine($"Cencured output {countSwearWords} time(s)");
            Console.WriteLine(rebuildCencuredStringString);
            */


            //string[] correctCencoredString = buildCencuredString(userAllWordsSplitted, userSplittedWordFiltedAwayDotsReplacedWord);
            //Console.WriteLine("FDSFDSFDSFDSFDS");
            //printStringArray(correctCencoredString, "Cencor string string string");

            //Rubild string last
            //string rebuildCencuredStringString = string.Join(" ", userSplittedWordFiltedAwayDotsReplacedWord);

        }

        //Builds cencured string - including filtered characters
        private string[] buildCencuredStringsWithStars(string[] userOriginalInputSplitted, string[] userCencuredStringWithoutDots) 
        {
            
            /*
            if (".ugly".StartsWith("."))
                Console.WriteLine("It starts with .");
            */

            string[] newCencuredString = new string[userOriginalInputSplitted.Length];



            for (int i = 0; i < userCencuredStringWithoutDots.Length; i++) 
            {
                newCencuredString[i] = userCencuredStringWithoutDots[i];

                //Contains a filter character - Make sure to add it
                if (userCencuredStringWithoutDots[i].Contains("*"))
                {
                    
                    
                }
            }

            return newCencuredString;
        }
        

        

        private void printStringArray(string[] arrayToPrint, string title) 
        {
            Console.WriteLine(title);

            foreach (string item in arrayToPrint) 
            {
                Console.WriteLine(item);            
            }
            Console.WriteLine();
        }

        private bool IsSwearWord(string prospectSwearWord, string[] swearWords) 
        {
            for (int i = 0; i < swearWords.Length; i++) 
            {
                if (String.Equals(prospectSwearWord, swearWords[i])) 
                {
                    return true;
                }
            }

            return false;
        }

        private string GetNewCencuredWord(string badWord) 
        {
            char[] wordToBeCensured = badWord.ToCharArray();

            
            
            if (badWord.Length == 1)
            {
                return new string("*");
            }
            else if (badWord.Length == 2)
            {
                return new string("**");
            }
            else if (badWord.Length == 3)
            {
                return new string("***");
            }
            else if (badWord.Length == 4)
            {
                return new string("****");
            }
            //Five or more
            //if (badWord.Length >= 5)
            else
            {
                int indexInTheMiddle = (badWord.Length / 2);
                //Cencur word in the middle plus one in each side
                wordToBeCensured[indexInTheMiddle] = '*';
                wordToBeCensured[indexInTheMiddle - 1] = '*';
                wordToBeCensured[indexInTheMiddle + 1] = '*';
                return new string(wordToBeCensured);
            }
        }

        private string[] GetWordsWithoutMatchPattern(string[] listOfStringsWithUnwantedChars) 
        {
            //Trim off characters that match
            char[] charToChopOff = { '.', ',', ';', ':' };

            //At most
            string[] tempWordWithoutPattern = new string[listOfStringsWithUnwantedChars.Length];

            for (int i = 0; i < listOfStringsWithUnwantedChars.Length; i++) 
            {                
                string prospectOfBadWordWithDotComma = listOfStringsWithUnwantedChars[i];
                //This word trims of accourding to pattern defined in start of this method
                string formattedString = prospectOfBadWordWithDotComma.Trim(charToChopOff);
                tempWordWithoutPattern[i] = formattedString;
            }

            return tempWordWithoutPattern;











            //Characters to trim off
            //char[] charsToTrim = { '.', ',', ';' };
            //string text = "fult ord med trailing punkt. dum. ugly,";
            //Trims last word only
            //string formatedString = text.Trim(charsToTrim);
            //Console.WriteLine(formatedString);
        }

        public void Exercise23() 
        {
            Console.WriteLine("Exercise 23");

            Random rand = new Random();
            const int upperLimitNumber = 40;
            const int uniqueCount = 7;

            
            List<int> validNumbers = new List<int>(upperLimitNumber);
            for (int i = 0; i < validNumbers.Capacity; i++) 
            {
                validNumbers.Add(i + 1);
            }

            List<int> uniqueNumbers = new List<int>(uniqueCount);
            for (int i = 0; i < uniqueNumbers.Capacity; i++) 
            {
                //Randomize indexNumber for validNumber
                int randomizedIndex = rand.Next(0, validNumbers.Count);
                //Add the number
                uniqueNumbers.Add(validNumbers[randomizedIndex]);
                //Remove element at randomized index
                validNumbers.RemoveAt(randomizedIndex);
            }
          
            foreach (int itemInt in uniqueNumbers) 
            {
                Console.Write($"{itemInt} ");
            }
            Console.WriteLine();   
            

        }

        public void Exercise24() 
        {
            
            int[] deckOfCardsLeft = { 
                                1, 1, 1, 1,
                                2, 2, 2, 2,
                                3, 3, 3, 3,
                                4, 4, 4, 4,
                                5, 5, 5, 5,
                                6, 6, 6, 6,
                                7, 7, 7, 7,
                                8, 8, 8, 8,
                                9, 9, 9, 9,
                                10, 10, 10, 10,
                                11, 11, 11, 11,
                                12, 12, 12, 12,
                                13, 13, 13, 13
                                };

            int[] deckOfCardsRight = new int[0];                  

            bool keepRunning = true;
            int choice;

            while (keepRunning) 
            {
                Console.Clear();
                Console.WriteLine("The shuffle game");
                Console.WriteLine();
                PrintDeck(deckOfCardsLeft, "Left Deck of Cards");
                PrintDeck(deckOfCardsRight, "Right Deck of Card");
                Console.WriteLine();
                PrintMenuOption();
                choice = forceIntegerInput("Input an integer number");

                switch (choice) 
                {
                    case 1:
                        ShuffleCards(ref deckOfCardsLeft);
                        break;
                    case 2:
                        ShuffleCards(ref deckOfCardsRight);
                        break;
                    case 3:
                        if (deckOfCardsLeft.Length == 0)
                        {
                            Console.WriteLine("The left deck is empty");
                            Console.Write("Press any key");
                            Console.ReadKey();
                        }
                        else 
                        {
                            int cardNumberDrawnLeft = DrawCard(ref deckOfCardsLeft);
                            Console.WriteLine($"Drawn card [from deck LEFT] is: {cardNumberDrawnLeft}");
                            Console.Write("Press any key");
                            Console.ReadKey();
                            int indexOfRightDeck = deckOfCardsRight.Length;
                            Array.Resize(ref deckOfCardsRight, deckOfCardsRight.Length + 1);
                            deckOfCardsRight[indexOfRightDeck] = cardNumberDrawnLeft;
                            Array.Sort(deckOfCardsRight);
                        }                        
                        break;
                    case 4:
                        if (deckOfCardsRight.Length == 0)
                        {
                            Console.WriteLine("The right deck is empty");
                            Console.Write("Press any key");
                            Console.ReadKey();
                        }
                        else 
                        {
                            int cardNumberDrawnRight = DrawCard(ref deckOfCardsRight);
                            Console.WriteLine($"Drawn card [from deck RIGHT] is: {cardNumberDrawnRight}");
                            Console.Write("Press any key");
                            Console.ReadKey();
                            int indexOfLeftDeck = deckOfCardsLeft.Length;
                            Array.Resize(ref deckOfCardsLeft, deckOfCardsLeft.Length + 1);
                            deckOfCardsLeft[indexOfLeftDeck] = cardNumberDrawnRight;
                            Array.Sort(deckOfCardsRight);
                        }                        
                        break;
                    case 5:
                        keepRunning = false;
                        break;
                    default:
                        Console.WriteLine("Invalid input. Press enter to contine");
                        Console.ReadKey();
                        break;
                }
            }
        }
              
        static void PrintMenuOption() 
        {
                      
            Console.WriteLine("1. Shuffle Left Deck");
            Console.WriteLine("1. Shuffle Right Deck");
            Console.WriteLine("3. Draw Card (From left deck to right deck)");
            Console.WriteLine("4. Draw Card (From right deck to to deck)");
            Console.WriteLine("5. End shuffle game");
            Console.WriteLine();
            Console.WriteLine("Make a selection [Confirm with enter]");
        }      

        static void PrintDeck(int[] deck, string title) 
        {                        
                Console.WriteLine($"{title} {deck.Length} card(s)");
                Console.Write("[ ");
                foreach (int item in deck)
                {
                    if (item != 0) 
                    {
                        Console.Write($" {item}");
                    }                    
                }
                Console.WriteLine($" ]");            
            
        }

        static void ShuffleCards(ref int[] deck) 
        {
            Random random = new Random();
            int randomIndex;

            for (int i = 0; i < deck.Length; i++) 
            {
                randomIndex = i + random.Next(deck.Length - i);

                int tempValue = deck[randomIndex];
                deck[randomIndex] = deck[i];
                deck[i] = tempValue;
            }
        }

        //Make sure to store the popped value
        static int DrawCard(ref int[] deck) 
        {
            Random random = new Random();

            int randomIndexCardToDraw = random.Next(deck.Length);
            int lastIndexOfDeck = deck.Length - 1;

            int cardNumber = deck[randomIndexCardToDraw];

            //Swap value
            if (randomIndexCardToDraw != lastIndexOfDeck) 
            {
                int tempValue = deck[randomIndexCardToDraw];
                deck[randomIndexCardToDraw] = deck[lastIndexOfDeck];
                deck[lastIndexOfDeck] = tempValue;


            }
            //Index are equal - Doesnt matter which one is choosen
            else 
            {
            
            }
            // 'Removes' or 'chops off' the last element in the deck
            Array.Resize(ref deck, deck.Length - 1);
            //User friendly format
            Array.Sort(deck);

            // 'Pop' it of array
            return cardNumber;

        }

        public void Exercise25() 
        {
            Console.WriteLine("Exercise 25");
            int userValueOne = UserMustEnterAValidInteger();
            int userValueTwo = UserMustEnterAValidInteger();

            
            try
            {
                Console.WriteLine($"Division {userValueOne}/{userValueTwo}={userValueOne/userValueTwo}");    
            }
            catch (DivideByZeroException exp) 
            {
                Console.WriteLine("You cant divide with zero!!!");
            }
            
        }

        public static int UserMustEnterAValidInteger() 
        {
            bool integerFlag = false;
            //Console.WriteLine("Please enter a valid integer value");

            string userInput;// = Console.ReadLine();
            int intValue = 0;

            while (!integerFlag) 
            {
                Console.WriteLine("Please enter a valid integer value");
                userInput = Console.ReadLine();

                try
                {
                    intValue = int.Parse(userInput);
                    integerFlag = true;
                }
                catch (ArgumentNullException exp)
                {
                    Console.WriteLine($"Argument exception caught!! {exp.Message}");
                }
                catch (FormatException exp)
                {
                    Console.WriteLine($"Format exception caught!! {exp.Message}");
                }
                catch (OverflowException exp)
                {
                    Console.WriteLine($"Overflow exception caught!! {exp.Message}");
                }
            }

            return intValue;
        }

        public void Exercise26()
        {
            Console.WriteLine("Exercise 26");

            String myDocuments = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            String myPictures = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);
            String myProgramFiles86 = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFilesX86);
            String mycookies = Environment.GetFolderPath(Environment.SpecialFolder.Cookies);
            String myCurrentDirectory = Environment.CurrentDirectory;

            String myDesktop = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string filePath = myDesktop + "lexicon_in_tha_house.txt";
            var fileNamePath = @filePath;

            Console.WriteLine(myDocuments);
            Console.WriteLine(myPictures);
            Console.WriteLine(myProgramFiles86);
            Console.WriteLine(mycookies);
            Console.WriteLine(myCurrentDirectory);
            Console.WriteLine(myDesktop);

            byte[] dataAppendToFile;
            using (FileStream fs = File.Create(fileNamePath)) 
            {
                dataAppendToFile = new System.Text.UTF8Encoding(true).GetBytes(myDesktop);
                fs.Write(dataAppendToFile, 0, dataAppendToFile.Length);
            }
        }
    }
}
