using System;

namespace Unit02
{
    class Program
    {
        static void Main(string[] args)
        {
            PlayGame();
        }


        // this is to play the game. everything to play the game is run here and called in main.
        private static void PlayGame()
        {
            DealerAI NewDealer = new DealerAI();
            EnemyAI NewEnemy = new EnemyAI();
            Player NewPlayer = new Player();

            bool isPlaying = true;
            bool validPlayeGuess = false;
            bool arePlayerPointsDistributed = false;
            bool areEnemyPointsDistributed = false;
            bool isValidAnswer = false;
            string playerAnswer = "";
            string enemyAnswer = "";
            string playerInput = "";
            int ogDealerCardNumber = 0;
            int curDealerCardNumber = 0;
            int playerPoints = 300;
            int enemyPoints = 300;
            int curPlayerPoints;
            int curEnemyPoints;


            Console.Clear();
            Console.WriteLine("In this game, you must guess if the next card is higher or lower than the previous. You start with 300 points. First to 1000 points wins!");
            Console.WriteLine("");

            while(isPlaying)
            {

                NewDealer.DealCard();
                ogDealerCardNumber = NewDealer.GetCardNumber();
                NewDealer.AskForGuess();
                Console.Write(NewDealer.GetCardNumber());
                NewDealer.DealCard();
                curDealerCardNumber = NewDealer.GetCardNumber();

                while (curDealerCardNumber == ogDealerCardNumber)
                {
                    curDealerCardNumber = NewDealer.GetCardNumber();
                }

                Console.WriteLine("");

                NewEnemy.GuessCard();
                enemyAnswer = NewEnemy.GetAnswer();
                
                Console.WriteLine("");

                validPlayeGuess = false;
                while(!validPlayeGuess)
                { 
                    playerAnswer = NewPlayer.GetAnswer(); 
                    validPlayeGuess = NewPlayer.CheckLine(playerAnswer); 
                }

                Console.WriteLine("");

                Console.Write("The new card is: " + NewDealer.GetCardNumber());
                
                Console.WriteLine("");

                arePlayerPointsDistributed = false;
                areEnemyPointsDistributed = false;

                arePlayerPointsDistributed = CheckPlayerGuess(playerAnswer, ogDealerCardNumber, curDealerCardNumber);
                areEnemyPointsDistributed = CheckAIGuess(enemyAnswer, ogDealerCardNumber, curDealerCardNumber);

                switch(arePlayerPointsDistributed)
                {
                    case true:
                        playerPoints = AwardPoints(playerPoints);
                    break;
                    case false:
                        playerPoints = DeductPoints(playerPoints);
                    break;
                }

                switch(areEnemyPointsDistributed)
                {
                    case true:
                        enemyPoints = AwardPoints(enemyPoints);
                    break;
                    case false:
                        enemyPoints = DeductPoints(enemyPoints);
                    break;
                }

                curPlayerPoints = playerPoints;
                curEnemyPoints = enemyPoints;

                Console.Write("Player has " + curPlayerPoints + " points.");
                Console.WriteLine("");
                Console.Write("Player has " + curEnemyPoints + " points.");

                Console.WriteLine("");

                // check to see if someone wins
                if(curPlayerPoints >= 1000) {curPlayerPoints = 1000; Console.Write("Player Wins!");}
                else
                if(curPlayerPoints <= 0) {curPlayerPoints = 0; Console.Write("Player Loses!");}

                if(curEnemyPoints >= 1000) {curEnemyPoints = 1000; Console.Write("AI Wins!");}
                else
                if(curEnemyPoints <= 0) {curEnemyPoints = 0; Console.Write("AI Loses!");}

                Console.Write("Would you like to keep playing? 'y'/'n': ");

                isValidAnswer = false;
                while(!isValidAnswer){
                    playerInput = Console.ReadLine();

                    if (playerInput == "y"){ isValidAnswer = true; isPlaying = true; playerAnswer = ""; playerPoints = curPlayerPoints; enemyPoints = curEnemyPoints;}
                    else
                    if (playerInput == "n"){ isValidAnswer = true; isPlaying = false; Console.Write("Thanks for Playing!"); }
                    else
                    if (playerInput != "y" && playerInput != "n"){ isValidAnswer = false; Console.Write("Invalid input. Please enter either 'y' or 'n'"); }
                }

            }

        }

        private static bool CheckPlayerGuess(string pAnswer, int ogCardNumber, int curCardNumber)
        {
            string pGuessedAnswer = pAnswer;

            if (curCardNumber <=ogCardNumber) 
            {
                // switch statement for the player check
                switch(pAnswer)
                {
                    case "l":
                        Console.Write("Player is Correct!");
                        Console.WriteLine("");
                        return true;
                    break;
                    case "h":
                        Console.Write("Player is Incorrect!");
                        Console.WriteLine("");
                        return false;
                    break;
                }
            }
            else
            if (curCardNumber >= ogCardNumber) 
            {
                // switch statement for the player check
                switch(pAnswer)
                {
                    case "l":
                        Console.Write("Player is Incorrect!");
                        Console.WriteLine("");
                        return false;
                    break;
                    case "h":
                        Console.Write("Player is Correct!");
                        Console.WriteLine("");
                        return true;
                    break;
                }
            }
            return false;
        }
        private static bool CheckAIGuess(string eAnswer, int ogCardNumber, int curCardNumber)
        {
            string eGuessedAnswer = eAnswer;

            if (curCardNumber <=ogCardNumber) 
            {
                // switch statement for the enemy ai check
                switch(eAnswer)
                {
                    case "l":
                        Console.Write("AI is Correct!");
                        Console.WriteLine("");
                        return true;
                    break;
                    case "h":
                        Console.Write("AI is Incorrect!");
                        Console.WriteLine("");
                        return false;
                    break;
                }

            }
            else
            if (curCardNumber >= ogCardNumber) 
            {
                // switch statement for the enemy ai check
                switch(eAnswer)
                {
                    case "l":
                        Console.Write("AI is Incorrect!");
                        Console.WriteLine("");
                        return false;
                    break;
                    case "h":
                        Console.Write("AI is Correct!");
                        Console.WriteLine("");
                        return true;
                    break;
                }

            }

            return false;;
        }

        private static int AwardPoints(int points)
        {
            points = points += 100;
            return points;
        }

        private static int DeductPoints(int points)
        {
            return points = points -= 75;
        }




    }
}

// this is for the player class
class Player 
{

    string guessedNumber = "";
    
    // this is to get the input from the player
    public string GetAnswer()
    {
        Console.Write("Enter your guess: ");
        guessedNumber = Console.ReadLine();
        return guessedNumber;
    }

    // this is to do an internal check on the players input
    public bool CheckLine(string guess)
    {
        if (guess == "l"){ return true;}
        else
        if (guess == "h"){ return true;}
        else
        if (guess != "l" && guess != "h"){ Console.Write("Invalid Answer. Please type either 'l' or 'h'"); Console.WriteLine("");}
        return false;
    }

}

// this is for the enemy AI class
class EnemyAI 
{

    int guessedNumbner = 0;
    string guessedAnswer = "";

    Random rNumberGenerator = new Random();

    public void GuessCard()
    {
        guessedNumbner = rNumberGenerator.Next(1,3);
        guessedAnswer = GetGuessedNumber(guessedNumbner);
    }

    private string GetGuessedNumber(int gNumber)
    {
        string gAnswer = "";
        switch(gNumber)
        {
            case 1:
                gAnswer = "l";
                
            break;
            case 2:
                gAnswer = "h";
            break;
        }

        Console.Write("Opponent AI: My Guess is: " + gAnswer);
        return gAnswer;
    }

    public string GetAnswer()
    {
        return guessedAnswer;
    }

}

// this is for the Dealer AI class
class DealerAI
{

    int cardNumber = 1;
    Random rNumberGenerator = new Random();

    // this is to deal the next card
    public void DealCard()
    {
        cardNumber = rNumberGenerator.Next(1,13);
    }

    // this is to ask for a guess
    public void AskForGuess()
    {
        Console.Write("Can you guess if the next card is Higher or Lower? My current card is: ");
    }

    // this is to get the card number
    public int GetCardNumber(){
        return cardNumber;
    }

}



