using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TextAdventure
{
    class TicTacToe
    {
        Logic Logic = new Logic();
        Random _random = new Random();

        static char[] arr = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };
        static int[] MageArray = { 1, 2, 3, 4, 5, 6, 7, 8, 9 };

        static string player = "PlayerName";
        static string notplayer = "EnemyName";
        static int choice; //this holds the choice the player wants to use
        static int flag1 = 0; //flag checks who has won.  if 0 still playing, -1 is a 
        static int flag2 = 0; //flag checks who has won.  if 0 still playing, -1 is a 

        public static void ShowBoard()
        {
            Console.WriteLine("     |     |     ");
            Console.WriteLine("  {0}  |  {1}  |  {2}  ", arr[1], arr[2], arr[3]);
            Console.WriteLine("_____|_____|_____");
            Console.WriteLine("     |     |     ");
            Console.WriteLine("  {0}  |  {1}  |  {2}  ", arr[4], arr[5], arr[6]);
            Console.WriteLine("_____|_____|_____");
            Console.WriteLine("     |     |     ");
            Console.WriteLine("  {0}  |  {1}  |  {2}  ", arr[7], arr[8], arr[9]);
            Console.WriteLine("     |     |     ");
        }

        public void MagePlay()
        {
            Console.WriteLine("The mage takes her turn");

            int MageNumber = MageArray[_random.Next(MageArray.Length - 1)];
            Console.WriteLine("random number is " + MageNumber);
            arr[MageNumber] = 'O';
            MageArray = MageArray.Where(val => val != MageNumber).ToArray();
            player = "PlayerName";
            notplayer = "EnemyName";
        }


        public void PlayerPlay()
        {
            ShowBoard();
            Console.WriteLine("Please enter the number of the square you wish to play");
            choice = int.Parse(Console.ReadLine());

            if(choice <1 || choice > 9)
            {
                Console.WriteLine("You have entered a number that isn't between 1 and 9");
                Console.WriteLine("Please enter the number of the square you wish to play");
                choice = int.Parse(Console.ReadLine());
            }
            if (arr[choice] == 'X' || arr[choice] == 'O')
            {
                    Console.WriteLine("Sorry number {0} is already marked with a {1}", choice, arr[choice]);
                    Console.WriteLine("Please enter the number of the square you wish to play");
                    choice = int.Parse(Console.ReadLine());
            }
            else
            {
                arr[choice] = 'X';
                MageArray = MageArray.Where(val => val != choice).ToArray();
                player = "EnemyName";
                notplayer = "PlayerName";
            }

            ShowBoard();
        }

        public void PlayAgain(Player PlayerName, Enemy EnemyName, Location location)
        {
            TicTacToeLogic(PlayerName, EnemyName, location);
        }

        public bool TicTacToeLogic(Player PlayerName, Enemy EnemyName, Location location)
        {
            Console.WriteLine(@"There is a wise old mage in the room, she challenges you to a game of Noughts and Crosses.  
You get to play first and will use Crosses, the mage will play second and use Noughts. 
The winner will be the first player to form a complete line of Noughts or Crosses - horizontally, vertically or diagonally.");
            while (flag1 == 0 || flag2 == 0)
            {
                PlayerPlay();
                flag1 = CheckWin();
                if (flag1 == 0)
                {

                }
                if (flag1 == 1)
                {
                    Console.WriteLine(PlayerName.GetPlayerName() + " has won");
                    Console.WriteLine("The Mage gives you her cloak.  It doesn't do anything but look good!");
                    location.WhereAmI(location);
                    return true;
                }
                if (flag1 == -1)
                {
                    Console.WriteLine("It's a draw"!);
                }
                MagePlay();
                flag2 = CheckWin();
                if (flag2 == 0)
                {

                }
                if (flag2 == 1)
                {
                    Console.WriteLine(EnemyName.GetEnemyName() + " has won");
                    Console.Write("The Mage has bested you and decided you're so bad at Noughts and Crosses it's not worth you living anymore");
                    Console.WriteLine("Thanks for playing");
                    return false;
                }
                if (flag2 == -1)
                {
                    Console.WriteLine("It's a draw! Let's try that again");
                    PlayAgain(PlayerName, EnemyName, location);
                }
            }
            return false;

        }

        private static int CheckWin()
        {
            #region Horzontal Winning Condtion

            //Winning Condition For First Row  
            if (arr[1] == arr[2] && arr[2] == arr[3])
            {
                return 1;
            }
            //Winning Condition For Second Row   
            else if (arr[4] == arr[5] && arr[5] == arr[6])
            {
                return 1;
            }
            //Winning Condition For Third Row   
            else if (arr[7] == arr[8] && arr[8] == arr[9])
            {
                return 1;
            }
            #endregion

            #region vertical Winning Condtion
            //Winning Condition For First Column   
            else if (arr[1] == arr[4] && arr[4] == arr[7])
            {
                return 1;
            }
            //Winning Condition For Second Column  
            else if (arr[2] == arr[5] && arr[5] == arr[8])
            {
                return 1;
            }
            //Winning Condition For Third Column  
            else if (arr[3] == arr[6] && arr[6] == arr[9])
            {
                return 1;
            }
            #endregion

            #region Diagonal Winning Condition
            else if (arr[1] == arr[5] && arr[5] == arr[9])
            {
                return 1;
            }
            else if (arr[3] == arr[5] && arr[5] == arr[7])
            {
                return 1;
            }
            #endregion

            #region Checking For Draw
            // If all the cells or values filled with X or O then any player has won the match  
            else if (arr[1] != '1' && arr[2] != '2' && arr[3] != '3' && arr[4] != '4' && arr[5] != '5' && arr[6] != '6' && arr[7] != '7' && arr[8] != '8' && arr[9] != '9')
            {
                return -1;
            }
            #endregion

            else
            {
                return 0;
            }
        }
            
    }
}
