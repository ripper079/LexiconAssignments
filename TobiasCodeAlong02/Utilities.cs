using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace TobiasCodeAlong02
{
    public class Utilities
    {
        public Utilities()
        {

        }

        public static List<string> DiscardWords(string[] words)
        {
            //----------------------------------

            //Discard words of no interest
            List<string> chosenWords = new();

            bool satisfied = false;
            while (!satisfied)
            {
                foreach (string word in words)
                {
                    Clear();
                    WriteLine($"Discard {word} with 'y' (keep with all other keys)");
                    WriteLine(word);
                    char keyDiscard = ReadKey().KeyChar;
                    if (keyDiscard != 'y')
                    {
                        chosenWords.Add(word);
                    }
                }

                Clear();
                foreach (string word in chosenWords)
                {
                    WriteLine(word);
                }
                WriteLine("Are you satisfied with the selection? (y / n)");
                char keySatisfied = ReadKey().KeyChar;
                if (keySatisfied == 'y')
                {
                    satisfied = true;
                    Clear();
                }
            }
            return chosenWords;

        }

        public static Dictionary<string, string> WordsToDictionary(List<string> chosenWords)
        {
            Dictionary<string, string> glossary = new Dictionary<string, string>();

            foreach (String word in chosenWords) 
            {
                WriteLine($"Enter a swedish translation for '{word}' Skip word with straight 'enter'");
                string? translation = ReadLine();

                if (translation != null)
                {
                    glossary.Add($"{word}", $"{translation}");
                }
                else 
                {
                    glossary.Add($"{word}", $"_");
                }
            }

            return glossary;
        }

        public static void ReadAllPosts(Dictionary<string,string> glossary) 
        {
            Clear();
            WriteLine("Glossary");
            foreach (KeyValuePair<string, string> word in glossary)
            {
                Console.WriteLine($"{word.Key}: {word.Value}");
            }
            ReadKey();
            Clear();
        }

        public static Dictionary<string, string> EnterTranslation(Dictionary<string, string> glossary) 
        {
            var englishWords = glossary.Keys;
            Dictionary<int, string> pairing = new();
            int indexValue = 0;
            foreach (var item in englishWords)
            {
                if (glossary[item] == "_") 
                {
                    pairing.Add(++indexValue, item);
                }
                
            }

            foreach (var item in pairing) 
            {
                WriteLine($"{item.Key}. {item.Value}");
            }

            char wordToEnter = ReadKey().KeyChar;
            int number = wordToEnter;

            glossary[pairing[number]] = ReadLine();


            return glossary;
        }
    }


}
