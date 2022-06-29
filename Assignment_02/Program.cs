using System.Text;

//Enable cheat mode - displays secretWord on startup
const bool cheatMode = false;

//Constants
const int MaxUserGuesses = 10;
//Better put in 'base' folder of project - Works in debug and release mode
const string FileNameProspects = "../../../prospectwords.txt";

//Loads from seperate file
String[] prospectsSecretWord = LoadFromFileProspectWords();
//Hard coded in source file
//String[] prospectsSecretWord = new string[] { "fotball", "meatballs", "computer", "vacation", "neighbor" };

char[] secretWord = GenerateCharLetters();

//The word that is displayed to the user
char[] hiddenCorrectWord = new char[secretWord.Length];
for (int i = 0; i < hiddenCorrectWord.Length; i++)
    hiddenCorrectWord[i] = '_';

StringBuilder userIncorrectLetters = new StringBuilder(MaxUserGuesses);

//Counters
int countUserGuessess = 0;

//Flags
bool gameAlive = true;
bool correctGuessed = false;

//For 'debugging'
if (cheatMode)
    PrintSecretWord();

// Start the game
EnterGame();



/*
    Matcher functions to obtain guessing status
                    |
                    v
*/

// "Generic" matcher for guessed word (against secret word)
bool CheckForMatchAgainstSecretWord(char[] prospectWord)
{
    bool isTheUserCorrectInGuessing = secretWord.SequenceEqual(prospectWord);

    if (isTheUserCorrectInGuessing)
        correctGuessed = true;

    return isTheUserCorrectInGuessing;
}

bool CheckIfLastCharWasInserted()
{
    bool anyMatchWithOneChar = false;

    if (userIncorrectLetters.Length > 0)
    {
        //Get last inserted character
        char lastCharInserted = userIncorrectLetters[userIncorrectLetters.Length - 1];

        for (int i = 0; i < secretWord.Length; i++)
        {
            if (secretWord[i] == lastCharInserted)
            {
                anyMatchWithOneChar = true;
                break;
            }
        }
    }

    return anyMatchWithOneChar;
}



/*
    Helper functions for formatted printing
                    |
                    v     
*/

void PrintMainScreen()
{
    Console.WriteLine("Welcome to Hangman. Save the poor man by guessing the right word[Press any key to enter game]");
    Console.ReadKey();
    Console.Clear();
}

void PrintSecretWord()
{
    Console.WriteLine("Secret word");
    Console.Write("|");
    foreach (char aLetter in secretWord)
        Console.Write(aLetter);
    Console.WriteLine("|");
    Console.WriteLine();
}

void PrintHiddenWord() 
{
    Console.WriteLine($"Hidden word - {secretWord.Length} characters [{MaxUserGuesses - countUserGuessess} guess(es) left]");
    Console.Write("|");
    foreach (char aLetter in hiddenCorrectWord)
        Console.Write(" " + aLetter + " ");
    Console.WriteLine("|");
}

void PrintIncorrectGuesses() 
{
    Console.WriteLine("Letters already guessed");
    Console.Write("|");
    Console.Write(userIncorrectLetters);
    Console.WriteLine("|");
    Console.WriteLine();
}

void PrintCountUserGuessess() 
{
    //Console.WriteLine("Time(s) you have guessed - aka Incorrect guesses");
    Console.WriteLine("Incorrect guesses count");
    Console.Write("|");
    Console.Write(countUserGuessess);
    Console.WriteLine("|");
    Console.WriteLine();
}

void PrintWinningText() 
{
    Console.ForegroundColor = ConsoleColor.Green;
    Console.WriteLine("Nice guessed, you got it right!");
    Console.WriteLine("You are a big HERO and saved the poor man from being hanged!!!");
    Console.ForegroundColor = ConsoleColor.White;
}

void PrintLoserText() 
{
    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine("Game over! He got hanged HIGH!!!");
    Console.WriteLine($"You used up all {countUserGuessess} guesses!");
    Console.WriteLine("The correct word was:");
    Console.ForegroundColor = ConsoleColor.Green;
    foreach (char aLetter in secretWord)
        Console.Write(aLetter);
    Console.WriteLine();
    Console.ForegroundColor = ConsoleColor.White;
}



/*
                User inputs
                    |
                    v
 */

//Returns true if letter was inserted in stringbuilder aka userIncorrectLetters
//bool UserGuessALetter() 
bool UserInputGuessALetter()
{    
    bool insertedLetterIntoStringBuilder = false;
    bool dublicateLetter = false;
    Console.WriteLine("Guess a letter");
    char userSingleLetterGuess = Console.ReadKey().KeyChar;
    Console.WriteLine();

    //Force a letter
    while (! Char.IsLetter(userSingleLetterGuess)) 
    {
        Console.WriteLine("Only letter accepted! Guess a LETTER");
        userSingleLetterGuess = Console.ReadKey().KeyChar;
        Console.WriteLine();
    }

    //Make it uppercase
    userSingleLetterGuess = Char.ToUpper(userSingleLetterGuess);

    //Make error check do avoid duplicates
    //Check userSingleLetterGuess against userGuessedLetters
    for (int i = 0; i < userIncorrectLetters.Length; i++) 
    {
        if (userSingleLetterGuess == userIncorrectLetters[i]) 
        {
            dublicateLetter = true;
            break;
        }            
    }

    // The letter has already been guessed
    if (dublicateLetter)
    {
        Console.WriteLine($"You have already guessed this letter [{userSingleLetterGuess}]");
    }    
    else 
    {
        userIncorrectLetters.Append(userSingleLetterGuess);
        insertedLetterIntoStringBuilder = true;        
    }

    return insertedLetterIntoStringBuilder;
}

//Returns true if correct word otherwise false
bool UserInputGuessesAWord()
{
    Console.WriteLine("Guess what word you think it is:");
    string wordUserGuesses = Console.ReadLine();
    wordUserGuesses = wordUserGuesses.ToUpper();

    bool userGuessedCorrect = CheckForMatchAgainstSecretWord(wordUserGuesses.ToCharArray());

    //copy the whole array for proper display
    if (userGuessedCorrect) 
    {
        for (int i = 0; i < hiddenCorrectWord.Length; i++)
            hiddenCorrectWord[i] = secretWord[i];
    }

    return userGuessedCorrect;
}

// Returns 1 for  single letter; 2 for word; (Candidate for Enum maybe?)
int UserInputOneLetterOrWordChoice()
{
    int validatedNumber = 1;

    bool oneOrTwoSelecion = false;

    while (!oneOrTwoSelecion)
    {
        Console.WriteLine("Guess word or letter?");
        Console.WriteLine("1. Letter");
        Console.WriteLine("2. Word");
        Console.WriteLine("Pick a selection[Confirm with enter]");
        var numbAsString = Console.ReadLine();

        //Force a number
        while (!int.TryParse(numbAsString, out validatedNumber))
        {
            Console.WriteLine();
            Console.WriteLine("That's not a number. ");
            Console.WriteLine("Guess word or letter?");
            Console.WriteLine("1. Letter");
            Console.WriteLine("2. Word");
            Console.WriteLine("Pick a selection of 1 or 2[Confirm with enter]");
            numbAsString = Console.ReadLine();
        }

        //Now validatedNumber is a valid int number
        //Now force 1 or 2
        if (validatedNumber == 1 || validatedNumber == 2)
            oneOrTwoSelecion = true;
        else
        {
            Console.WriteLine($"The number {validatedNumber} is not a valid selection. Lets try again...");
            Console.WriteLine();
        }
    }

    return validatedNumber;
}



/*
    Main entry function - Meny selection
                    |
                    v
*/

void EnterGame()
{
    PrintMainScreen();
    Console.Clear();
    PrintHiddenWord();
    PrintCountUserGuessess();
    PrintIncorrectGuesses();

    while (gameAlive)
    {
        //Implement choice for guess one letter OR whole word
        int userChoiceCharOrWord = UserInputOneLetterOrWordChoice();

        //Selection - Letter 
        if (userChoiceCharOrWord == 1)
        {
            //User guessed a 'valid' character
            if (UserInputGuessALetter())
            {
                //Update hiddenWord
                UpdateHiddenCorrectWord();

                //Only update if previous guess not found in secret word
                if (!CheckIfLastCharWasInserted())
                    countUserGuessess++;

                //Check if user has correct build up word
                //checkCorrectGuessedWord();
                CheckForMatchAgainstSecretWord(hiddenCorrectWord);
            }
            else
            {
                Console.WriteLine("Don't guess the same letter");
            }
        }
        // Selection - Word 
        else if (userChoiceCharOrWord == 2)
        {
            //Update counter on wrong guess word
            if (!UserInputGuessesAWord())
                countUserGuessess++;
        }

        // PickOneLetterOrWordChoice() enforces this
        else
        {
            Console.WriteLine("THIS SHOULD BE UNREACHABLE CODE");
        }


        //Quit game if - Maximum guesses used OR if correct word guessed        
        if (countUserGuessess == MaxUserGuesses || correctGuessed)
        {
            gameAlive = false;
        }
        Console.Clear();
        PrintHiddenWord();
        PrintCountUserGuessess();
        PrintIncorrectGuesses();
    }

    if (countUserGuessess == MaxUserGuesses)
        PrintLoserText();

    if (correctGuessed)
        PrintWinningText();

}



/*
            Misc functions
                    |
                    v
*/

//Checks the whole word and flips all '_' to  matched character
void UpdateHiddenCorrectWord()
{
    for (int i = 0; i < secretWord.Length; i++)
    {
        for (int j = 0; j < userIncorrectLetters.Length; j++)
        {
            if (userIncorrectLetters[j] == secretWord[i])
            {
                hiddenCorrectWord[i] = userIncorrectLetters[j];
            }
        }
    }
}

// Generates a "random" char[] -  (Code requirement 1)
char[] GenerateCharLetters()
{
    //Choose seed, based on time
    int seed = DateTime.Now.Millisecond;

    Random random = new Random(seed);
    int randomIndex = random.Next(prospectsSecretWord.Length);

    return (prospectsSecretWord[randomIndex]).ToUpper().ToCharArray();
}


//string[] OpenFileAndLoadWordsIntoprospectsSecretWord()
string[] LoadFromFileProspectWords()
{
    var fileStream = File.OpenText(FileNameProspects);
    String oneLinerInFile = fileStream.ReadLine();    
    String[] splittedWords = oneLinerInFile.Split(",");    
    fileStream.Close();
    return splittedWords;
}

