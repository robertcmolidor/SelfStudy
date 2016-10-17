using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InternetBattle.Models;


namespace InternetBattle.Persistence.ItemRepo
{
    class Manager
    {
        public List<Item> GetAllItems()
        {
            var items = new List<Item>
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
            return items;
        }
    }
}
