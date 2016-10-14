using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using InternetBattle.Models;


namespace InternetBattle.Persistence.CharacterRepo
{
    class Manager
    {
        public List<Character> GetAllCharacters()
        {
            
            var enemyNames = new List<string>
            {
                "Piano Cat",
                "Troll Dad",
                "Scumbag Steve",
                "Overly Attached Girlfriend",
                "Grumpy Cat",
                "Hipster Barista",
                "Willie Wonka",
                "Philoso Raptor",
                "Socially Akward Penguin",
                "Hasselhoff"
            };
            var enemies = new List<Character>();
            for (int i = 0; i < enemyNames.Count; i++)
            {
                enemies.Add(new Character
                {
                    CharacterId = Guid.NewGuid(),
                    Avatar = "",
                    IsAlive = true,
                    Name = enemyNames[i],
                    Stats = new Stats
                    {
                        AttackBonus = false,
                        DamageMaximum = (i + 1) * 10,
                        DefendMaximum = (i + 1) * 5,
                        Experience = 0,
                        Health = 100,
                        Limit = 0,
                        MaxHealth = (i + 1) * 20
                    }
                });
            }
            return enemies;
        }
        public Player GetNewPlayer(Guid characterId)
        {
            var player = (Player)GetAllCharacters().FirstOrDefault(x => x.CharacterId == characterId);
            double healthAdvantage = player.Stats.MaxHealth/2000;
            if (healthAdvantage >= 1)
                player.Items.Size = 5;
            else
            player.Items.Size = (40 - (int)(35/healthAdvantage));
            return player;
        }

        public EnemyPlayer GeteEnemyPlayer(Guid characterId)
        {
            return (EnemyPlayer)GetAllCharacters().FirstOrDefault(x => x.CharacterId == characterId);
        }
    }
}
