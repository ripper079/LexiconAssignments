namespace ClassLibraryUtils
{
    public class UtilsInput
    {
        public UtilsInput()
        {

        }        

        public static int GetLuckyNumber() 
        {
            return 999;
        }

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

        static double forceDoubleInput(string title)
        {
            Console.WriteLine(title);
            var numbAsString = Console.ReadLine();
            double validatedNumber;

            while (!double.TryParse(numbAsString, out validatedNumber))
            {
                Console.WriteLine("That not a number. " + title);
                numbAsString = Console.ReadLine();
            }

            return validatedNumber;
        }
    }
}