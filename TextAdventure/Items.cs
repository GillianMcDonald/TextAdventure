using System;
using System.Collections.Generic;
using System.Text;

namespace TextAdventure
{
    class Items
    {
        private string ItemName { get; set; }
        private string ItemDescription { get; set; }
        private string ItemAction { get; set; }
        public bool CanPickUp { get; set; }

       

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
        public string GetItemAction()
        {
            return ItemAction;
        }

    }
}
