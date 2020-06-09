using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using SkillTree.Controls;
using SkillTree.UI;
using System.Collections.Generic;
using Terraria;
using Terraria.ModLoader;
using Terraria.UI;

namespace SkillTree
{
	public class SkillTreeMod : Mod
	{
        private PlayerGUI gui;
        public HotkeyConfiguration hotkeyConfiguration { get; private set; }
        private static SkillTreeMod instance;

        public static SkillTreeMod GetInstance()
        {
            return instance;
        }

     
        public override void Load()
        {
            base.Load();
            this.gui = new PlayerGUI();
            this.hotkeyConfiguration = new HotkeyConfiguration(this);
            instance = this;
            if (!Main.dedServ)
            {
                loadOnClient();
            }
        }

        public override void Unload()
        {
            base.Unload();
            instance = null;
        }

        private void loadOnClient()
        {
            gui.buildUI();
        }

        public override void UpdateUI(GameTime gameTime)
        {
            base.UpdateUI(gameTime);
            gui.updateUI(gameTime);
            this.Logger
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