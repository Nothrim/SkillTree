using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkillTree.Core
{
    class Skill
    {
        private readonly string name;
        private readonly string iconPath;
        private readonly string displayName;
        private readonly string tooltip;
        private readonly int cost;
        private readonly int cooldown;
        private bool used = false;
        private readonly int chance;
        private readonly int level;
        private readonly List<Skill> requirements;

        public Skill(string name, string iconPath, string displayName, string tooltip, bool used = false,  int level, int chance = 0, int cost = 0, int cooldown = 0, List<Skill> requirements = null)
        {
            this.name = name;
            this.iconPath = iconPath;
            this.displayName = displayName;
            this.tooltip = tooltip;
            this.cost = cost;
            this.cooldown = cooldown;
            this.used = used;
            this.chance = chance;
            this.level = level;
            if (requirements == null)
            {
                this.requirements = new List<Skill>();
            }
            else
            {
                this.requirements = requirements;
            }
        }
    }
}
