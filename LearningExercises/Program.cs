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

/*
static void RunExercise01() 
{
    string firstName = "Daniel";
    string lastName = "Oikarainen";
    Console.WriteLine("Hello " + firstName + " " + lastName + "! I'm glad to inform you that you are the test subject of my very first assignmnet!");
    Console.WriteLine("Hello {0} {1} ", firstName, lastName);
    Console.WriteLine($"Hello again {firstName} {lastName}");
}


static void RunExercise02()
{
    Console.WriteLine("You successfully ran exercise two!");
}






static void exerciseTobias()
{
    //futur
    //conditionnal
    //passe compose

    // Parler           (first)
    //je parlerai
    //je parlerais
    //j'ai parl'e



    // Venir            (second)
    // Attendre         (third)

   
   
    string tenseChosen;
    string patternString = "123";
    do
    {
        Console.Clear();
        Console.WriteLine("Choose a verb tense from the list:");
        Console.WriteLine("1. futur (press 1)");
        Console.WriteLine("2. conditionnal (press 2)");
        Console.WriteLine("3. passe compose (press 3)");
        tenseChosen = Console.ReadKey().KeyChar.ToString();
    }
    //while (! (tenseChosen == "1" || tenseChosen == "2" || tenseChosen == "3"));    
    //while (!("123".Contains(tenseChosen)));
    while (!(patternString.Contains(tenseChosen)));






    Console.WriteLine();



    Console.WriteLine("Please enter a regular verb in french:");
    string enteredWord = Console.ReadLine();
    Console.WriteLine($"You wrote {enteredWord}");

    string verbKind = "";

    //Put in a separate function
    bool testFirst = enteredWord.EndsWith("er");
    bool testSecond = enteredWord.EndsWith("ir");
    bool testThird = enteredWord.EndsWith("re");

    if (testFirst)
    {
        verbKind = "the first";
    }
    else if (testSecond)
    {
        verbKind = "the second";
    }
    else if (testThird)
    {
        verbKind = "the third";
    }
    else
    {
        verbKind = "no";
    }
    // End put in a separate function


    Console.WriteLine($"The verb is of the {verbKind} kind");


    //SNYGGTTTT!!!
    string foo = "1";
    string verbTense = foo switch
    {
        "1" => "futur",
        "2" => "conditionnel",
        "3" => "passé composé",
    };
    
}
*/