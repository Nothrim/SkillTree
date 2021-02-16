
using Microsoft.Xna.Framework;
using SkillTree.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.GameContent.UI.Elements;
using Terraria.ModLoader;
using Terraria.UI;

using SkillTreeVisualisation = System.Collections.Generic.List<System.Collections.Generic.List<System.Tuple<SkillTree.Core.SkillNode, SkillTree.UI.SkillButton>>>;
namespace SkillTree.UI
{
    class SkillTreeUI : UIState, UIItem
    {
        private static readonly Microsoft.Xna.Framework.Color BACKGROUD_PANEL_COLOR = new Microsoft.Xna.Framework.Color(73, 93, 171, 210);
        private SkillPanel skillPanel;
        private SkillTreeVisualiser visualiser;
        private bool visible = false;

        public void buildSkillTree(SkillNode way, Action<Skill> onSkillPicked)
        {
            visualiser = new SkillTreeVisualiser(way, onSkillPicked);
            skillPanel.RemoveAllChildren();
            buildSkillTree();
            skillPanel.RecalculateChildren();
            Append(skillPanel);
            this.RecalculateChildren();
        }

        private void buildSkillTree()
        {
            var tree = visualiser.getSkillTree();
            var levelsInformation = tree.Select(level => new LevelSize(level.Count)).ToList();
            var alignments = new SkillAlignmentCalculator().calculateAlignment(levelsInformation);

            for (int level = 0; level < tree.Count; level++)
            {
                for (int i = 0; i < tree[level].Count; i++)
                {

                    var allignBetweenSkills = 1.0f / tree[level].Count;
                    var skill = tree[level][i];
                    var skillButton = skill.Item2;
                    var alignment = alignments[level][i];
                    setUpSkillButton(skillButton, alignment);
                }
            }
        }

        private void setUpSkillButton(SkillButton skillButton, Alignment alignment)
        {
            skillButton.VAlign = alignment.vertical;
            skillButton.HAlign = alignment.horizontal;
            skillPanel.Append(skillButton);
        }

        public override void OnInitialize()
        {
            base.OnInitialize();
            var width = 900f;
            var height = 700f;
            skillPanel = new SkillPanel
            {
                HAlign = 0.5f,
                VAlign = 0.5f
            };
            skillPanel.Width.Set(width, 0f);
            skillPanel.Height.Set(height, 0f);

            skillPanel.BackgroundColor = BACKGROUD_PANEL_COLOR;

            Append(skillPanel);
        }

        public void show()
        {
            visible = true;
        }

        public void hide()
        {
            visible = false;
        }

        public bool isVisible()
        {
            return visible;
        }



    }

}
