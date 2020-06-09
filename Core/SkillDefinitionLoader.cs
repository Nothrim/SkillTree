using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria.ModLoader;

namespace SkillTree.Core
{
    class SkillDefinitionLoader
    {
        private readonly Dictionary<String, Skill> skillDefinitions = new Dictionary<string, Skill>();

        public void loadSkills()
        {

        }

        private void loadMight()
        {
            string skillName = "might";
            skillDefinitions[skillName] =
            new Skill(
            name: skillName
            , displayName: "Might"
            , iconPath: "Textures/Icons/Might!"
            , tooltip: "10% increased damage with melee hits"
            , level: 0
            );
        }
        public void fromJson(string name, string json)
        {
            Skill skill = JsonConvert.DeserializeObject<Skill>(json);
            if (!skillDefinitions.ContainsKey(name))
            {
                skillDefinitions[name] = skill;
            }
        }
    }
}
