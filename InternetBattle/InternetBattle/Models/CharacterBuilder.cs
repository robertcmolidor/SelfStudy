using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InternetBattle.Models
{
    [Serializable]
    public class CharacterItemRepository
    {
        public Player Player { get; set; }
        public List<EnemyPlayer> Enemies { get; set; }
        public List<Item> Items { get; set; }

        public CharacterItemRepository()
        {
            Player = new Player
            {
                PlayerId = Guid.NewGuid(),
                Avatar = "",
                IsAlive = true,
                Items = new Backpack(),
                Name = "Nyan Cat",
                Stats = new Stats
                {
                    AttackBonus = false,
                    DamageMaximum = 20,
                    DefendMaximum = 5,
                    Experience = 0,
                    Health = 100,
                    Limit = 0,
                    MaxHealth = 100
                }
            };
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
            Enemies = new List<EnemyPlayer>();
            for (int i = 0; i < enemyNames.Count; i++)
            {
                Enemies.Add(new EnemyPlayer
                {
                    PlayerId = Guid.NewGuid(),
                    Avatar = "",
                    IsAlive = true,
                    Items = new Backpack(),
                    Name = enemyNames[i],
                    Stats = new Stats
                    {
                        AttackBonus = false,
                        DamageMaximum = (i + 1) * 20,
                        DefendMaximum = (i+1)*5,
                        Experience = 0,
                        Health = 100,
                        Limit = 0,
                        MaxHealth = (i + 1) * 20
                    }
                });
            }
            Items = new List<Item>
            {
                new Item
                {
                    ItemId = Guid.NewGuid(),
                    Name = "Attack Increase",
                    Avatar = "",
                    Attack = 10
                },
                new Item
                {
                    ItemId = Guid.NewGuid(),
                    Name = "Defense Increase",
                    Avatar = "",
                    Defend = 10
                },
                new Item
                {
                    ItemId = Guid.NewGuid(),
                    Name = "Small Potion",
                    Avatar = "",
                    Health = 50
                },
                new Item
                {
                    ItemId = Guid.NewGuid(),
                    Name = "Large Potion",
                    Avatar = "",
                    Health = 100
                },
                new Item
                {
                    ItemId = Guid.NewGuid(),
                    Name = "Max Health Increase",
                    Avatar = "",
                    Defend = 250
                }

            };




        }
    }
}