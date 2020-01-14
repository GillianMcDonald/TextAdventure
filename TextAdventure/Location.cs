using System;
using System.Collections.Generic;
using System.Text;

namespace TextAdventure
{
    class Location
    {
        public string LocationName { get; private set; }
        public string LocationDescription { get; private set; }
       
        public List<Items> LocationItems { get; private set; }

       

        public Location (string LocationName, string LocationDescription)
        {
            this.LocationName = LocationName;
            this.LocationDescription = LocationDescription;
            this.LocationItems = new List<Items>(); 
           // List <Items> LocationItems = new List<Items>();

            //Console.WriteLine("Location Created");
        }

        public Items AddLocationItem(string InName, string InItemDescription, string InItemAction, bool InBool)
        {
            Items result = new Items(InName, InItemDescription, InItemAction, InBool);
            LocationItems.Add(result);
            return result;

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



        public void ItemDescription(string name)
        {
            foreach (Items i in LocationItems)
            {
                if(i.GetItemName() == name)
                {
                    Console.WriteLine(i.GetItemDescription());
                }
            }

        }

        public Items FindItem(string ItemName, Location location)
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
            Console.WriteLine("You are in a " + Name.LocationName + " it's " + Name.LocationDescription);
        }

    }
}
