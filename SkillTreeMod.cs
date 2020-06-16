using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using SkillTree.Controls;
using SkillTree.Core;
using SkillTree.Player;
using SkillTree.UI;
using System.Collections.Generic;
using Terraria;
using Terraria.ModLoader;
using Terraria.UI;

namespace SkillTree
{
	public class SkillTreeMod : Mod
	{
        public PlayerGUI gui { get; private set; }
        public HotkeyConfiguration hotkeyConfiguration { get; private set; }
        public SkillDefinitionLoader skillDefinitionLoader { get; private set; }

     
        public override void Load()
        {
            base.Load();
            this.gui = new PlayerGUI();
            this.hotkeyConfiguration = new HotkeyConfiguration(this);
            this.skillDefinitionLoader = new SkillDefinitionLoader();
            this.skillDefinitionLoader.loadSkills();
            if (!Main.dedServ)
            {
                loadOnClient();
            }
        }

        public override void Unload()
        {
            base.Unload();
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

        public void toggleUI()
        {
            if (gui.isVisible())
            {
                gui.hideSkillTreeUI();
            }
            else
            {
                gui.showSkillTreeUI();
            }
        }

        public void showUI()
        {
            gui.showSkillTreeUI();
        }

    }
}