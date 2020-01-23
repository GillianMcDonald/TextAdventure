using System;
using System.Collections.Generic;
using System.Text;
using static System.Environment;

namespace TextAdventure
{
    class Logic
    {
        public void LocationLogic(Player name, Location location)
        {
            Location currentLocation = location;
            FightLogic FightLogic = new FightLogic();
            Game Game = new Game();
            TicTacToe TicTacToe = new TicTacToe();
            Actions Actions = new Actions();
            


            while (true)
            {
                string Action = Console.ReadLine();

                switch(Action)
                {
                    case "1": //look around
                        Console.WriteLine("You can see the following items");
                        location.ViewLocationItems(location);
                        Game.PlayerPrompt();
                        break;
                    case "2": //search an item
                        Console.WriteLine("Please type the name of the Item would you like to search exactly as you see it in the list");
                        string ItemSearch = Console.ReadLine();
                        Items ItemSearch2 = location.FindLocationItem(ItemSearch, location);
                        if (ItemSearch2 == null)
                        { }
                        else
                        {
                            location.ItemDescription(ItemSearch);
                        }
                        Game.PlayerPrompt();
                        break;
                    case "3": //pick up an item
                        Console.WriteLine("Please type the name of the Item would you like to pick up exactly as you see it in the list");
                        string ItemKeep = Console.ReadLine();
                        Items ItemKeep2 = location.FindLocationItem(ItemKeep, location);
                        if (ItemKeep2 != null)
                        {
                            name.PlayerPickUpItem(ItemKeep2, location, ItemKeep2.CanPickUp);
                        }
                        Game.PlayerPrompt();
                        break;
                    case "4": //use an item 
                        name.ViewPlayerItems();
                        if(name.PlayerItems.Count >= 1)
                        {
                            Console.WriteLine("Please type the name of the Item would you like to use");
                            string Item1 = Console.ReadLine();
                            bool Item1Result = name.DoesPlayerHaveItem(Item1); // check player has item

                            if (Item1Result)
                            {
                                Items ItemToUse = name.FindPlayerItem(Item1, name);
                                if (ItemToUse.GetItemAction() == "This item does nothing")
                                {
                                    Console.WriteLine("Unlucky, that item does absolutely nothing");
                                    name.PlayerItems.Remove(ItemToUse);
                                    Game.PlayerPrompt();
                                }
                                else
                                {
                                    Actions.UseItem(Item1, name, location);
                                    Game.PlayerPrompt();
                                }
                            }
                            if (!Item1Result)
                            {
                                Console.WriteLine("You have not picked up that item");
                                Game.PlayerPrompt();
                            }
                        }
                        else
                        {
                            Game.PlayerPrompt();
                        }
                        
                        break;
                    case "5": //view my items
                        name.ViewPlayerItems();
                        Game.PlayerPrompt();
                        break;
                    case "6"://change location 
                        name.ViewLocationOptions(location); //list possible locations as doors
                        string LeavingLocation = location.LocationToString(location);
                        string NewLocation = Console.ReadLine(); //ask for door to go through
                        string NewLocation2 = location.DoorDirection(NewLocation, LeavingLocation); //convert door to location string
                        if (NewLocation2 == null)
                        {
                            Console.WriteLine("That location does not exist, did you type it in the format 'Door 1'?");
                            Game.PlayerPrompt();
                        }
                        else
                        {
                            Location NewLocation3 = name.FindLocation(NewLocation2); //convert location string into Location 
                            currentLocation = NewLocation3; //set currentLocation to the new location name.  
                            NewLocation3.WhereAmI(NewLocation3);

                            //move to fight sequences here if there is an enemy in the new location. 
                            bool IsThereAnEnemy = NewLocation3.IsThereAnEnemy(NewLocation3);

                            FightLogic.IfEnemyFound(name, location, NewLocation3, IsThereAnEnemy);
                            
                        }
                       break;
                    default:
                        Console.WriteLine("Please enter a number between 1 and 6");
                        break;
                }
            }
        }
    }
}



//switch (IsThereAnEnemy)
//{
//    case true:
//        //in here need to get name of enemy from list, check what it is, do appropriate action
//        Enemy Enemy = location.GetEnemy(NewLocation3);
//        Console.WriteLine("the enemy name is " + Enemy.GetEnemyName());
//        if (Enemy.GetEnemyName() == "Zombie")
//        {
//            ConsoleChanges.ConsoleDisplayZombie();
//            Console.WriteLine("There is a Zombie in the room");
//            Enemy Zombie = location.ReturnBasicZombie(NewLocation3, "Zombie");
//            FightLogic.LetsFight(name, Zombie, NewLocation3);
//            Game.PlayerPrompt();
//            LocationLogic(name, currentLocation);
//        }
//        if (Enemy.GetEnemyName() == "The Zombie King")
//        {
//            ConsoleChanges.ConsoleDisplayZombieKing();
//            Console.WriteLine("The Zombie King is in the room");
//            Enemy ZKing = location.ReturnBasicZombie(NewLocation3, "The Zombie King"); 
//            FightLogic.LetsFight(name, ZKing, NewLocation3); 
//        }
//        if (Enemy.GetEnemyName() == "Wise Old Mage")
//        {
//            ConsoleChanges.ConsoleDisplayMage();
//            bool result = TicTacToe.TicTacToeLogic(name, Enemy, NewLocation3);
//            Game.PlayerPrompt();
//            LocationLogic(name, currentLocation);
//        }
//        break;
//    case false:
//        Game.PlayerPrompt();
//        LocationLogic(name, currentLocation);
//        break;
//}