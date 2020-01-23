using System;
using System.Collections.Generic;
using System.Text;

namespace TextAdventure
{
    class Actions
    {
        Logic Logic = new Logic();
        Game Game = new Game();
        FightLogic FightLogic = new FightLogic();
        public void UsePotion(string item1, Player name)
        {//increases health by 50 
            name.IncreasePlayerHealth(50);
            Console.WriteLine("Your health is now " + name.PlayerHealth);
            //need to find it and return as an Item so can remove it 
            Items Item2 = name.FindPlayerItem(item1, name);
            //need to remove from player items
            name.PlayerItems.Remove(Item2);
        }

        public void UseKnife(string item1, Player name)
        {//increases hitpower by 50
            name.IncreasePlayerHitPower(50);
            Console.WriteLine("Your Hit Power is now " + name.PlayerHitPower + " points per hit");
            //need to find it and return as an Item so can remove it 
            Items Item2 = name.FindPlayerItem(item1, name);
            //need to remove from player items
            name.PlayerItems.Remove(Item2);
        }

        public void UseSyringe(string item1, Player name)
        {//increases hitpower by 25
            name.IncreasePlayerHitPower(25);
            Console.WriteLine("Your Hit Power is now " + name.PlayerHitPower + " points per hit");
            //need to find it and return as an Item so can remove it 
            Items Item2 = name.FindPlayerItem(item1, name);
            //need to remove from player items
            name.PlayerItems.Remove(Item2);
        }

        public void UseTransporter(string item1, Player name, Location location)
        {//changing locations like this doesn't trigger the search the room for an enemy function. it needs to. 
            string LeavingLocation = location.LocationToString(location); //change Location into string
            Console.WriteLine("Please type the name of the location you would like to move to exactly as you see it below:");
            name.TransporterMove(name, LeavingLocation); //list the locations available to me by name
            string NewLocation = Console.ReadLine();

            if (NewLocation != "disused kitchen" && NewLocation != "old laboritory" && NewLocation != "medical room" && NewLocation != "sunken courtyard" && NewLocation != "dormitory")
            {
                Console.WriteLine("That location doesn't exist");
            }
            else
            {
                switch (NewLocation)
                {
                    case "disused kitchen":
                        Location MoveTo = name.FindLocation("disused kitchen");
                        bool IsThereAnEnemy = MoveTo.IsThereAnEnemy(MoveTo);
                        FightLogic.IfEnemyFound(name, location, MoveTo, IsThereAnEnemy);
                        break;
                    case "old laboritory":
                        Location MoveTo1 = name.FindLocation("old laboritory");
                        bool IsThereAnEnemy1 = MoveTo1.IsThereAnEnemy(MoveTo1);
                        FightLogic.IfEnemyFound(name, location, MoveTo1, IsThereAnEnemy1);
                        break;
                    case "medical room":
                        Location MoveTo2 = name.FindLocation("medical room");
                        bool IsThereAnEnemy2 = MoveTo2.IsThereAnEnemy(MoveTo2);
                        FightLogic.IfEnemyFound(name, location, MoveTo2, IsThereAnEnemy2);
                        break;
                    case "sunken courtyard":
                        Location MoveTo3 = name.FindLocation("sunken courtyard");
                        bool IsThereAnEnemy3 = MoveTo3.IsThereAnEnemy(MoveTo3);
                        FightLogic.IfEnemyFound(name, location, MoveTo3, IsThereAnEnemy3);
                        break;
                    case "dormitory":
                        Location MoveTo4 = name.FindLocation("dormitory");
                        bool IsThereAnEnemy4 = MoveTo4.IsThereAnEnemy(MoveTo4);
                        FightLogic.IfEnemyFound(name, location, MoveTo4, IsThereAnEnemy4);
                        break;
                }
                Items Item2 = name.FindPlayerItem(item1, name);
                //need to remove from player items
                name.PlayerItems.Remove(Item2);
            }

        }

        ////move to fight sequences here if there is an enemy in the new location. 
        //Location NewLocation2 = name.FindLocation(NewLocation);
        //bool IsThereAnEnemy = NewLocation2.IsThereAnEnemy(NewLocation2);
        //FightLogic.IfEnemyFound(name, location, NewLocation2, IsThereAnEnemy);


        public void UseItem(string item1, Player name, Location location)
        {
          if(item1 == "Potion")
            {
                UsePotion(item1, name);
            }
          if(item1 == "Knife")
            {
                UseKnife(item1, name);
            }
          if (item1 == "Syringe")
            {
                UseSyringe(item1, name);
            }
            if (item1 == "Transporter")
            {
                UseTransporter(item1, name, location);
            }
        }



    }
}
