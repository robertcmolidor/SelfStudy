using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NyanCatBattleRemix.Classes
{
    public class Backpack
    {
        public int Size { get; set; }
        public int NumberOfItems { get; set; }
        public bool IsFull { get; set; }
        public Dictionary<Item, int> Contents { get; set; }

        public void UseItem(Item item)
        {
            int result;
            if (Contents.TryGetValue(item, out result))
            {
                Contents[item] = result--;
            }
            if (result == 1)
            {
                Contents.Remove(item);
            }
            NumberOfItems--;
            IsFull = false;
        }

        public void AddItem(Item item)
        {
            int result;
            if (Contents.TryGetValue(item, out result))
                Contents[item] = result++;
            else
            {
                Contents.Add(item,1);
            }
            NumberOfItems++;
            if (NumberOfItems == Size)
                IsFull = true;
        }

        public bool HasItem(Item item)
        {
            return Contents.ContainsKey(item);
        }
    }
    
}