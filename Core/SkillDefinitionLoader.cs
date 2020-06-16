using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria.ModLoader;

namespace SkillTree.Core
{
    public class SkillDefinitionLoader
    {
        public static class Names {
            public static readonly string MIGHT = "might";
            public static readonly string LAYERED_ARMOR = "layeredArmor";
            public static readonly string BLOCK = "block";
        }

        public static class Ways
        {
            public static readonly string MIGHT = "might";
        }
        private readonly Dictionary<String, Skill> skillDefinitions = new Dictionary<string, Skill>();

        public void loadSkills()
        {
            var might = loadMight();
            var layeredArmor = loadLayeredArmor(new List<Skill> { might });
            var block = loadBlock(new List<Skill> { layeredArmor });
        }

        public Way getWay(String name)
        {
            if (!skillDefinitions.ContainsKey(name)) return null;
            return (Way)skillDefinitions[name];
        }

        public Skill getSkill(String name)
        {
            return skillDefinitions[name];
        }

        public List<Way> getAllWays()
        {
           return  skillDefinitions.Values
                .Where(skill => skill is Way)
                .Select(skill=>(Way) skill)
                .ToList();
        }

        private Way loadMight()
        {
           string skillName = Names.MIGHT;
           Way skill = new Way(
           name: skillName
           , displayName: "Might"
           , iconPath: "Textures/Icons/Might!"
           , tooltip: "10% increased damage with melee hits"
           , level: 0
           );
           skillDefinitions[skillName] = skill;
           
           return skill;
        }

        private Skill loadLayeredArmor(List<Skill> requiredSkills)
        {
            string skillName = Names.LAYERED_ARMOR;
            Skill skill = new Skill(
             name: skillName
            , displayName: "Layered Armor"
            , iconPath: "Textures/Icons/LayeredArmor"
            , tooltip: "Gain armor layers when not fighting I:(Always On)+5 Armor,II:+10 armor,III:+15 armor"
            , level: 0
            ,requirements: requiredSkills
            );
            skillDefinitions[skillName] = skill;

            return skill;
        }

        private Skill loadBlock(List<Skill> requiredSkills)
        {
            string skillName = Names.BLOCK;
            Skill skill = new Skill(
             name: skillName
            , displayName: "Block"
            , iconPath: "Textures/Icons/Block"
            , tooltip: "Block incoming damage [10% chance]"
            , level: 0
            , requirements: requiredSkills
            );
            skillDefinitions[skillName] = skill;

            return skill;
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
