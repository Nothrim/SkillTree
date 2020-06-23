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
    class SkillPanel : UIPanel
    {

		private static readonly float SKILL_FRAME_SIZE = 50f;
		private static readonly Color SKILL_FRAME_COLOR = new Color(73, 93, 171);
		private static readonly Color SKILL_FRAME_CLICKED_COLOR = new Color(150, 150, 93);
		private Skill skill;
		private Texture2D skillIcon;

		public SkillPanel(Skill skill)
        {
			this.BackgroundColor = SKILL_FRAME_COLOR;
			this.skill = skill;
			this.skillIcon = ModContent.GetTexture(skill.iconPath);
        }

		public SkillPanel()
        {
			this.skill = Skill.blankSkill();
        }


		public static SkillPanel getSkillFrame(Skill skill)
        {
			var skillFrame = new SkillPanel(skill);
			skillFrame.Width.Set(SKILL_FRAME_SIZE, 0);
			skillFrame.Height.Set(SKILL_FRAME_SIZE, 0);
            skillFrame.OnClick += skillFrame.onSkillFrameClicked;
			skillFrame.OnMouseOver += skillFrame.onMouseOver;
			skillFrame.OnMouseOut += skillFrame.onMouseOut;
			return skillFrame;
        }

        private void onSkillFrameClicked(UIMouseEvent evt, UIElement listeningElement)
        {
			this.BackgroundColor = SKILL_FRAME_CLICKED_COLOR;
        }

		private void onMouseOver(UIMouseEvent evt, UIElement listeningElement)
        {
			this.BackgroundColor = SKILL_FRAME_CLICKED_COLOR;
			this.Width.Set(SKILL_FRAME_SIZE + 10, 0);
			this.Height.Set(SKILL_FRAME_SIZE + 10, 0);
		}

		private void onMouseOut(UIMouseEvent evt, UIElement listeningElement)
        {
			this.BackgroundColor = SKILL_FRAME_COLOR;
			this.Width.Set(SKILL_FRAME_SIZE, 0);
			this.Height.Set(SKILL_FRAME_SIZE, 0);
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
				Main.hoverItemName = skill.tooltip;
			}
            if (skillIcon != null)
            {
				//spriteBatch.Draw(skillIcon,this.X);
            }
		}

    }
}
