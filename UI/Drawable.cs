using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkillTree.UI
{
    interface Drawable
    {
        void DrawChildren(SpriteBatch sb);
        void DrawSelf(SpriteBatch sb);
    }
}
