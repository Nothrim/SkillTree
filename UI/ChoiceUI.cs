
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
        private Action<Way> onWayPicked;

        public ChoiceUI(List<Way> choices,Action<Way> onWayPicked){
            this.choices = choices;
            this.onWayPicked = onWayPicked;
        }

        public override void OnInitialize()
        {
            base.OnInitialize();
            var width = choices.Count * SKILL_FRAME_DISTANCE + 2*SKILL_FRAME_DISTANCE;
            var height = 100;
            skillPanel = new SkillPanel
            {
                HAlign = 0.5f,
                VAlign = 0.5f
            };
            skillPanel.Width.Set(width, 0f);
            skillPanel.Height.Set(height, 0f);

            skillPanel.BackgroundColor = BACKGROUD_PANEL_COLOR;
            List<SkillButton> panels = choices
                .Select(choice => SkillButton.getSkillButton(choice,skill => onWayPicked.Invoke(skill as Way)))
                .ToList();
            foreach(int i in Enumerable.Range(0,panels.Count))
            {
                var currentPanel = panels[i];
                currentPanel.Left.Set((i+1) * SKILL_FRAME_DISTANCE, 0f);
                currentPanel.VAlign = 0.5f;
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
