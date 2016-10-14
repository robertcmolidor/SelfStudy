using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NyanCatBattleRemix.Classes
{
    public class EnemyPlayer : Player
    {
        public int ExperienceGiven { get; set; }
        public int EngagementOdds { get; set; }
        public Item ItemDropped { get; set; }

        public EnemyPlayer()
        {
            ItemDropped = new Item();
        }
    }
}