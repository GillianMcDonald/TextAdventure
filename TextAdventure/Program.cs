using System;
using System.Collections;

namespace TextAdventure
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Escape room, what is your name?");
            var InputName = Console.ReadLine();
         
            Player Player1 = new Player("InputName");

            //Location1 with items
            Location Location1 = Player1.AddLocation("EscapeRoom", "Cold Dark Dungeon");
            Items Potion1 = Location1.AddLocationItem("Potion", "Bubbly bottle", "Gives Health");
            Items Key1 = Location1.AddLocationItem("Key", "Large Gold Door Key", "Fits Key Hole");
            Items Door1 = Location1.AddLocationItem("Door", "Hole in door for a key", "Fits Key");
            Items Window1 = Location1.AddLocationItem("Window", "Small opaque window, Window Opens", "No Action");
            Items Picture1 = Location1.AddLocationItem("Picture", "Mountain Landscape Lifts off the wall, nothing behind", "No Action");
            Items Rug1 = Location1.AddLocationItem("Rug", "Large purple rug with nothing underneath", "No Action");
            Items Plant1 = Location1.AddLocationItem("Plant", "Beautiful Daisys in a plant Pot", "Find a Key");
            //Console.WriteLine("Location items count is " + Location1.LocationItems.Count);

            //Location2 with items
            Location Location2 = Player1.AddLocation("Another Escape Room", "Gothic Church");
            Items Potion2 = Location2.AddLocationItem("Potion 2", "Bubbly bottle", "Gives Health");
            Items Key2 = Location2.AddLocationItem("Key 2", "Large Gold Door Key", "Fits Key Hole");
            Items Door2 = Location2.AddLocationItem("Door 2", "Hole in door for a key", "Fits Key");
            Items Window2 = Location2.AddLocationItem("Window 2", "Small opaque window, Window Opens", "No Action");
            Items Picture2 = Location2.AddLocationItem("Picture 2", "Mountain Landscape Lifts off the wall, nothing behind", "No Action");
            Items Rug2 = Location2.AddLocationItem("Rug 2", "Large purple rug with nothing underneath", "No Action");
            Items Plant2 = Location2.AddLocationItem("Plant 2", "Beautiful Daisys in a plant Pot", "Find a Key");
            //Console.WriteLine("Location items count is " + Location1.LocationItems.Count);

            Location1.WhereAmI(Location1);
           
            Player1.ActionPrompt();

            Location currentLocation;
            currentLocation = Location1;

            while (currentLocation == Location1)
            {

                string Action = Console.ReadLine();

                if (Action == "1" || Action == "2" || Action == "3" || Action == "4" || Action == "5")
                {

                    if (Action == "1") //look around
                    {
                        //Console.WriteLine("You are in an " + Location1.LocationName + " it's a " + Location1.LocationDescription);
                        Console.WriteLine("You can see the following items");
                        Location1.ViewLocationItems(Location1);
                        Player1.ActionPrompt();
                    }
                    if (Action == "2") //search an item
                    {
                        Console.WriteLine("Please type the name of the Item would you like to search exactly as you see it in the list");
                        string ItemSearch = Console.ReadLine();
                        Location1.ItemDescription(ItemSearch);
                        Player1.ActionPrompt();

                    }
                    if (Action == "3")//keep an item
                    {
                        Console.WriteLine("Please type the name of the Item would you like to keep exactly as you see it in the list");
                        string ItemKeep = Console.ReadLine();
                        Items ItemKeep2 = Location1.FindItem(ItemKeep);
                        Player1.PlayerPickUpItem(ItemKeep2, Location1);
                        //Console.WriteLine("Location items count is " + Location1.LocationItems.Count);
                        //Console.WriteLine("player items count is " + Player1.PlayerItems.Count);
                        Player1.ActionPrompt();
                    }
                    if (Action == "4") //use an item 
                    {
                        Console.WriteLine("Please type the name of the Item would you like to use");
                        string Item1 = Console.ReadLine();
                        bool Item1Result = Player1.DoesPlayerHaveItem(Item1); // check player has item

                        //Items Item1Item = Location1.FindItem(Item1);
                        Console.WriteLine("Now type the name of the item in the room you would like to use to use the first item with");
                        string Item2 = Console.ReadLine();
                        bool Item2Result = Location1.DoesLocationHaveItem(Item2); //check location has item

                        if (Item1Result == true && Item2Result == true)
                        {
                            Player1.UseItem(Item1, Item2);

                        }
                        if (Item1Result == true && Item2Result == false)
                        {
                            Console.WriteLine("The 2nd item is not at your location");
                            Player1.ActionPrompt();
                        }
                        if (Item1Result == false && Item2Result == true)
                        {
                            Console.WriteLine("You have not picked up the first item");
                            Player1.ActionPrompt();
                        }
                        if (Item1Result == false && Item2Result == false)
                        {
                            Console.WriteLine("You have not picked up the first item and the 2nd item is not at your location");
                            Player1.ActionPrompt();
                        }
                    }
                    if (Action == "5") //change location 
                    {
                        Player1.ViewLocationOptions(); //list possible locations 
                        var NewLocation = Console.ReadLine();
                        Location NewLocation2 = Player1.FindLocation(NewLocation);
                        currentLocation = NewLocation2;

                        //Location NewcurrentLocation = NewLocation; //need to change the input to a location - look at how i did that with find item.....
                        //Location2.WhereAmI(Location2);
                        //Location2.ViewLocationItems(Location2);



                        //when they choose the location is that when it's instantiated or should they all exist when the game is started?
                    }

                }
                else
                {
                    Console.WriteLine("Please enter a number between 1 and 5");
                }

            }

            while(currentLocation == Location2)
            {

            }














        }
    } 
}
