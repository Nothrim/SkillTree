using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.GameContent.UI.Elements;
using Terraria.UI;

namespace SkillTree.UI
{
    class SkillPanel : UIPanel
    {
		private Vector2 offset;
		public bool dragging;
		private static readonly float SKILL_FRAME_SIZE = 50f;
		private static readonly Microsoft.Xna.Framework.Color SKILL_FRAME_COLOR = new Microsoft.Xna.Framework.Color(73, 93, 171);
		private static readonly Microsoft.Xna.Framework.Color SKILL_FRAME_CLICKED_COLOR = new Microsoft.Xna.Framework.Color(150, 150, 93);

		public SkillPanel()
        {
			this.BackgroundColor = SKILL_FRAME_COLOR;
        }


		public static SkillPanel getSkillFrame()
        {
			var skillFrame = new SkillPanel();
			skillFrame.Width.Set(SKILL_FRAME_SIZE, 0);
			skillFrame.Height.Set(SKILL_FRAME_SIZE, 0);
			return skillFrame;
        }
		public override void MouseDown(UIMouseEvent evt)
		{
			base.MouseDown(evt);
			DragStart(evt);
			this.BackgroundColor = SKILL_FRAME_CLICKED_COLOR;
		}

		public override void MouseUp(UIMouseEvent evt)
		{
			base.MouseUp(evt);
			Main.NewText("clicked");
			DragEnd(evt);
			this.BackgroundColor = SKILL_FRAME_COLOR;
		}

		private void DragStart(UIMouseEvent evt)
		{
			offset = new Vector2(evt.MousePosition.X - Left.Pixels, evt.MousePosition.Y - Top.Pixels);
			dragging = true;
		}

		private void DragEnd(UIMouseEvent evt)
		{
			Vector2 end = evt.MousePosition;
			dragging = false;

			Left.Set(end.X - offset.X, 0f);
			Top.Set(end.Y - offset.Y, 0f);

			Recalculate();
		}

		public override void Update(GameTime gameTime)
		{
			base.Update(gameTime); // don't remove.
			// Checking ContainsPoint and then setting mouseInterface to true is very common. This causes clicks on this UIElement to not cause the player to use current items. 
			if (ContainsPoint(Main.MouseScreen))
			{
				Main.LocalPlayer.mouseInterface = true;
			}

			if (dragging)
			{
				Left.Set(Main.mouseX - offset.X, 0f); // Main.MouseScreen.X and Main.mouseX are the same.
				Top.Set(Main.mouseY - offset.Y, 0f);
				Recalculate();
			}

			// Here we check if the DragableUIPanel is outside the Parent UIElement rectangle. 
			// (In our example, the parent would be ExampleUI, a UIState. This means that we are checking that the DragableUIPanel is outside the whole screen)
			// By doing this and some simple math, we can snap the panel back on screen if the user resizes his window or otherwise changes resolution.
			var parentSpace = Parent.GetDimensions().ToRectangle();
			if (!GetDimensions().ToRectangle().Intersects(parentSpace))
			{
				Left.Pixels = Utils.Clamp(Left.Pixels, 0, parentSpace.Right - Width.Pixels);
				Top.Pixels = Utils.Clamp(Top.Pixels, 0, parentSpace.Bottom - Height.Pixels);
				// Recalculate forces the UI system to do the positioning math again.
				Recalculate();
			}
		}
	}
}
