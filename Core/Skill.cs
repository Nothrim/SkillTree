using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkillTree.Core
{
    public class Skill
    {
        public readonly string name;
        public readonly string iconPath;
        public readonly string displayName;
        public readonly string tooltip;
        public readonly int cost;
        public readonly int cooldown;
        public bool used = false;
        public readonly int chance;
        public readonly int level;
        public readonly List<Skill> requirements;

        public Skill(string name, string iconPath, string displayName, string tooltip, int? level = null, bool used = false, List<Skill> requirements = null, int chance = 0, int cost = 0, int cooldown = 0)
        {
            var requirementsList = requirements ?? new List<Skill>();
            this.name = name;
            this.iconPath = iconPath;
            this.displayName = displayName;
            this.tooltip = tooltip;
            this.cost = cost;
            this.cooldown = cooldown;
            this.used = used;
            this.chance = chance;
            this.level = getLevel(level,requirements);
            this.requirements = requirementsList;
        }

        private int getLevel(int? level, List<Skill> parents)
        {
            int outputLevel = level ?? getLevelFromParents(parents);
            if (outputLevel == 0 && !(this.GetType() == typeof(Way))) throw new ArgumentException("Skill must be a Way to be attached at root level");
            
            return outputLevel;
        }

        private int getLevelFromParents(List<Skill> parents)
        {
            if (parents == null || parents.Count == 0) return 1;
            return parents
                .Select(skill => skill.level)
                .Max() + 1;
        }

        public static Skill blankSkill()
        {
            return new Skill(name:"blank",iconPath:"", displayName:"Blank skill", tooltip:"Does nothing but you can click it!", level:1);
        }
    }
}
