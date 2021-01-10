using SkillTree.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;

namespace SkillTree.UI
{
    class SkillTreeVisualiser
    {
        private SkillNode root;
        private List<List<SkillNode>> skillsByLevel = new List<List<SkillNode>>();

        public SkillTreeVisualiser(SkillNode root)
        {
            this.root = root;
            build();
        }

        void build()
        {
           splitByLevels();
            
        }

        private void addSkill(SkillNode skill , int level)
        {
            while(skillsByLevel.Count < level)
            {
                skillsByLevel.Add(new List<SkillNode>());
            }
            if (!skillsByLevel[level].Contains(skill))
            {
                skillsByLevel[level].Add(skill);
            }
        }

        private void splitByLevels()
        {
            Queue<SkillNode> toVisit = new Queue<SkillNode>();
            toVisit.Enqueue(root);
            while (toVisit.Count > 0)
            {
                var node = toVisit.Dequeue();
                foreach (var child in node.getChildren())
                {
                    toVisit.Enqueue(child);
                }
                /*
                 Solve case when child has multiple parents since basic algo just duplicates it
                 */
                addSkill(node, node.getSkill().level);
            }
        }

        private List<List<SkillNode>> assignPositions(List<List<SkillNode>> skills)
        {
            return null;
        }

        private List<List<SkillNode>> swapPositionsToPreventOverlaping(List<List<SkillNode>> skills)
        {
            return null;
        }



    }
}
