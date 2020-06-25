using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkillTree.Core
{
    class SkillNode 
    {
        private readonly Skill value;
        private readonly SkillNode parent;
        private readonly List<SkillNode> children;

        public SkillNode(Skill value, SkillNode parent, List<SkillNode> children =null )
        {
            this.value = value;
            this.parent = parent;
            this.children = children != null? children : new List<SkillNode>();
        }

        public void addChild(SkillNode skillNode)
        {
            children.Add(skillNode);
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

        public SkillNode getParent()
        {
            return parent;
        }
    }
}
