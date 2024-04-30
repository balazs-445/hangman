
namespace ConsoleApp1;

public class GModule
{
    public static void DrawHangman(int wrongGuesses)
    {
       
        string[] hangmanArt = new string[11];

        hangmanArt[1] = @"






            =========";

        hangmanArt[2] = @"
                   
                  |
                  |
                  |
                  |
                  |
            =========";

        hangmanArt[3] = @"
             ======
                 \|
                  |
                  |
                  |
                  |
            =========";

        hangmanArt[4] = @"
             =+====
              |  \|
                  |
                  |
                  |
                  |
            =========";

        hangmanArt[5] = @"
             =+====
              |  \|
              O   |
                  |
                  |
                  |
            =========";

        hangmanArt[6] = @"
             =+====
              |  \|
              O   |
              |   |
                  |
                  |
            =========";

        hangmanArt[7] = @"
             =+====
              |  \|
              O   |
             /|   |
                  |
                  |
            =========";

        hangmanArt[8] = @"
             =+====
              |  \|
              O   |
             /|\  |
                  |
                  |
            =========";

        hangmanArt[9] = @"
             =+====
              |  \|
              O   |
             /|\  |
             /    |
                  |
            =========";

        hangmanArt[10] = @"
             =+====
              |  \|
              O   |
             /|\  |
             / \  |
                  |
            =========";
        Console.WriteLine(hangmanArt[wrongGuesses]);
    }
}
// You can display the hangman art based on the number of incorrect guesses
//Console.WriteLine(hangmanArt[guesses]);