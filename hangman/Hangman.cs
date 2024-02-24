
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
    public static string maskedWord;
    public static string guessedLetters = "";
    public static string guess;
    public static ConsoleKeyInfo pressedKey;
    public static int guesses = 0;

    public static void Main()
    {
        Init();
        Game();
    }

    private static void Init()
    {
        Console.Clear();
        Console.WriteLine("Welcome to Hangman!");
        Console.WriteLine("I'm thinking of a word. Can you guess it?");
        Random random = new Random();
        int randomIndex = random.Next(0, words.Length);
        word = words[randomIndex];
        maskedWord = new string('_', word.Length);
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
        Console.WriteLine("[Press any key to exit]");
        Console.ReadKey();
    }

    private static void inputkey()
    {
        Console.WriteLine("[Guess a letter]");
        pressedKey = Console.ReadKey();
        guess = pressedKey.KeyChar.ToString().ToLower();
    }

    private static void WriteLetters()
    {
        if (guess != " " && guess != ConsoleKey.Enter.ToString())
        {
            if (word.Contains(guess))
            {
                for (int i = 0; i < word.Length; i++)
                {
                    if (word[i].ToString()== guess)
                    {
                        maskedWord = maskedWord.Remove(i, 1).Insert(i, guess);
                    }
                }
            }
            else
            {
                if (guessedLetters.Contains(guess))
                {
                    alreadyGuessed = true;
                }
                else
                {
                    if (guessedLetters.Length > 0)
                    {
                        guessedLetters += ", " + guess;
                    }
                    else
                    {
                        guessedLetters += guess;
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
