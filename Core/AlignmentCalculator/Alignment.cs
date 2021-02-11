using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkillTree.Core
{
    class Alignment
    {
        private float vertical { get; }
        private float horizontal { get; }

        public Alignment(float horizontal, float vertical)
        {
            this.vertical = vertical;
            this.horizontal = horizontal;
        }
    }
}
