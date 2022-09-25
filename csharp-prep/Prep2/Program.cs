using System;

namespace Prep2
{
    class Program
    {
        static void Main(string[] args)
        {
            int guessedNumber = 0;
            int correctNumber = 0;
            string playerInput = "";
            bool isPlaying = true;
            bool isCorrect = false;
            bool didWin = false;

            StartGame();
            correctNumber = GetRandomNumber();

            while(isPlaying)
            {
                // we will leave this here in case we need to debug anything
                //Console.Write(correctNumber);
                Console.Write("\n");

                guessedNumber = GetGuessedNumber();
                Console.Write("\n");

                isCorrect = CheckForNumber(guessedNumber, correctNumber);
                Console.Write("\n");

                switch (isCorrect)
                {
                    case true:
                        Console.Write("You are correct!");
                        didWin = true;
                        Console.Write("\n");
                    break;

                    case false:
                        if (guessedNumber > correctNumber){ Console.Write("Too High!"); Console.Write("\n");}
                            else
                        if (guessedNumber < correctNumber){ Console.Write("Too Low!"); Console.Write("\n");}
                    break;
                }

                // we then check if the player has won. If not, the player starts from the loop again
                if (didWin)
                {
                    Console.Write("Would you like to keep playing? (y/n)");
                    Console.Write("\n");
                    playerInput = GetUserInput();
                    // if the player wants to play again, we change the number, and we set the guessed number back to 0. We then call our StartGame() function
                    if (playerInput == "y"){ isPlaying = true; correctNumber = GetRandomNumber(); guessedNumber = 0; StartGame(); didWin = false; }
                        else
                    if (playerInput == "n"){ isPlaying = false; Console.Write("Thanks for Playing!"); }
                        else // if the input is incorrect, we ask the player to please type in either a yes or no.
                    if (playerInput != "y" && playerInput != "n"){ Console.Write("Please enter 'y' for Yes or 'n' for No"); Console.Write("\n");}
                }
           }

        }

        private static void StartGame()
        {
            // we clear the console and then show the starting message
            Console.Clear();
            Console.Write("Hello Player! Can you guess my number? Type your number below to guess!");
        }

        private static bool CheckForNumber(int guessedNum, int correctNum)
        {
            if (guessedNum == correctNum)
            {
                return true;
            }
            return false;
        }

        private static int GetGuessedNumber()
        {
            int guessedNum = int.Parse(Console.ReadLine());
            return guessedNum;
        }

        private static string GetUserInput()
        {
            string userInput = Console.ReadLine();
            return userInput;
        }

        private static int GetRandomNumber()
        {
            Random rnGenerator = new Random();
            int randomNum = rnGenerator.Next(1, 11);

            return randomNum;
        }

    }
}
