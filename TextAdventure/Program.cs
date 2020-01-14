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
            Location Location1 = Game.SetLocation1(Player1);
            Location Location2 = Game.SetLocation2(Player1);
           
            Location1.WhereAmI(Location1);
            Player1.ActionPrompt();

            Logic.LocationLogic(Player1, Location1);
            Logic.LocationLogic(Player1, Location2);
        }
    } 
}


