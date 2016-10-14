using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NyanCatBattleRemix.Classes
{
    [Serializable]
    public class Item
    {
        public Guid ItemId { get; set; }
        public string Name { get; set; }
        public string Avatar { get; set; }
        public int Health { get; set; }
        public int Attack { get; set; }
        public int Defend { get; set; }
        public int HPMax { get; set; }
    }
}