using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SkillTreeVisualisation = System.Collections.Generic.List<System.Collections.Generic.List<System.Tuple<SkillTree.Core.SkillNode, SkillTree.UI.SkillButton>>>;

namespace SkillTree.Core
{
    public class SkillAlignmentCalculator
    {
        private static readonly float MAX_SKILL_PANEL_SPACING = 0.1f;
        List<List<Alignment>> calculateAlignment(SkillTreeVisualisation tree)
        {
            var allignBetweenLevels = Math.Min(1.0f / tree.Count, MAX_SKILL_PANEL_SPACING);
            var alignments = new List<List<Alignment>>();


            for (int level = 0; level < tree.Count; level++)
            {
                var skillsOnLevel = tree[level].Count;
                var aligmentsForLevel = new List<Alignment>();
                if (skillsOnLevel == 1)
                {
                    aligmentsForLevel.Add(new Alignment(horizontal: 0.5f, vertical: allignBetweenLevels * level));
                }
                else if(skillsOnLevel % 2==0)
                {
                    var allignBetweenSkills = 1.0f / skillsOnLevel;
                    for (int i = 0; i < skillsOnLevel; i++)
                    {
                        aligmentsForLevel.Add(new Alignment(allignBetweenSkills * (i + 1), allignBetweenLevels * level));
                    }
                }
                else
                {
                    var midlleSkill = (int)(Math.Floor((double) skillsOnLevel) + 1);
                    var skillsOnLeftAndRight = skillsOnLevel - midlleSkill;
                    var spaceLeft = 0.5f / skillsOnLeftAndRight;

                    for(int i =0;i < skillsOnLeftAndRight; i++)
                    {
                        aligmentsForLevel.Add(new Alignment(horizontal: skillsOnLeftAndRight * i, vertical: allignBetweenLevels * level));
                    }
                    aligmentsForLevel.Add(new Alignment(horizontal: 0.5f, vertical: allignBetweenLevels * level));
                    for (int i = 0; i < skillsOnLeftAndRight; i++)
                    {
                        aligmentsForLevel.Add(new Alignment(horizontal: skillsOnLeftAndRight * (i + skillsOnLeftAndRight +1), vertical: allignBetweenLevels * level);
                    }

                }
                alignments.Add(aligmentsForLevel);
            }
            return alignments;
        }

    }
}
