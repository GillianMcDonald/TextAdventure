using System;
using System.Collections.Generic;
using System.Text;

namespace TextAdventure
{
    class Game
    {
        public Player SetPlayer()
        {
            Console.WriteLine("Welcome to Escape, what is your name?");
            var InputName = Console.ReadLine();
            Player Player1 = new Player(InputName);
            Console.WriteLine("Welcome to the game " + InputName + ". Your Hit Power is 25 points per hit and your Health is currently 100 points.");
            return Player1;
        }

      //location they start in.  Kitchen
        public Location SetLocation0(Player name)
        {
            Location Location0 = name.AddLocation("disused kitchen", "There are open cupboards and kitchen equipment scattered throughout the room", true, true, true, true);
            Items Blender = Location0.AddLocationItem("Blender", "Broken orange blender, nothing underneath", "This item does nothing", true);
            Items Cupboards = Location0.AddLocationItem("Cupboards", "60's formica yellow Kitchen units ", "This item does nothing", false);
            Items Knife = Location0.AddLocationItem("Knife", "Large serrated knife", "the knife adds 50 points to your Hit Power", true);
            Items ButchersBlock = Location0.AddLocationItem("Butchers Block", "Heavy, covered in mould, nothing underneath", "This item does nothing", false);
            Items Plant = Location0.AddLocationItem("Plant", "Dead spider plant in a cracked pot, nothing underneath", "This item does nothing", true);
           
            return Location0;
        }

        //Door 1. Old Laboritory 
        public Location SetLocation1(Player name)
        {
            Location Location1 = name.AddLocation("old laboritory", "Smashed equipment is strewn around the room, chemical spills everywhere, watch your step", true, false, false, false);
            Items TestTube = Location1.AddLocationItem("Test Tubes", "Racks of test tubes, mostly smashed to pieces", "This item does nothing", false);
            Items Potion = Location1.AddLocationItem("Potion", "Conical flask full of green liquid", "The potion inccreases your health by 50", true);
            Items Cages = Location1.AddLocationItem("Cages", "Rows of empty cages with open doors", "This item does nothing", false);
            Items Microscope = Location1.AddLocationItem("Microscope", "Warning light flashes showing non organic matter present", "This item does nothing", true);
            Items Clock = Location1.AddLocationItem("Clock", "Broken clock showing time as 2.10", "This item does nothing", true);
            Zombie Zombie = Location1.AddLocationZombie(Location1, "Zombie");
            return Location1;
        }

        //Door 2. Medical Room 
        public Location SetLocation2(Player name)
        {
            Location Location2 = name.AddLocation("medical room", "The room is vacant but with a terrible odour", false, true, false, false);
            Items Stethoscope = Location2.AddLocationItem("Stethoscope", "Red stethoscope without earbuds", "This item does nothing", true);
            Items Gurney = Location2.AddLocationItem("Hospital Bed", "Gurney with skeleton on top", "This item does nothing", false);
            Items Scalpel = Location2.AddLocationItem("Scalpel", "Small bloodstained scalpel", "This item does nothing", true);
            Items Sphygmomanometer = Location2.AddLocationItem("Sphygmomanometer", "Blood pressure meter but you knew that right?", "This item does nothing", true);
            Items Syringe = Location2.AddLocationItem("Syringe", "Filled with purple liquid", "This item increases your hit power by 25", true);
            Items Chair = Location2.AddLocationItem("Chair", "Stained roller chair", "This item does nothing", false);
            return Location2;
        }

        //Door 3. Sunk Couryard.  Stairs out and main zombie
        public Location SetLocation3(Player name)
        {
            Location Location3 = name.AddLocation("sunken courtyard", "Dead plants and trees surround you, you can see some stairs in the far corner", false, false, true, false);
            Items FlowerBeds = Location3.AddLocationItem("Flower Beds", "Overflowing with dead plants", "This item does nothing", true);
            Items WateringCan = Location3.AddLocationItem("Watering Can", "Green, plastic, empty watering can", "This item does nothing", true);
            Items Wheelbarrow = Location3.AddLocationItem("Wheelbarrow", "Metal wheelbarrow with only one handle", "This item does nothing", false);
            Items stairs = Location3.AddLocationItem("Stairs", "Concrete steps leading to ground level", "This item does nothing", false);
            ZombieKing ZombieKing = Location3.AddLocationZombieKing(Location3, "The Zombie King");
            return Location3;
        }

        //Door 4. Old Dormitory 
        public Location SetLocation4(Player name)
        {
            Location Location4 = name.AddLocation("dormitory", "Beds with restraints are crammed together, there's fresh blood on the floor", false, false, false, true);
            Items Chains = Location4.AddLocationItem("Chains", "Lengths of chain used to chain the beds together", "This item does nothing", false);
            Items Wardrobe = Location4.AddLocationItem("Wardrobe", "Large wooden wardrobe full of dirty rags", "This item does nothing", false);
            Items Transporter = Location4.AddLocationItem("Transporter", "Small silver transporting device ", "Moves you to another Location", true);
            Items Pillow = Location4.AddLocationItem("Pillow", "Dirty, ripped feather pillow", "This item does nothing", true);
            Zombie Zombie = Location4.AddLocationZombie(Location4, "Zombie");
            return Location4;
        }

        public void PlayerPrompt()
        {
            Console.WriteLine(@"What would you like to do?
Type the number for the action you want:
        1.Look around
        2.Search an item
        3.Pick up an item
        4.Use an item
        5.View my items
        6.Change Location");
        }

        public void FightPrompt()
        {
            Console.WriteLine(@"What would you like to do?
Type the number for the action you want:
        1.View my items
        2.Use an item
        3.Trade blows with the Zombie");
        }
    }
}
