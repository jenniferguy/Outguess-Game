using System;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.CompilerServices;

namespace Outguess_Game_2
{
    class Program
    {
        static void Main(string[] args) {

            
            //ISSUE RANDOM CODE TO GENERATE RANDOM NUMBER
            Random rnd_maker = new Random();
            //DECLARE VARIABE(S)
            double copyOfUserGuesses = 0;
            int number = 5;// rnd_maker.Next(0, 101);
            int userInput = 0;
            double userGuesses = 0.0;
            double userWager = 0.0;
            int playAgain = 0;
            int gamesPlayed = 0;
            int gamesWon = 0;
           
            //INTRODUCTION TO GAME
            Console.WriteLine(" Welcome to Outguess!!!");
            Console.WriteLine(" Try to choose the correct random number to win the game.");
           
            Console.WriteLine();
            //GET USER CASH
            double userCash = GetUserInputDouble(" How much cash are you bringing to the table? $");
            Console.WriteLine();

            //DO LOOP TO RESTART GAME
           
            do {
                       gamesPlayed = gamesPlayed + 1;
                //VALIDATION LOOP FOR WAGER AMOUNT
                do
                {
                    userWager = GetUserInputDouble(" How much would you like to wager? $");

                    if (userCash < userWager || userCash <= 0) 
                    {
                        Console.WriteLine(" Please enter a valid amount.");
                        Console.WriteLine(" Cannot be more than the cash you brought to the table and cash should be more than 0.");
                    }//END IF
                        Console.WriteLine();
                }while (userCash < userWager || userCash <=0);

                //VALIDATION LOOP FOR NUMBER OF GUESSES
                do
                {
                    userGuesses = GetUserInputDouble(" How many guesses do you want to use? Max guess allowed is 10 ");
                    copyOfUserGuesses = userGuesses;
                    if (userGuesses > 10) {
                        Console.WriteLine(" Please enter a valid number between 1 -10.");
                    }//END IF
                    Console.WriteLine();
                   
                }while (userGuesses > 10);
                   
                    //MAIN GAME LOOP

                    do { 

                        //VALIDATION LOOP FOR USERS GUESS
                        do
                        {
                            Console.WriteLine(" Choose a valid number between 1 & 100.");//INPUT FROM THE USER
                            userInput = int.Parse(Console.ReadLine());
                        }while (userInput < 1 || userInput > 100);
                            Console.WriteLine();

                            //SUBTRACT 1 FROM THE NUMBER OF GUESSES
                             userGuesses = userGuesses - 1;
                
                            //TELL USER WHETHER GUESS IS TOO HIGH, TOO LOW, OR CORRECT
                            if (userInput < number){
                                Console.WriteLine(" Too low! You have {0} tries to go", userGuesses);
                            }else if (userInput > number){
                                Console.WriteLine(" Too high! You have {0} tries to go", userGuesses);
                            }//END IF
               
                    } while (userInput != number && userGuesses > 0);
 
                    //TELL USER WHETHER THEY WIN OR LOSE

                    if (userInput == number) {
                        Console.WriteLine(" Congratulations! You guessed the correct number.!");
                        gamesWon = gamesWon + 1;
                        Console.WriteLine("-----------------------------------------------------");
                        Console.WriteLine(" Total winnings = {0:C}", UserWinnings(copyOfUserGuesses, userWager));
                        double userCashAfterWinning = userCash + UserWinnings(copyOfUserGuesses, userWager);
                        Console.WriteLine(" You now have a cash balance of {0:C}", userCashAfterWinning);
                        userCash = userCashAfterWinning;
                       
                    }else if (userInput != number){
                        Console.WriteLine(" Sorry, you Lose!");
                        Console.WriteLine(" The correct number = {0}", number);
                        Console.WriteLine(" --------------------------------------");
                        double cashAfterLosing = userCash - userWager;
                        Console.WriteLine(" You have {0:C} left", cashAfterLosing);
                        userCash = cashAfterLosing;
                   

                 
                    }//END IF

                        Console.WriteLine();
                        //SEE IF USER WOULD LIKE TO PLAY AGAIN
                        Console.Write(" Would you like to play again? (0 for yes) or (1 for no): " );
                        playAgain = int.Parse(Console.ReadLine());
                        Console.WriteLine();
                        ResetGame(number =rnd_maker.Next(0, 101));

            } while (playAgain == 0);
               
                        //CALCULATE WINNING PERCENTAGE
                        if ( playAgain != 0 || userCash <= 0){
                           Console.WriteLine(" Your winning % ={0:F2}",  WinningPercentage(gamesWon,gamesPlayed));
                
                        }//END WHILE
                        Console.ReadKey();
        }//END MAIN


        static void ResetGame(int number) 
        {
            Random  rnd_maker = new Random();
            number = rnd_maker.Next(0, 101);
        }//END FUNCTION
       
        static double WinningPercentage(double numberOfGamesWon, double numberOfGamesPlayed)
        {
            double winningPercentage =  numberOfGamesWon/numberOfGamesPlayed * 100;
            return  winningPercentage;
        }//END FUNCTION

       static double GetUserInputDouble(string text)
        {
            Console.Write(text + " ");
            return double.Parse(Console.ReadLine());
        }//END FUNCTION

        static double UserWinnings ( double guessesUsed, double userWager)
        {
            if (guessesUsed == 1)  return userWager * 10;
            if (guessesUsed == 2)  return userWager * 9;
            if (guessesUsed == 3)  return userWager * 8;
            if (guessesUsed == 4)  return userWager * 7;
            if (guessesUsed == 5)  return userWager * 6;
            if (guessesUsed == 6)  return userWager * 5;
            if (guessesUsed == 7)  return userWager * 4;
            if (guessesUsed == 8)  return userWager * 3;
            if (guessesUsed == 9)  return userWager * 2;
            if (guessesUsed == 10) return userWager * 1;
            return 0;
        }//END FUNCTION

       static double AddDouble (double userCash, double userWinnings)
        {
            double cashTotalAfterWinning = userCash + userWinnings;
            return cashTotalAfterWinning;
        }// END FUNCTION
    }//END CLASS
}//END NAMESPACE



