
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

namespace SkillTree.UI
{
    class ChoiceUI : UIState, UIItem
    {
        private static readonly Microsoft.Xna.Framework.Color BACKGROUD_PANEL_COLOR = new Microsoft.Xna.Framework.Color(73, 93, 171, 210);
        private SkillPanel skillPanel;
        private bool visible = false;
        private List<Way> choices;
        private static readonly int SKILL_FRAME_DISTANCE = 90;

        public ChoiceUI(List<Way> choices){
            this.choices = choices;
        }

        public override void OnInitialize()
        {
            base.OnInitialize();
            var width = choices.Count * SKILL_FRAME_DISTANCE;
            var height = 100;
            skillPanel = new SkillPanel
            {
                HAlign = 0.5f,
                VAlign = 0.5f
            };
            skillPanel.Width.Set(width, 0f);
            skillPanel.Height.Set(height, 0f);

            skillPanel.BackgroundColor = BACKGROUD_PANEL_COLOR;
            List<SkillPanel> panels = choices
                .Select(choice => SkillPanel.getSkillFrame(choice))
                .ToList();
            foreach(int i in Enumerable.Range(0,panels.Count))
            {
                var currentPanel = panels[i];
                currentPanel.Left.Set(i * SKILL_FRAME_DISTANCE, 0f);
                currentPanel.HAlign = 0.5f;
                skillPanel.Append(currentPanel);

            }

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
