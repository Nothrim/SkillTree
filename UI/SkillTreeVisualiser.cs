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
        List<List<SkillNode>> levels = new List<List<SkillNode>>();
        private SkillNode root;

        public SkillTreeVisualiser(SkillNode root)
        {
            this.root = root;
            build();
        }
        void build()
        {
            Queue<SkillNode> toVisit = new Queue<SkillNode>();
            toVisit.Enqueue(root);
            ISet<SkillNode> visited = new HashSet<SkillNode>();
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
                visited.Add(node);
            }
            foreach(SkillNode node in visited){
                Main.NewText(node.getSkill().name);
            }
            
        }



    }
}
