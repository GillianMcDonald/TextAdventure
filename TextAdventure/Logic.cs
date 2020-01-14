using System;
using System.Collections.Generic;
using System.Text;

namespace TextAdventure
{
    class Logic
    {
        public void LocationLogic(Player name, Location location)
        {
            Location currentLocation;
            currentLocation = location;

            while (true)
            {
                string Action = Console.ReadLine();

                if (Action == "1" || Action == "2" || Action == "3" || Action == "4" || Action == "5")
                {
                    if (Action == "1") //look around
                    {
                        Console.WriteLine("You can see the following items");
                        location.ViewLocationItems(location);
                        name.ActionPrompt();
                    }
                    if (Action == "2") //search an item
                    {
                        Console.WriteLine("Please type the name of the Item would you like to search exactly as you see it in the list");
                        string ItemSearch = Console.ReadLine();
                        Items ItemSearch2 = location.FindItem(ItemSearch, location);
                        if (ItemSearch2 == null)
                        { }
                        else
                        {
                            location.ItemDescription(ItemSearch);
                        }
                        name.ActionPrompt();
                    }
                    if (Action == "3")//keep an item
                    {
                        Console.WriteLine("Please type the name of the Item would you like to keep exactly as you see it in the list");
                        string ItemKeep = Console.ReadLine();
                        Items ItemKeep2 = location.FindItem(ItemKeep, location);
                        if (ItemKeep2 == null)
                        { }
                        else
                        {
                            name.PlayerPickUpItem(ItemKeep2, location, ItemKeep2.CanPickUp);
                        }
                        name.ActionPrompt();
                    }
                    if (Action == "4") //use an item 
                    {
                        Console.WriteLine("Please type the name of the Item would you like to use");
                        string Item1 = Console.ReadLine();
                        bool Item1Result = name.DoesPlayerHaveItem(Item1); // check player has item

                        //Items Item1Item = Location1.FindItem(Item1);
                        Console.WriteLine("Now type the name of the item in the room you would like to use to use the first item with");
                        string Item2 = Console.ReadLine();
                        bool Item2Result = location.DoesLocationHaveItem(Item2, location); //check location has item

                        if (Item1Result == true && Item2Result == true)
                        {
                            name.UseItem(Item1, Item2);
                            name.ActionPrompt();
                        }
                        if (Item1Result == true && Item2Result == false)
                        {
                            Console.WriteLine("The 2nd item is not at your location");
                            name.ActionPrompt();
                        }
                        if (Item1Result == false && Item2Result == true)
                        {
                            Console.WriteLine("You have not picked up the first item");
                            name.ActionPrompt();
                        }
                        if (Item1Result == false && Item2Result == false)
                        {
                            Console.WriteLine("You have not picked up the first item and the 2nd item is not at your location");
                            name.ActionPrompt();
                        }
                    }
                    if (Action == "5") //change location 
                    {
                        name.ViewLocationOptions(location); //list possible locations 
                        var NewLocation = Console.ReadLine(); //ask for new location name
                        Location NewLocation2 = name.FindLocation(NewLocation); //convert string into Location 
                        currentLocation = NewLocation2; //set currentLocation to the new location name.  I think this is the bit that hasn't kicked in 
                        NewLocation2.WhereAmI(NewLocation2);
                        name.ActionPrompt();
                        break;
                    }
                }
                else
                {
                    Console.WriteLine("Please enter a number between 1 and 5");
                }

            }

        }
       
    }
}

