//using TobiasCodeAlong02;
using static TobiasCodeAlong02.BaseText;
using static TobiasCodeAlong02.Utilities;
using static System.Console;

Console.WriteLine("Hello, Tobias!");

string text = getBaseText();

//Get text and split into words
string[] completeWords = getBaseText().Split(' ');
//Discard words of no interest
List<string> chosenWords = DiscardWords(completeWords);
//Add words to dictionary
Dictionary<string, string> glossary = WordsToDictionary(chosenWords);

// Work with dictionary
// 1. Get dictionary
// 2. Enter translation
// 3. Improve translation 

WriteLine("Work with dictionary");
WriteLine("1. Read all posts");
WriteLine("2. Enter translation");
WriteLine("3. Improve translation");

char choice = ReadKey().KeyChar;
switch (choice)
{
    case '1': ReadAllPosts();
    break;

    case '2': EnterTranslation();
    break;

    case '3': EnterTranslation();
    break;

}





// Begin adding translations

