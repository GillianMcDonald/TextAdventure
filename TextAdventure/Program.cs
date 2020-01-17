using System;
using System.Collections;

namespace TextAdventure
{
    class Program
    {
        static void Main(string[] args)
        {
            Game Game = new Game();
            Logic Logic = new Logic();
            Player Player1 = Game.SetPlayer();
            Location Location0 = Game.SetLocation0(Player1);
            Location Location1 = Game.SetLocation1(Player1);
            Location Location2 = Game.SetLocation2(Player1);
            Location Location3 = Game.SetLocation3(Player1);
            Location Location4 = Game.SetLocation4(Player1);

            
           

            Location0.WhereAmI(Location0);
            Game.PlayerPrompt();
            Logic.LocationLogic(Player1, Location0);

           

        }
    } 
}


