using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
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
    class SkillButton : UIImageButton
    {

        private static readonly float SKILL_FRAME_SIZE = 50f;
        private readonly Skill skill;
        private readonly Action<Skill> onClick;
        private int unlearnedSkillFrameSizeModificator = -10;

        public SkillButton(Skill skill, Action<Skill> onClick) : base(ModContent.GetTexture(skill.iconPath))
        {
            this.skill = skill;
            this.onClick = onClick;
            this.SetVisibility(0.5f, 0.35f);
            this.Width.Set(SKILL_FRAME_SIZE + unlearnedSkillFrameSizeModificator, 0);
            this.Height.Set(SKILL_FRAME_SIZE + unlearnedSkillFrameSizeModificator, 0);
        }


        public static SkillButton getSkillButton(Skill skill, Action<Skill> onClick)
        {
            var skillButton = new SkillButton(skill, onClick);

            skillButton.OnClick += skillButton.onSkillFrameClicked;
            skillButton.OnMouseOver += skillButton.onMouseOver;
            skillButton.OnMouseOut += skillButton.onMouseOut;

            return skillButton;
        }

        private void onSkillFrameClicked(UIMouseEvent evt, UIElement listeningElement)
        {
            onClick.Invoke(skill);
            if (skill.learned && unlearnedSkillFrameSizeModificator != 0)
            {
                unlearnedSkillFrameSizeModificator = 0;
                this.SetVisibility(1f, 1f);
                this.Width.Set(SKILL_FRAME_SIZE, 0);
                this.Height.Set(SKILL_FRAME_SIZE, 0);
            }
        }

        private void onMouseOver(UIMouseEvent evt, UIElement listeningElement)
        {
            this.Width.Set(SKILL_FRAME_SIZE + 10 + unlearnedSkillFrameSizeModificator, 0);
            this.Height.Set(SKILL_FRAME_SIZE + 10 + unlearnedSkillFrameSizeModificator, 0);
        }

        private void onMouseOut(UIMouseEvent evt, UIElement listeningElement)
        {
            this.Width.Set(SKILL_FRAME_SIZE + unlearnedSkillFrameSizeModificator, 0);
            this.Height.Set(SKILL_FRAME_SIZE + unlearnedSkillFrameSizeModificator, 0);
        }


        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime); // don't remove.
                                   // Checking ContainsPoint and then setting mouseInterface to true is very common. This causes clicks on this UIElement to not cause the player to use current items. 
            if (ContainsPoint(Main.MouseScreen))
            {
                Main.LocalPlayer.mouseInterface = true;
            }

        }

        protected override void DrawSelf(SpriteBatch spriteBatch)
        {
            base.DrawSelf(spriteBatch);
            if (IsMouseHovering)
            {
                Main.hoverItemName = skill.displayName + "\n" + skill.tooltip;
            }
        }

    }
}
