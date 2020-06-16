using Microsoft.Xna.Framework;
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

        public void buildUI()
        {
            skillTreeUI = new SkillTreeUI();
            skillTreeInterface = new UserInterface();
            skillTreeInterface.SetState(skillTreeUI);
        }

        public  void updateUI(GameTime gameTime)
        { 
            if (skillTreeUI != null && skillTreeUI.isVisible() && !Main.gameMenu)
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
                        if (!skillTreeUI.isVisible() || Main.gameMenu) { return true; }
                        skillTreeInterface.Draw(Main.spriteBatch, new GameTime());
                        return true;
                    },
                    InterfaceScaleType.UI)
                );
            }
        }

        public void showSkillTreeUI()
        {
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
