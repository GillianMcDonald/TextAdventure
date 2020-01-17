using System;
using System.Collections.Generic;
using System.Text;

namespace TextAdventure
{
    class Actions
    {
        
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


        public void UseItem(string item1, Player name)
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

        }



    }
}
