using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria.ModLoader;

namespace SkillTree.UI
{
    class Line : Drawable
    {
        public readonly Vector2 begin;
        public readonly Vector2 end;
        private static readonly Texture2D BASIC_LINE = ModContent.GetTexture("SkillTree/Textures/UI/1x1");
        private static readonly Color BASIC_COLOR = Color.White;
        private static readonly int DEFAULT_LINE_THICCNESS = 5;

        public Line(Vector2 begin,Vector2 end)
        {

            this.begin = begin;
            this.end = end;
        }

        public void DrawChildren(SpriteBatch sb)
        {
            throw new NotImplementedException();
        }

        public void DrawSelf(SpriteBatch sb)
        {
            Rectangle line = new Rectangle((int)begin.X, (int)begin.Y, (int)(end - begin).Length() - DEFAULT_LINE_THICCNESS, DEFAULT_LINE_THICCNESS);
            Vector2 distance = Vector2.Normalize(begin - end);
            float angle = (float)Math.Acos(Vector2.Dot(distance, -Vector2.UnitX));
            if(begin.Y > end.Y)
            {
                angle = MathHelper.TwoPi - angle;
            }

            sb.Draw(BASIC_LINE, line, null, BASIC_COLOR, angle, Vector2.Zero, SpriteEffects.None, 0);
        }
    }
}
