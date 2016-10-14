using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InternetBattle.Models
{
    public class Character
    {
        public Guid CharacterId { get; set; }
        public string Name { get; set; }
        public string Avatar { get; set; }
        public Stats Stats { get; set; }
        public bool IsAlive { get; set; }

        
    }
}