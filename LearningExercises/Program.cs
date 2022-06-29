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

                break;
            case 12:

                break;
            case 13:

                break;
            case 14:

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
