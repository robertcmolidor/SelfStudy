using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NyanCatBattleRemix.Classes
{
    [Serializable]
    public class Player
    {
        public Guid PlayerId { get; set; }
        public string Name { get; set; }
        public string Avatar { get; set; }
        public Stats Stats { get; set; }
        public Backpack Items { get; set; }
        public bool IsAlive { get; set; }
    }
}