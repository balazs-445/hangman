
namespace ConsoleApp1;


public class Hangman
{


    private static String[] words =
    {
        "cat", "dog", "repository", "hangman", "computer", "programming", "csharp", "visualstudio", "microsoft", "windows",
        "keyboard", "mouse", "monitor", "speaker", "headphones", "microphone", "camera", "printer", "scanner", "laptop",
        "desktop", "tablet", "smartphone", "smartwatch", "television", "remote", "controller", "console", "game",
        "internet", "network", "server", "cloud", "database", "software", "hardware" , "algorithm", "function", "variable",
        "constant", "class", "object", "method", "property", "event", "delegate", "interface", "namespace", "library",
        "assembly", "project", "solution", "file", "folder", "directory", "drive", "disk", "memory", "processor", "graphics",
        "sound", "video", "image", "text", "document", "spreadsheet", "presentation", "database", "table", "record", "field",
        "query", "report", "form", "macro", "module", "web", "page", "website", "webserver", "webbrowser",
        "python", "java", "javascript", "html", "css", "php", "ruby", "perl", "swift", "objective", "sql", 
         "notepad", "wordpad", "word", "excel", "powerpoint", "access", "outlook", "onenote", "publisher", 
        "google", "firefox", "chrome", "opera", "safari", "edge", "internetexplorer", "android", "ios", "windowsphone",
    };

    public static string word;
    public static bool alreadyGuessed = false;
    public static bool isMultiplayer;
    public static bool wrongWord = true;
    public static string maskedWord;
    public static string guessedLetters = "";
    public static string inputChar;
    public static ConsoleKeyInfo pressedKey;
    public static int guesses = 0;

    public static void Main()
    {
        Init();
        Game();
        inputChar = "";
        while (inputChar != "r" && inputChar != ConsoleKey.Enter.ToString())
        {
            
        }
        Console.WriteLine("[Press 'r' to restart or any enter to exit]");
        inputChar = Console.ReadKey().KeyChar.ToString().ToLower();
        if (inputChar == "r")
        {
            Main();
        }
    }

    private static void Init()
    {
        guessedLetters = "";
        guesses = 0;
        wrongWord = true;
        Console.Clear();
        Console.WriteLine("Welcome to Hangman!");
        Console.WriteLine("Do you want to play multiplayer? (y/n)");
        inputChar = Console.ReadKey().KeyChar.ToString().ToLower();
        while (inputChar != "y" && inputChar != "n")
        {
            Console.WriteLine("Invalid input! Please enter 'y' or 'n'!");
            inputChar = Console.ReadKey().KeyChar.ToString().ToLower();
        }
        if (inputChar == "y")
        {
            isMultiplayer = true;
        }
        if (isMultiplayer)
        {
            Console.Clear();
            Console.WriteLine("Player 1, please enter a word for Player 2 to guess:");
            word = Console.ReadLine().ToLower();
            while (wrongWord)
            {
                for (int i = 0; i < word.Length; i++)
                {
                    inputChar = word[i].ToString().ToLower();
                    if (inputChar == "a" || inputChar == "á" || inputChar == "b" || inputChar == "c" || inputChar == "d" || inputChar == "e" ||
                        inputChar == "é" || inputChar == "f" || inputChar == "g" || inputChar == "h" || inputChar == "i" || inputChar == "í" ||
                        inputChar == "j" || inputChar == "k" || inputChar == "l" || inputChar == "m" || inputChar == "n" || inputChar == "o" ||
                        inputChar == "ó" || inputChar == "ö" || inputChar == "ő" || inputChar == "p" || inputChar == "q" || inputChar == "r" ||
                        inputChar == "s" || inputChar == "t" || inputChar == "u" || inputChar == "ú" || inputChar == "ü" || inputChar == "ű" ||
                        inputChar == "v" || inputChar == "w" || inputChar == "x" || inputChar == "y" || inputChar == "z")
                    {
                        wrongWord = false;
                    }
                    else
                    {
                        wrongWord = true;
                        break;
                    }
                }
                if (wrongWord)
                {
                    Console.WriteLine("Invalid word! Please enter a correct word!");
                    word = Console.ReadLine().ToLower();
                }
            }
            maskedWord = new string('_', word.Length);
        }
        else
        {
            Console.Clear();
            Console.WriteLine("Than you play aganist the computer!");
            Console.WriteLine("I'm thinking of a word. Can you guess it?");
            Random random = new Random();
            int randomIndex = random.Next(0, words.Length);
            word = words[randomIndex];
            maskedWord = new string('_', word.Length);
        }
        Console.WriteLine("[Press any key to continue]");
        Console.ReadKey();
        Console.Clear();
    }

    private static void Game()
    {
        while (word != maskedWord)
        {
            RefreshScreen();
            inputkey();
            WriteLetters();
        }
        RefreshScreen();
    }

    private static void inputkey()
    {
        Console.WriteLine("[Guess a letter]");
        pressedKey = Console.ReadKey();
        inputChar = pressedKey.KeyChar.ToString().ToLower();
    }

    private static void WriteLetters()
    {
        if (inputChar == "a" || inputChar == "á" || inputChar == "b" || inputChar == "c" || inputChar == "d" || inputChar == "e" ||
            inputChar == "é" || inputChar == "f" || inputChar == "g" || inputChar == "h" || inputChar == "i" || inputChar == "í" ||
            inputChar == "j" || inputChar == "k" || inputChar == "l" || inputChar == "m" || inputChar == "n" || inputChar == "o" ||
            inputChar == "ó" || inputChar == "ö" || inputChar == "ő" || inputChar == "p" || inputChar == "q" || inputChar == "r" ||
            inputChar == "s" || inputChar == "t" || inputChar == "u" || inputChar == "ú" || inputChar == "ü" || inputChar == "ű" ||
            inputChar == "v" || inputChar == "w" || inputChar == "x" || inputChar == "y" || inputChar == "z")
        {
            if (word.Contains(inputChar))
            {
                for (int i = 0; i < word.Length; i++)
                {
                    if (word[i].ToString()== inputChar)
                    {
                        maskedWord = maskedWord.Remove(i, 1).Insert(i, inputChar);
                    }
                }
            }
            else
            {
                if (guessedLetters.Contains(inputChar))
                {
                    alreadyGuessed = true;
                }
                else
                {
                    if (guessedLetters.Length > 0)
                    {
                        guessedLetters += ", " + inputChar;
                    }
                    else
                    {
                        guessedLetters += inputChar;
                    }
                    guesses++;
                }
            }
        }
    }

    private static void RefreshScreen()
    {
        Console.Clear();
        Console.WriteLine(maskedWord);
        Console.WriteLine("Wrong guesses: " + guesses);
        Console.WriteLine("Guessed letters: " + guessedLetters);
        if (alreadyGuessed)
        {
            Console.WriteLine("You already guessed that letter!");
            alreadyGuessed = false;
        }
        if (word == maskedWord)
        {
            Console.WriteLine("Congratulations! You guessed the word!");
        }
    }
}
