using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NyanCatBattleRemix.Classes
{
    public class Dice
    {
        private readonly Random _random = new Random();
        public int Roll(int sides, int max)
        {
            return _random.Next(max - sides, max);
        }
    }
}