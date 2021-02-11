using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkillTree.Core
{
    public class LevelSize
    {
        public float value { get; private set; }

        public LevelSize(int value)
        {
            this.value = value;
        }
    }
}
