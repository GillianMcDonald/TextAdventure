using System;
using System.Collections.Generic;
using System.Text;

namespace TextAdventure
{
    class Game
    {
        public Player SetPlayer()
        {
            Console.WriteLine("Welcome to Escape room, what is your name?");
            var InputName = Console.ReadLine();
            Player Player1 = new Player("InputName");
            return Player1;
        }

        public Location SetLocation1(Player name)
        {
            Location Location1 = name.AddLocation("Dungeon", "Cold and Dark");
            Items Potion1 = Location1.AddLocationItem("Potion", "Bubbly bottle", "Gives Health", true);
            Items Key1 = Location1.AddLocationItem("Key", "Large Gold Door Key", "Fits Key Hole", true);
            Items Door1 = Location1.AddLocationItem("Door", "Hole in door for a key", "Fits Key", false);
            Items Window1 = Location1.AddLocationItem("Window", "Small opaque window, Window Opens", "No Action", false);
            Items Picture1 = Location1.AddLocationItem("Picture", "Mountain Landscape Lifts off the wall, nothing behind", "No Action", true);
            Items Rug1 = Location1.AddLocationItem("Rug", "Large purple rug with nothing underneath", "No Action", true);
            Items Plant1 = Location1.AddLocationItem("Plant", "Beautiful Daisys in a plant Pot", "Find a Key", true);
            return Location1;
        }

        public Location SetLocation2(Player name)
        {
            Location Location2 = name.AddLocation("Church", "Dirty and Creepy");
            Items Cross = Location2.AddLocationItem("Cross", "Ornate Gold Cross", "Fits Wall Sconce", true);
            Items Alter = Location2.AddLocationItem("Alter", "Large Broken Alter table", "No Action", false);
            Items Pews = Location2.AddLocationItem("Pews", "Rows of pews for congregation", "No Action", false);
            Items Windows = Location2.AddLocationItem("Windows", "Ornate crumbling stained glass windows", "No Action", false);
            Items Sconce = Location2.AddLocationItem("Sconce", "Concrete wall sconce with cross missing", "Cross fits", false);
            Items RosaryBeads = Location2.AddLocationItem("Rosary Beads", "Small wooden set of rosary beads", "No Action", true);
            return Location2;
        }
    }
}
