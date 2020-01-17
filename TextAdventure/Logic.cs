using System;
using System.Collections.Generic;
using System.Text;

namespace TextAdventure
{
    class Logic
    {
        FightLogic FightLogic = new FightLogic();
        Game Game = new Game();
        Actions Actions = new Actions();
        public void LocationLogic(Player name, Location location)
        {
            Location currentLocation;
            currentLocation = location;

            while (true)
            {
                string Action = Console.ReadLine();

                if (Action == "1" || Action == "2" || Action == "3" || Action == "4" || Action == "5" || Action == "6")
                {
                    if (Action == "1") //look around
                    {
                        Console.WriteLine("You can see the following items");
                        location.ViewLocationItems(location);
                        Game.PlayerPrompt();
                    }
                    if (Action == "2") //search an item
                    {
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
                    }
                    if (Action == "3")//pick up an item
                    {
                        Console.WriteLine("Please type the name of the Item would you like to pick up exactly as you see it in the list");
                        string ItemKeep = Console.ReadLine();
                        Items ItemKeep2 = location.FindLocationItem(ItemKeep, location);
                        if (ItemKeep2 == null)
                        { }
                        else
                        {
                            name.PlayerPickUpItem(ItemKeep2, location, ItemKeep2.CanPickUp);
                        }
                        Game.PlayerPrompt();
                    }
                    if (Action == "4") //use an item 
                    {
                        name.ViewPlayerItems();
                        Console.WriteLine("Please type the name of the Item would you like to use");
                        string Item1 = Console.ReadLine();
                        bool Item1Result = name.DoesPlayerHaveItem(Item1); // check player has item

                        if (Item1Result == true)
                        {
                            Actions.UseItem(Item1, name);
                            Game.PlayerPrompt();
                        }
                        if (Item1Result == false)
                        {
                            Console.WriteLine("You have not picked up that item");
                            Game.PlayerPrompt();
                        }
                    }
                    if (Action == "5") //view my items
                    {
                        name.ViewPlayerItems();
                        Game.PlayerPrompt();
                    }
                    if (Action == "6") //change location 
                    {
                        name.ViewLocationOptions(location); //list possible locations as doors
                        string LeavingLocation = location.LocationToString(location);
                        string NewLocation = Console.ReadLine(); //ask for door to go through
                        string NewLocation2 = location.DoorDirection(NewLocation, LeavingLocation); //convert door to location string
                        if (NewLocation2 == null)
                        {
                            Console.WriteLine("That location does not exist, did you type it in the format 'Door 1'?");
                            Game.PlayerPrompt();
                        }
                        if (NewLocation2 != null)
                        {
                            Location NewLocation3 = name.FindLocation(NewLocation2); //convert location string into Location 
                            currentLocation = NewLocation3; //set currentLocation to the new location name.  I think this is the bit that hasn't kicked in 
                            NewLocation3.WhereAmI(NewLocation3);
                            //move to fight sequences here if there is a zombie in the new location 
                            bool IsThereAZombie = NewLocation3.IsThereAZombie(NewLocation3);
                            if(IsThereAZombie == true)
                            {
                                Console.WriteLine("There is a Zombie in the room");
                                BasicZombie basicZombie = location.ReturnBasicZombie(NewLocation3, "BasicZombie1");
                                FightLogic.LetsFight(name, basicZombie, NewLocation3);

                            }
                            else
                            {
                                Game.PlayerPrompt();
                                LocationLogic(name, currentLocation);
                            }
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Please enter a number between 1 and 6");
                }
            }
        }
    }
}


//THIS IS THE OLD US ITEM FUNCTION WHERE ONE ITEM WAS USED WITH ANOTHER
//Console.WriteLine("Please type the name of the Item would you like to use");
//                        string Item1 = Console.ReadLine();
//bool Item1Result = name.DoesPlayerHaveItem(Item1); // check player has item

////Items Item1Item = Location1.FindItem(Item1);
//Console.WriteLine("Now type the name of the item in the room you would like to use to use the first item with");
//                        string Item2 = Console.ReadLine();

//bool Item2Result = location.DoesLocationHaveItem(Item2, location); //check location has item

//if (Item1Result == true && Item2Result == true)
//{
//    name.UseItem(Item1, Item2);
//    Game.PlayerPrompt();
//}
//if (Item1Result == true && Item2Result == false)
//{
//    Console.WriteLine("The 2nd item is not at your location");
//    Game.PlayerPrompt();
//}
//if (Item1Result == false && Item2Result == true)
//{
//    Console.WriteLine("You have not picked up the first item");
//    Game.PlayerPrompt();
//}
//if (Item1Result == false && Item2Result == false)
//{
//    Console.WriteLine("You have not picked up the first item and the 2nd item is not at your location");
//    Game.PlayerPrompt();
//}