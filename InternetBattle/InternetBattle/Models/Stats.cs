using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InternetBattle.Models
{
    [Serializable]
    public class Stats
    {
        public int Experience { get; set; }
        public int Health { get; set; }
        public int MaxHealth { get; set; }
        public int DamageMaximum { get; set; }
        public int DefendMaximum { get; set; }
        public bool AttackBonus { get; set; }
        public int Limit { get; set; }

        public bool IsAlive()
        {
            if (this.Health > 0)
                return true;
            else
                return false;
        }
        public void SetHealthMax()
        {
            this.Health = MaxHealth;
        }
        public bool IsLimit()
        {
            if (this.Limit >= 100)
                return true;
            else
                return false;
        }
    }
}