using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InternetBattle.Models
{
    public class Player : Character
    {
        public Guid PlayerId { get; set; }
        public string UserName { get; set; }
        public Backpack Items { get; set; }
    }
}
