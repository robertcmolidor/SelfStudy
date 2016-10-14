using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NyanCatBattleRemix.Classes;
using NyanCatBattleRemix.Services;

namespace NyanCatBattleRemix
{
    public partial class Default : System.Web.UI.Page
    {
        CharacterItemRepository repo = new CharacterItemRepository();
        protected void Page_Load(object sender, EventArgs e)
        {
            repo = ViewState["RepoState"] as CharacterItemRepository;
            var enemyId = ViewState["EnemyGuid"];
            if ((string)enemyId == Guid.Empty.ToString())
            {
                //this is a trainging battle.  tips to play happen with training
            }
            else
            {
                //enemy = guid.  this has no tips just play.
            }

        }

        protected void attackButton_Click(object sender, EventArgs e)
        {
            var engine = new BattleEngine();
            engine.Attack(repo.Player,repo.Enemies.FirstOrDefault(x => x.PlayerId == Guid.Empty));

        }

        protected void UpdateLabels()
        {
            
        }
    }
}