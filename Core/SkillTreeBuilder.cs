using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkillTree.Core
{
    class SkillTreeBuilder
    {

        private readonly SkillDefinitionLoader skillDefinitionLoader;
        private Dictionary<String, SkillNode> skillNodes = new Dictionary<String, SkillNode>();
        public SkillTreeBuilder(SkillDefinitionLoader skillDefinitionLoader)
        {
            this.skillDefinitionLoader = skillDefinitionLoader;
        }

        public SkillNode getSkillTree(Way way)
        {
            buildSkillTree();

            return skillNodes[way.name];
        }

        private void buildSkillTree()
        {
            foreach (var skill in skillDefinitionLoader.getAll())
            {
                var skillNode = skillNodes.ContainsKey(skill.name) ? skillNodes[skill.name] : new SkillNode(skill);
                skill.requirements.ForEach(requirement =>
                {
                    var requiredNode = skillNodes.ContainsKey(requirement.name) ? skillNodes[requirement.name] : new SkillNode(requirement);
                    skillNode.addParent(requiredNode);
                    requiredNode.addChild(skillNode);
                    skillNodes[requirement.name] = requiredNode;
                });
                skillNodes[skill.name] = skillNode;
            }
        }
    }
}
