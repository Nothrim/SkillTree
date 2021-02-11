using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkillTree.Core
{
    public class SkillAlignmentCalculator
    {
        private static readonly float MAX_SKILL_PANEL_SPACING = 0.2f;
        public List<List<Alignment>> calculateAlignment(List<LevelSize> levels)
        {
            var allignBetweenLevels = Math.Min(1.0f / levels.Count, MAX_SKILL_PANEL_SPACING);
            var alignments = new List<List<Alignment>>();


            for (int level = 0; level < levels.Count; level++)
            {

                var skillsOnLevel = levels[level].value;
                var aligmentsForLevel = new List<Alignment>();
                if (skillsOnLevel == 1)
                {
                    aligmentsForLevel.Add(new Alignment(vertical: 0.5f, horizontal: allignBetweenLevels * level));
                }
                else if(skillsOnLevel % 2==0)
                {
                    var allignBetweenSkills = 1.0f / skillsOnLevel;
                    for (int i = 0; i < skillsOnLevel; i++)
                    {
                        aligmentsForLevel.Add(new Alignment(vertical: allignBetweenSkills * (i + 1), horizontal: allignBetweenLevels * level));
                    }
                }
                else
                {
                    var midlleSkill = (int)(Math.Floor(skillsOnLevel/2d) + 1);
                    var skillsOnLeftAndRight = skillsOnLevel - midlleSkill;
                    var spaceLeft = 0.5f / skillsOnLeftAndRight;

                    for(int i =0;i < skillsOnLeftAndRight; i++)
                    {
                        aligmentsForLevel.Add(new Alignment(vertical: spaceLeft * i, horizontal: allignBetweenLevels * level));
                    }
                    aligmentsForLevel.Add(new Alignment(vertical: 0.5f, horizontal: allignBetweenLevels * level));
                    for (int i = 0; i < skillsOnLeftAndRight; i++)
                    {
                        aligmentsForLevel.Add(new Alignment(vertical: spaceLeft * (i + skillsOnLeftAndRight +1), horizontal: allignBetweenLevels * level));
                    }

                }
                alignments.Add(aligmentsForLevel);
            }
            return alignments;
        }

    }
}
