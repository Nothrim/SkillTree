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
    class PlayerGUI
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
            if (skillTreeUI != null && skillTreeUI.isVisible())
            {
                skillTreeUI?.Update(gameTime);
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
                        skillTreeInterface.Draw(Main.spriteBatch, new GameTime());
                        return true;
                    },
                    InterfaceScaleType.UI)
                );
            }
        }
    }
}
