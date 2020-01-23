using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Collections;


namespace TextAdventure
{
    class Player
    {
        Game Game = new Game();
        private string PlayerName { get; set; }

        public int PlayerHealth { get; private set; }

        public int PlayerHitPower { get; private set; }

        public List<Items> PlayerItems { get; private set; }

        //public List<Actions> PlayerActions;

        public List<Location> LocationsList;
        public Location AddLocation(string InLocationName, string InLocationDescription, bool Door1, bool Door2, bool Door3, bool Door4)
        {
            Location result = new Location(InLocationName, InLocationDescription, Door1, Door2, Door3, Door4);
            LocationsList.Add(result);
            return result;
        }

      
        public void TransporterMove(Player name, string location)
        {
            foreach (Location l in name.LocationsList)
            {
                if(l.GetLocationName() == location)
                {
                    continue;
                }
                Console.WriteLine(l.GetLocationName());
            }

        }


        //want to see what locations are available.  need to know where you are
        public void ViewLocationOptions(Location location)
        {
            Console.WriteLine("Please type the number of the door you wish to go through exactly as you see it in the list below");

            if(location.GetLocationName() == "disused kitchen")
            {
                Console.WriteLine("Door 1");
                Console.WriteLine("Door 2");
                Console.WriteLine("Door 3");
                Console.WriteLine("Door 4");
            }
            if (location.GetLocationName() == "old laboritory")
            {
                Console.WriteLine("Door 1");
            }
            if (location.GetLocationName() == "medical room")
            {
                Console.WriteLine("Door 2");
            }
            if (location.GetLocationName() == "sunken courtyard")
            {
                Console.WriteLine("Door 3");
            }
            if (location.GetLocationName() == "dormitory")
            {
                Console.WriteLine("Door 4");
            }
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
            this.PlayerName = Name;
            PlayerItems = new List<Items>();
            PlayerHealth = 100;
            PlayerHitPower = 25;
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
            Console.WriteLine("Here is a list of your items:");
            if(PlayerItems.Count >0)
            {
                foreach (Items i in PlayerItems)
                {
                    Console.Write(i.GetItemName() + ". "); Console.Write(i.GetItemDescription() + ". "); Console.WriteLine(i.GetItemAction() + ".");
                };
            }
            else
            {
                Console.WriteLine("You currently don't have any items.");
                
            }

        }

        public Items FindPlayerItem(string ItemName, Player name)
        {
            foreach (Items i in name.PlayerItems)
            {
                if (i.GetItemName() == ItemName)
                {
                    var result = i;
                    return i;
                }
            }
            return null;
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

        public void IncreasePlayerHealth(int factor)
        {
            PlayerHealth += factor;
        }

        public void DecreasePlayerHealth(int factor, Player name)
        {
            PlayerHealth -= factor;
            Console.WriteLine(name.GetPlayerName() + "'s got hit!");
        }

        public void IncreasePlayerHitPower(int factor)
        {
            PlayerHitPower += factor;
        }

        public string GetPlayerName()
        {
            return PlayerName;
        }

    }
}

