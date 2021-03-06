using LearningExercises;


AllExercises mySolutions = new AllExercises();


var keepAlive = true;
while (keepAlive)
{
    try
    {
        Console.Write("Enter assignment number (or -1 to exit): ");
        var assignmentChoice = int.Parse(Console.ReadLine() ?? "");
        Console.ForegroundColor = ConsoleColor.Green;

        switch (assignmentChoice)
        {
            case 1:
                mySolutions.Exercise01();
                break;
            case 2:
                mySolutions.Exercise02();
                break;
            case 3:
                mySolutions.Exercise03();
                break;
            case 4:
                mySolutions.Exercise04();
                break;
            case 5:
                mySolutions.Exercise05();
                break;
            case 6:
                mySolutions.Exercise06();
                break;
            case 7:
                mySolutions.Exercise07();
                break;
            case 8:
                mySolutions.Exercise08();
                break;
            case 9:
                mySolutions.Exercise09();
                break;
            case 10:
                mySolutions.Exercise10();
                break;
            case 11:
                mySolutions.Exercise11();
                break;
            case 12:
                mySolutions.Exercise12();
                break;
            case 13:
                mySolutions.Exercise13();
                break;
            case 14:
                mySolutions.Exercise14();
                break;
            case 15:
                mySolutions.Exercise15();
                break;
            case 16:
                mySolutions.Exercise16();
                break;
            case 17:
                mySolutions.Exercise17();
                break;
            case 18:
                mySolutions.Exercise18();
                break;
            case 19:
                mySolutions.Exercise19();
                break;
            case 20:
                mySolutions.Exercise20();
                break;
            case 21:
                mySolutions.Exercise21();
                break;
            case 22:
                mySolutions.Exercise22();
                break;
            case 23:
                mySolutions.Exercise23();
                break;
            case 24:
                mySolutions.Exercise24();
                break;
            case 25:
                mySolutions.Exercise25();
                break;
            case 26:
                mySolutions.Exercise26();
                break;
            case 99:
                
                break;
            case -1:
                keepAlive = false;
                break;
            default:
                Console.ForegroundColor = ConsoleColor.Red;
                break;
        }

        Console.ResetColor();
        Console.WriteLine("Hit any key to continue!");
        Console.ReadKey();
        Console.Clear();
    }

    catch 
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("That is not a valid assignment number!");
        Console.ResetColor();
    }
}
