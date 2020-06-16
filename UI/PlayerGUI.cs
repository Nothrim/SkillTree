using Microsoft.Xna.Framework;
using SkillTree.Core;
using SkillTree.Player;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.UI;

namespace SkillTree.UI
{
    public class PlayerGUI
    {
        private SkillTreeUI skillTreeUI;
        private UserInterface skillTreeInterface;
        private SkillDefinitionLoader skillDefinitionLoader;
        private SkillPlayer player;

        public PlayerGUI(SkillDefinitionLoader skillDefinitionLoader)
        {
            this.skillDefinitionLoader = skillDefinitionLoader;
        }
        public void buildUI()
        {
            skillTreeUI = new SkillTreeUI();
            skillTreeInterface = new UserInterface();
            skillTreeInterface.SetState(skillTreeUI);
        }

        public  void updateUI(GameTime gameTime)
        {

            if (skillTreeUI != null && skillTreeUI.isVisible() && !Main.gameMenu && player != null)
            {
                skillTreeInterface.Update(gameTime);
            }
        }

        public void modifyInterfaceLayers(List<GameInterfaceLayer> layers)
        {
            int mouseTextIndex = layers.FindIndex(layer => layer.Name.Equals("Vanilla: Mouse Text"));
            if (mouseTextIndex != -1)
            {
                layers.Insert(mouseTextIndex, new LegacyGameInterfaceLayer(
                    "Skill Tree: useSkillAndStuff",
                    delegate
                    {
                        if (!skillTreeUI.isVisible() || Main.gameMenu || player == null) { return true; }
                        skillTreeInterface.Draw(Main.spriteBatch, new GameTime());
                        return true;
                    },
                    InterfaceScaleType.UI)
                );
            }
        }

        public void showSkillTreeUI(SkillPlayer player)
        {
            this.player = player;
            skillTreeUI.show();
        }

        public void hideSkillTreeUI()
        {
            skillTreeUI.hide();
        }

        public bool isVisible()
        {
            return skillTreeUI.isVisible();
        }
    }
}
