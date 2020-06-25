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
        private Dictionary<String, List<Skill>> parents = new Dictionary<String, List<Skill>>();
        public SkillTreeBuilder(SkillDefinitionLoader skillDefinitionLoader)
        {
            this.skillDefinitionLoader = skillDefinitionLoader;
        }

        public SkillNode getSkillTree(Way way)
        {
            buildSkillTree();
            var root = new SkillNode(way, null);
            var rootChildren =  findChildren(root);
            root.addChildren(rootChildren);
            return root;
        }

        private List<SkillNode> findChildren(SkillNode parent)
        {
            var children = parents[parent.getSkill().name];
            var childNodes = new List<SkillNode>();

            if (children.Count >0 )
            {
                foreach(var child in children)
                {
                    var childNode = new SkillNode(child, parent);
                    var foundNodeChildren = findChildren(childNode);
                    childNode.addChildren(foundNodeChildren);
                    childNodes.Add(childNode);
                }
            }

            return childNodes;
        }

        private void buildSkillTree()
        {
            foreach(var skill in skillDefinitionLoader.getAll())
            {
                parents.Add(skill.name, new List<Skill>());
            }

            skillDefinitionLoader.getAll()
                .Where(skill => skill.requirements.Count > 0)
                .ToList()
                .ForEach(skillWithRequirements => fillInParents(skillWithRequirements));
        }

        private void fillInParents(Skill skill)
        {
            skill.requirements.ForEach(parent => parents[parent.name].Add(skill));
        }


    }
}
