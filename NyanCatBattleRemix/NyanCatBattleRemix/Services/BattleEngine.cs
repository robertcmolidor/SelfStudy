using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NyanCatBattleRemix.Classes;

namespace NyanCatBattleRemix.Services
{
    public class BattleEngine
    {
        public void Attack(Player player, EnemyPlayer enemy)
        {
            var dice = new Dice();
            enemy.Stats.Health -= dice.Roll(12, player.Stats.DamageMaximum - dice.Roll(12, enemy.Stats.DefendMaximum));
            if(enemy.Stats.Health <= 0)
                enemy.IsAlive = false;
            
        }
    }
}