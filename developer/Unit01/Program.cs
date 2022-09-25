using System;

namespace Unit01
{
    class Program
    {
        static void Main(string[] args)
        {
            bool isGameOver = false;
            bool playerTurn = true;
            string playerInput = "";

            string[] row_one = {"1", "2", "3"};
            string[] row_two = {"4", "5", "6"};
            string[] row_three = {"7", "8", "9"};


            Console.Clear();

            Console.Write(row_one[0] + "|" + row_one[1] + "|" + row_one[2]);
            Console.WriteLine("");
            Console.Write(row_two[0] + "|" + row_two[1] + "|" + row_two[2]);
            Console.WriteLine("");
            Console.Write(row_three[0] + "|" + row_three[1] + "|" + row_three[2]);
            
            while (!isGameOver)
            {
               
                switch(playerTurn)
                {
                    case true:
                        Console.WriteLine("");
                        Console.WriteLine("Player One! Where you will place an 'X'?");
                        playerInput = "";
                        playerInput = Console.ReadLine();
                        playerTurn = Player1Turn(row_one, row_two, row_three, playerInput);

                        Console.Write(row_one[0] + "|" + row_one[1] + "|" + row_one[2]);
                        Console.WriteLine("");
                        Console.Write(row_two[0] + "|" + row_two[1] + "|" + row_two[2]);
                        Console.WriteLine("");
                        Console.Write(row_three[0] + "|" + row_three[1] + "|" + row_three[2]);

                    break;

                    case false:
                        Console.WriteLine("");
                        Console.WriteLine("Player Two! Where you will place an 'O'?");
                        playerInput = "";
                        playerInput = Console.ReadLine();
                        playerTurn = Player2Turn(row_one, row_two, row_three, playerInput);

                        Console.Write(row_one[0] + "|" + row_one[1] + "|" + row_one[2]);
                        Console.WriteLine("");
                        Console.Write(row_two[0] + "|" + row_two[1] + "|" + row_two[2]);
                        Console.WriteLine("");
                        Console.Write(row_three[0] + "|" + row_three[1] + "|" + row_three[2]);

                    break;
                }
                Console.WriteLine("");
                isGameOver = CheckWin(row_one, row_two, row_three);
            }
        }

    

        private static bool Player1Turn(string[] row_one, string[] row_two, string[] row_three, string input)
        {
                bool isValid = false;
                switch(input)
                {
                    // row 1
                    case "1":
                        if( row_one[0] == "1" ){ row_one[0] = "X"; isValid = false;}
                            else
                        { Console.WriteLine("Invalid Option. Please select another."); isValid = true;}
                        break;
                    case "2":
                        if( row_one[1] == "2" ){ row_one[1] = "X"; isValid = false;}
                            else
                        { Console.WriteLine("Invalid Option. Please select another."); isValid = true;}
                        break;
                    case "3":
                        if( row_one[2] == "3" ){ row_one[2] = "X"; isValid = false;}
                            else
                        { Console.WriteLine("Invalid Option. Please select another."); isValid = true;}
                        break;
                    // end of row 1
                    // row 2
                    case "4":
                        if( row_two[0] == "4" ){ row_two[0] = "X"; isValid = false;}
                            else
                        { Console.WriteLine("Invalid Option. Please select another."); isValid = true;}
                        break;
                    case "5":
                        if( row_two[1] == "5" ){ row_two[1] = "X"; isValid = false;}
                            else
                        { Console.WriteLine("Invalid Option. Please select another."); isValid = true;}
                        break;
                    case "6":
                        if( row_two[2] == "6" ){ row_two[2] = "X"; isValid = false;}
                            else
                        { Console.WriteLine("Invalid Option. Please select another."); isValid = true;}
                        break;
                    // end of row 2
                    // row 3
                    case "7":
                        if( row_three[0] == "7" ){ row_three[0] = "X"; isValid = false;}
                            else
                        { Console.WriteLine("Invalid Option. Please select another."); isValid = true;}
                        break;
                    case "8":
                        if( row_three[1] == "8" ){ row_three[1] = "X"; isValid = false;}
                            else
                        { Console.WriteLine("Invalid Option. Please select another."); isValid = true;}
                        break;
                    case "9":
                        if( row_three[2] == "9" ){ row_three[2] = "X"; isValid = false;}
                            else
                        { Console.WriteLine("Invalid Option. Please select another."); isValid = true;}
                        break;
                    // end of row 3

                }
                return isValid;

        }



        private static bool Player2Turn(string[] row_one, string[] row_two, string[] row_three, string input)
        {

                bool isValid = false;
                switch(input)
                {
                    // row 1
                    case "1":
                        if( row_one[0] == "1" ){ row_one[0] = "O"; isValid = true;}
                            else
                        { Console.WriteLine("Invalid Option. Please select another."); isValid = false;}
                        break;
                    case "2":
                        if( row_one[1] == "2" ){ row_one[1] = "O"; isValid = true;}
                            else
                        { Console.WriteLine("Invalid Option. Please select another."); isValid = false;}
                        break;
                    case "3":
                        if( row_one[2] == "3" ){ row_one[2] = "O"; isValid = true;;}
                            else
                        { Console.WriteLine("Invalid Option. Please select another."); isValid = false;}
                        break;
                    // end of row 0
                    // row 2
                    case "4":
                        if( row_two[0] == "4" ){ row_two[0] = "O"; isValid = true;;}
                            else
                        { Console.WriteLine("Invalid Option. Please select another."); isValid = false;}
                        break;
                    case "5":
                        if( row_two[1] == "5" ){ row_two[1] = "O"; isValid = true;;}
                            else
                        { Console.WriteLine("Invalid Option. Please select another."); isValid = false;}
                        break;
                    case "6":
                        if( row_two[2] == "6" ){ row_two[2] = "O"; isValid = true;;}
                            else
                        { Console.WriteLine("Invalid Option. Please select another."); isValid = false;}
                        break;
                    // end of row 1
                    // row 2
                    case "7":
                        if( row_three[0] == "7" ){ row_three[0] = "O"; isValid = true;;}
                            else
                        { Console.WriteLine("Invalid Option. Please select another."); isValid = false;}
                        break;
                    case "8":
                        if( row_three[1] == "8" ){ row_three[1] = "O"; isValid = true;;}
                            else
                        { Console.WriteLine("Invalid Option. Please select another."); isValid = false;}
                        break;
                    case "9":
                        if( row_three[2] == "9" ){ row_three[2] = "O"; isValid = true;;}
                            else
                        { Console.WriteLine("Invalid Option. Please select another."); isValid = false;}
                        break;
                    // end of row 3
                }
                return isValid;
        }

        private static bool CheckWin(string[] row_one, string[] row_two, string[] row_three)
        {
            bool gameOver = false;
            
            if (row_one[0] == "X" && row_one[1] == "X" && row_one[2] == "X"){ gameOver = true; Console.WriteLine("Player One Wins!"); }
            else
            if (row_two[0] == "X" && row_two[1] == "X" && row_two[2] == "X"){ gameOver = true; Console.WriteLine("Player One Wins!"); }
            else
            if (row_three[0] == "X" && row_three[1] == "X" && row_three[2] == "X"){ gameOver = true; Console.WriteLine("Player One Wins!"); }
            else
            if (row_one[0] == "X" && row_two[1] == "X" && row_three[2] == "X"){ gameOver = true; Console.WriteLine("Player One Wins!"); }
            else
            if (row_one[1] == "X" && row_two[1] == "X" && row_three[1] == "X"){ gameOver = true; Console.WriteLine("Player One Wins!"); }
            else
            if (row_one[2] == "X" && row_two[1] == "X" && row_three[0] == "X"){ gameOver = true; Console.WriteLine("Player One Wins!"); }

           
            if (row_one[0] == "O" && row_one[1] == "O" && row_one[2] == "O"){ gameOver = true; Console.WriteLine("Player Two Wins!"); }
            else
            if (row_two[0] == "O" && row_two[1] == "O" && row_two[2] == "O"){ gameOver = true; Console.WriteLine("Player Two Wins!"); }
            else
            if (row_three[0] == "O" && row_three[1] == "O" && row_three[2] == "O"){ gameOver = true; Console.WriteLine("Player Two Wins!"); }
            else
            if (row_one[0] == "O" && row_two[1] == "O" && row_three[2] == "O"){ gameOver = true; Console.WriteLine("Player Two Wins!"); }
            else
            if (row_one[1] == "O" && row_two[1] == "O" && row_three[1] == "O"){ gameOver = true; Console.WriteLine("Player Two Wins!"); }
            else
            if (row_one[2] == "O" && row_two[1] == "O" && row_three[0] == "O"){ gameOver = true; Console.WriteLine("Player Two Wins!"); }


            return gameOver;

        }


    }



}



