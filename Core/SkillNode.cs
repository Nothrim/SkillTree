using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkillTree.Core
{
    public class SkillNode 
    {
        private readonly Skill value;
        private readonly List<SkillNode> parents;
        private readonly SkillNode mainParent;
        private readonly List<SkillNode> children;

        public SkillNode(Skill value, SkillNode mainParent = null, List<SkillNode> children =null, List<SkillNode> parents=null)
        {
            this.value = value;
            this.mainParent = mainParent;
            this.children = children ?? new List<SkillNode>();
            this.parents = parents ?? new List<SkillNode>();
        }

        public void addChild(SkillNode skillNode)
        {
            if (!children.Contains(skillNode))
            {
                children.Add(skillNode);
            }
        }

        public void addParent(SkillNode parent)
        {
            if (!parents.Contains(parent))
            {
                parents.Add(parent);
            }
        }
        public void addChildren(List<SkillNode> children)
        {
            this.children.AddRange(children);
        }

        public Skill getSkill()
        {
            return value;
        }
        public List<SkillNode> getChildren()
        {
            return children;
        }

        public SkillNode getMainParent()
        {
            return mainParent;
        }
    }
}
