using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dungeon
{
    class Item
    {
        public string Name;
        public int Weight;
        public string Type;

        public Item(string n, int w, string t)
        {
            Name = n;
            Weight = w;
            Type = t;
        }
    }
}
