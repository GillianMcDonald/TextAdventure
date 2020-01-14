using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Collections;


namespace TextAdventure
{
    class Player
    {
        private string Name { get; set; }

        private int Health { get; set; }

        public List<Items> PlayerItems { get; private set; }

        //public List<Actions> PlayerActions;

        public List<Location> LocationsList;
        public Location AddLocation(string InLocationName, string InLocationDescription)
        {
            Location result = new Location(InLocationName, InLocationDescription);
            LocationsList.Add(result);
            return result;
        }

        //want to see what locations are available
        public void ViewLocationOptions(Location location)
        {
            Console.WriteLine("Please type the name of the location you wish to move to exactly as you see it in the list below");
            foreach (Location l in LocationsList)
            {
                if (l.GetLocationName() == location.GetLocationName())
                    {
                    continue;
                    }
                Console.WriteLine(l.GetLocationName());
            };
        }

        public Location FindLocation(string LocationName)
        {
            foreach (Location l in LocationsList)
            {
                if (l.GetLocationName() == LocationName)
                {
                    var result = l;
                    return l;
                }
            }
            return null;
        }

        //constructor.  Sets name of player and creates a list to hold references to the items
        public Player(string Name)
        {
            this.Name = Name;
            PlayerItems = new List<Items>();
            Health = 10;
            LocationsList = new List<Location>();
           // Console.WriteLine("player created");
        }

        public void PlayerPickUpItem(Items ItemName, Location Location, bool pickup)
        {
                //want a response in case people type in something that doesn't exist 
                if (ItemName == null)
                {
                    //Console.WriteLine("You have already picked up that item");
                }
                if (pickup == false)
                {
                    Console.WriteLine("You can not pick up that item");
                }
                else if (pickup == true)
                {
                    //add item to player list 
                    PlayerItems.Add(ItemName);
                    Console.WriteLine("You have picked up the Item"); //change to item name when possible 
                                                                      //remove item from location list 
                    Location.RemoveLocationItem(ItemName);
                    // Console.WriteLine("Player picks up item");
                }
        }

        //want to see what's in the list
        public void ViewPlayerItems()
        {
            foreach (Items i in PlayerItems)
            {
                Console.WriteLine(i.GetItemName());
            };
        }

        public void ActionPrompt()
        {
            Console.WriteLine(@"What would you like to do?
Type the number for the action you want:
        1.Look around
        2.Search an item
        3.Pick up an item
        4.Use an item
        5.Change Location");
        }

        public bool DoesPlayerHaveItem(string ItemName)
        {
            foreach (Items i in PlayerItems)
            {
                if (i.GetItemName() == ItemName)
                {
                    var result = i;
                    return true;
                }
            }
           
            return false;
        }

        public void UseItem(string item1, string item2)
        {
            Console.WriteLine("You have used the items");
            //if (item1 == "Key" && item2 == "Door" || item1 == "Door" && item2 =="Key")
            //{
            //    Console.WriteLine("Congratulations you have Escaped the Room, You win!");            
            //}
            //else
            //{
            //    Console.WriteLine("Those items do not work together.  Try again");
            //}

        }

    }
}
