using System;
using System.Collections.Generic;
using System.Text;

namespace TextAdventure
{
    class Game
    {
        public List<Location> LocationsList;
        public Location AddLocation(string InLocationName, string InLocationDescription)
        {
            Location result = new Location(InLocationName, InLocationDescription);
            LocationsList.Add(result);
            return result;
        }

        //want to see what locations are available
        public void ViewLocationOptions()
        {
            foreach (Location L in LocationsList)
            {
                Console.WriteLine(L);
            };
        }
        //game creates players and keeps a list of them (like bank and accounts)
        //game creates locations and keeps a list of them (like bank and accounts)
    }
}
