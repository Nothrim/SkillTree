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
        private ChoiceUI choiceUI;
        private UserInterface skillTreeInterface;
        private SkillDefinitionLoader skillDefinitionLoader;
        private SkillPlayer player;
        private UIItem currentUI;

        public PlayerGUI(SkillDefinitionLoader skillDefinitionLoader)
        {
            this.skillDefinitionLoader = skillDefinitionLoader;
        }
        public void buildUI()
        {
            skillTreeUI = new SkillTreeUI();
            choiceUI = new ChoiceUI(skillDefinitionLoader.getAllWays(), way =>
            {
                player.pickWay(way);
                var skillRoot = new SkillTreeBuilder(this.skillDefinitionLoader).getSkillTree(way);
                skillTreeUI.buildSkillTree(skillRoot, skill => { player.learnSkill(skill); });
                Main.NewText("You chave choosen your way, you will be wielder of:");
                Main.NewText(skillRoot.getSkill().displayName);
                showSkillTreeUI(player);
            });
            skillTreeInterface = new UserInterface();
            skillTreeInterface.SetState(skillTreeUI);
            currentUI = skillTreeUI;
        }

        public void updateUI(GameTime gameTime)
        {

            if (currentUI != null && currentUI.isVisible() && !Main.gameMenu && player != null)
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
                        if (!currentUI.isVisible() || Main.gameMenu || player == null) { return true; }
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
            currentUI.hide();
            if (player.hasPickedWay())
            {
                currentUI = skillTreeUI;
                skillTreeInterface.SetState(skillTreeUI);
            }
            else
            {
                currentUI = choiceUI;
                skillTreeInterface.SetState(choiceUI);
            }
            currentUI.show();
        }

        public void hideSkillTreeUI()
        {
            currentUI.hide();
        }

        public bool isVisible()
        {
            return currentUI.isVisible();
        }
    }
}
