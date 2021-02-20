using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SkillTree.Core.Model;

namespace SkillTree.Core
{
    public class Skill
    {
        public readonly string name;
        public readonly string iconPath;
        public readonly string displayName;
        public readonly string tooltip;
        public readonly Mana cost;
        public readonly Second cooldown;
        public bool used = false;
        public bool useable = false;
        public bool learned { get; private set; } = false;
        public readonly int chance;
        public readonly int level;
        public readonly int skillPointsCost;
        public readonly List<Skill> requirements;

        public Skill(string name, string iconPath, string displayName, string tooltip, int? level = null, bool used = false, List<Skill> requirements = null, int chance = 0, Mana cost = null, Second cooldown = null, int skillPointsCost = 1, bool learned = false, bool useable = false)
        {
            var requirementsList = requirements ?? new List<Skill>();
            this.name = name;
            this.iconPath = iconPath;
            this.displayName = displayName;
            this.tooltip = tooltip;
            this.cost = cost ?? new Mana(0);
            this.cooldown = cooldown ?? new Second(0);
            this.used = used;
            this.chance = chance;
            this.level = getLevel(level, requirements);
            this.skillPointsCost = skillPointsCost;
            this.requirements = requirementsList;
            this.learned = learned;
            this.useable = useable;
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

        public static Skill blankSkill(string name, List<Skill> requirements = null)
        {
            return new Skill(name: name, iconPath: "SkillTree/Textures/UI/BlankFrame", displayName: "Blank skill", tooltip: "Does nothing but you can click it!", level: 1, requirements: requirements);
        }

        public void learn()
        {
            this.learned = true;
        }
    }
}