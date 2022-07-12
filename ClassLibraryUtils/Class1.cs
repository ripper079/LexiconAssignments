namespace ClassLibraryUtils
{
    public class UtilsInput
    {
        public UtilsInput()
        {

        }        

        public static int GetLuckyNumber() 
        {
            return 999666;
        }

        //Before start with small letter
        public static int ForceIntegerInput(string title)
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

        //Before start with small letter
        public static double ForceDoubleInput(string title)
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

        public static bool ArrayContainsOnlyInts(String[] splittedArray)
        {            
            bool flagIntsOnly = true;
            foreach (String str in splittedArray)
            {
                if (! int.TryParse(str, out _))
                {
                    flagIntsOnly = false;
                    break;
                }
            }

            return flagIntsOnly;
        }
    }
}