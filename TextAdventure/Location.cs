using System;
using System.Collections.Generic;
using System.Text;

namespace TextAdventure
{
    class Location
    {
        Game Game = new Game();
        public string LocationName { get; private set; }
        public string LocationDescription { get; private set; }

        private bool Door1 { get; set; }
        private bool Door2 { get; set; }
        private bool Door3 { get; set; }
        private bool Door4 { get; set; }

        public List<Items> LocationItems { get; private set; }

        public List<BasicZombie> LocationZombies { get; private set; }



        public Location (string LocationName, string LocationDescription, bool Door1, bool Door2, bool Door3, bool Door4)
        {
            this.LocationName = LocationName;
            this.LocationDescription = LocationDescription;
            this.Door1 = Door1;
            this.Door2 = Door2;
            this.Door3 = Door3;
            this.Door4 = Door4;
            this.LocationItems = new List<Items>();
            this.LocationZombies = new List<BasicZombie>();
        }

        public Items AddLocationItem(string InName, string InItemDescription, string InItemAction, bool CanPickUp)
        {
            Items result = new Items(InName, InItemDescription, InItemAction, CanPickUp);
            LocationItems.Add(result);
            return result;
        }

        public BasicZombie AddLocationZombie(Location location, string name)
        {
            BasicZombie result = new BasicZombie(location, name);
            LocationZombies.Add(result);
            return result;
        }

        public bool IsThereAZombie(Location location)
        {
            if (location.LocationZombies.Count >= 1)
            {
                return true;
            }
            return false;
        }

        public BasicZombie ReturnBasicZombie (Location location, string name)
        {
                foreach (BasicZombie z in location.LocationZombies)
            {
                if (z.GetZombieName() == name)
                {
                    var result = z;
                    return z;
                }
            }
            return null;
        }

        public void RemoveLocationItem(Items ItemName)
        {
            LocationItems.Remove(ItemName);
        }

        //want to see what items are in the Location list
        public void ViewLocationItems(Location Name)
        {
            foreach (Items i in Name.LocationItems)
            {
                Console.WriteLine(i.GetItemName());
            };
        }

        public string GetLocationName()
        {
            return LocationName;
        }

        public bool GetDoor1()
        {
            return Door1;
        }
        public bool GetDoor2()
        {
            return Door2;
        }
        public bool GetDoor3()
        {
            return Door3;
        }
        public bool GetDoor4()
        {
            return Door4;
        }

        public string DoorDirection (string Door, string location)
        {
            if (location == "old laboritory" && Door == "Door 1")
            {
                return "disused kitchen";
            }
            if (location == "disused kitchen" && Door == "Door 1")
            {
                return "old laboritory";
            }
            if (location == "medical room" && Door == "Door 2")
            {
                return "disused kitchen";
            }
            if (location == "disused kitchen" && Door == "Door 2")
            {
                return "medical room";
            }
            if (location == "sunken courtyard" && Door == "Door 3")
            {
                return "disused kitchen";
            }
            if (location == "disused kitchen" && Door == "Door 3")
            {
                return "sunken courtyard";
            }
            if (location == "dormitory" && Door == "Door 4")
            {
                return "disused kitchen";
            }
            if (location == "disused kitchen" && Door == "Door 4")
            {
                return "dormitory";
            }

            return null;
        }

        //change Location to string 
        public string LocationToString(Location location)
        {
            if (location.GetLocationName() == "disused kitchen")
            {
                return "disused kitchen";
            }
            if (location.GetLocationName() == "old laboritory")
            {
                return "old laboritory";
            }
            if (location.GetLocationName() == "sunken courtyard")
            {
                return "sunken courtyard";
            }
            if (location.GetLocationName() == "dormitory")
            {
                return "dormitory";
            }
            if (location.GetLocationName() == "medical room")
            {
                return "medical room";
            }
            return null;
        }

        public void ItemDescription(string name)
        {
            foreach (Items i in LocationItems)
            {
                if(i.GetItemName() == name)
                {
                    Console.Write(i.GetItemDescription() + ". "); Console.WriteLine(i.GetItemAction());
                }
            }
        }

        public Items FindLocationItem(string ItemName, Location location)
        {
            foreach(Items i in location.LocationItems)
            {
                if(i.GetItemName() == ItemName)
                {
                    var result = i;
                    return i;
                }
            }
            Console.WriteLine("That item is not in your current Location");
            return null;
        }

        public bool DoesLocationHaveItem(string ItemName, Location location)
        {
            foreach (Items i in location.LocationItems)
            {
                if (i.GetItemName() == ItemName)
                {
                    var result = i;
                    return true;
                }
            }
            return false;
        }

        public void WhereAmI(Location Name)
        {
            Console.WriteLine("You are in a " + Name.LocationName + ". " + Name.LocationDescription + ".");
        }

    }
}
