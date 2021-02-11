using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkillTree.Core
{
    public class Alignment
    {
        public float vertical { get; private set; }
        public float horizontal { get; private set; }

        public Alignment(float horizontal, float vertical)
        {
            this.vertical = vertical;
            this.horizontal = horizontal;
        }
    }
}
