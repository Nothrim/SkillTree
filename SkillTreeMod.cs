using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using SkillTree.UI;
using System.Collections.Generic;
using Terraria;
using Terraria.ModLoader;
using Terraria.UI;

namespace SkillTree
{
	public class SkillTreeMod : Mod
	{
        PlayerGUI gui = new PlayerGUI();

        public override void Load()
        {
            base.Load();
            if (!Main.dedServ)
            {
                loadOnClient();
            }
        }

        private void loadOnClient()
        {
            gui.buildUI();
        }

        public override void UpdateUI(GameTime gameTime)
        {
            base.UpdateUI(gameTime);
            gui.updateUI(gameTime);
        }

        public override void ModifyInterfaceLayers(List<GameInterfaceLayer> layers)
        {
            gui.modifyInterfaceLayers(layers);
        }
    }
}