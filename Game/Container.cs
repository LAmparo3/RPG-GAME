using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dungeon
{
    class Container
    {
        public  Guid ID = new Guid();
        public string Name;
        public int MaxSlots;
        public int MaxWeight;
        public int Weight;
        List<Item> Inventory = new List<Item>();

        public Container(string n, int ms = 9, int mw = 100, int w = 0)
        {
            Name = n;
            MaxSlots = ms;
            MaxWeight = mw;
            Weight = w;
        }
        public virtual Item RemoveItem(int i)
        {
            Item item = Inventory[i];
            Inventory.RemoveAt(i);
            Weight -= item.Weight;
            return Inventory[i];
        }
        public virtual Item RemoveItem(Item item)
        {
            Inventory.Remove(item);
            Weight -= item.Weight;
            return item; ;
        }
        public virtual Item ViewItem(int i)
        {
            return Inventory[i];
        }
        public virtual Item ViewItem(Item i)
        {
            return Inventory[0];
        }
        public virtual bool AddItem(Item item)
        {
            if (Inventory.Count < MaxSlots && item.Weight + Weight <= MaxWeight)
            {
                Inventory.Add(item);
                Weight += item.Weight;
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}
