using SkillTree.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;

using SkillTreeVisualisation = System.Collections.Generic.List<System.Collections.Generic.List<System.Tuple<SkillTree.Core.SkillNode, SkillTree.UI.SkillButton>>>;
namespace SkillTree.UI
{
    class SkillTreeVisualiser
    {
        private SkillNode root;
        private List<List<SkillNode>> skillsByLevel = new List<List<SkillNode>>();
        private SkillTreeVisualisation nodesWithButtons = new SkillTreeVisualisation();
        private Action<Skill> onSkillPicked;
        private Dictionary<SkillNode, SkillButton> skillNodeToButton = new Dictionary<SkillNode, SkillButton>();

        public SkillTreeVisualiser(SkillNode root = null, Action<Skill> onSkillPicked=null)
        {
            if (root != null)
            {
                build(root, onSkillPicked);
            }
        }

        public SkillTreeVisualisation getSkillTree()
        {
            return nodesWithButtons;
        }

        public SkillButton getButton(SkillNode node)
        {
            return skillNodeToButton[node];
        }

        public void build(SkillNode root = null, Action<Skill> onSkillPicked = null)
        {
            this.root = root;
            this.onSkillPicked = onSkillPicked;
            splitByLevels();
            pairWithButtons();

        }

        private void addSkill(SkillNode skill, int level)
        {
            while (skillsByLevel.Count <= level)
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
        private void pairWithButtons()
        {
            foreach (var level in skillsByLevel)
            {

                var pairedLevel = level
                    .Select(skillNode =>
                    {
                        var button = SkillButton.getSkillButton(skillNode.getSkill(), skill => { onSkillPicked.Invoke(skill); });
                        skillNodeToButton.Add(skillNode, button);
                        return new Tuple<SkillNode, SkillButton>(skillNode, button);
                    })
                    .ToList();
                nodesWithButtons.Add(pairedLevel);
            }
        }
    }


}
