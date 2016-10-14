using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InternetBattle.Models
{
    public class Backpack 
    {
        public int Size { get; set; }
        public int UsedSpace { get; set; }
        public bool IsFull { get; set; }
        public Dictionary<Item, int> Contents { get; set; }

        public void RemoveItem(Item item)
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
            UsedSpace -= item.Size;
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
            UsedSpace += item.Size;
            if (UsedSpace == Size)
                IsFull = true;
        }

        public bool HasItem(Item item)
        {
            return Contents.ContainsKey(item);
        }

        public bool WillItemFit(Item item)
        {
            return (item.Size + UsedSpace <= Size);
        }
    }
    
}