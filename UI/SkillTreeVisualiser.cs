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
        }
        void build(SkillNode root)
        {
            this.root = root;
            int level = 0;
            Queue<SkillNode> toVisit = new Queue<SkillNode>();
            toVisit.Enqueue(root);
            while (toVisit.Count > 0)
            {
                var node = toVisit.Dequeue();
                foreach (var child in node.getChildren())
                {
                    toVisit.Enqueue(child);
                }
               Main.NewText(node.getSkill().name);
            }
            
        }



    }
}
