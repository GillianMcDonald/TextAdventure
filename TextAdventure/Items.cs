using System;
using System.Collections.Generic;
using System.Text;

namespace TextAdventure
{
    class Items
    {
        private List<string> GameItems;
       
        private string ItemName { get; set; }
        private string ItemDescription { get; set; }
       
        private string ItemAction { get; set; }

        public bool CanPickUp { get; set; }

        //need constructor.  can constructor add to player / location?

        public Items(string Name, string ItemDescription, string ItemAction, bool CanPickUp)
        {
            this.ItemName = Name;
            this.ItemDescription = ItemDescription;
            this.ItemAction = ItemAction;
            this.CanPickUp = CanPickUp;
            //Console.WriteLine("Item Created");
        }

        public string GetItemName()
        {
            return ItemName;
        }

        public void SetItemName(string Name)
        {
            this.ItemName = Name;
        }

        public string GetItemDescription()
        {
            return ItemDescription;
        }


        //when to set items action?  when created so parameter? 

        //methods needed
        //use item (by player) action happens and item deleted from player inventory 
        //delete item (from location or player doesn't matter) 
        //add item (to location or player - doesn't matter)
    }
}
