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
        public static class Names
        {
            public static readonly string LAYERED_ARMOR = "layeredArmor";
            public static readonly string BLOCK = "block";
            public static readonly string TROLLS_BLOOD = "trollsBlood";
            public static readonly string MIRROR_SHIELD = "mirrorShield";
            public static readonly string THROW = "throw";
            public static readonly string SHOCKWAVE = "shockwave";
            public static readonly string ENDER_LEGACY = "enderLegacy";
        }

        public static class Ways
        {
            public static readonly string MIGHT = "might";
            public static readonly string MAGIC_ELEMENT = "magicElement";
            public static readonly string MARKSMANSHIP = "marksmanship";
        }
        private readonly Dictionary<String, Skill> skillDefinitions = new Dictionary<string, Skill>();

        public void loadSkills()
        {
            var might = loadMight();
            var layeredArmor = loadLayeredArmor(new List<Skill> { might });
            var block = loadBlock(new List<Skill> { layeredArmor });
            var trollsBlood = loadTrollsBlood(new List<Skill> { block });
            var mirrorShield = loadMirrorShield(new List<Skill> { trollsBlood });
            var throwSkill = loadThrow(new List<Skill> { mirrorShield });
            var shockwave = loadShockwave(new List<Skill> { throwSkill });
            var enderLegacy = loadEnderLegacy(new List<Skill> { shockwave });
            var magicElement = loadMagicElement();
            var marksmanship = loadMarksmanship();
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
            return skillDefinitions.Values
                 .Where(skill => skill is Way)
                 .Select(skill => (Way)skill)
                 .ToList();
        }

        public List<Skill> getAll()
        {
            return skillDefinitions.Values.ToList();
        }

        private Way loadMight()
        {
            string skillName = Ways.MIGHT;
            Way skill = new Way(
            name: skillName
            , displayName: "Might"
            , iconPath: "SkillTree/Textures/Icons/Might!"
            , tooltip: "10% increased damage with melee hits"
            , level: 0
            );
            skillDefinitions[skillName] = skill;

            return skill;
        }

        private Way loadMagicElement()
        {
            string skillName = Ways.MAGIC_ELEMENT;
            Way skill = new Way(
            name: skillName
            , displayName: "MagicElement"
            , iconPath: "SkillTree/Textures/Icons/MagicElement"
            , tooltip: "Grants various attributes required for beginer mages"
            , level: 0
            );
            skillDefinitions[skillName] = skill;

            return skill;
        }

        private Way loadMarksmanship()
        {
            string skillName = Ways.MAGIC_ELEMENT;
            Way skill = new Way(
            name: skillName
            , displayName: "Marksmanship"
            , iconPath: "SkillTree/Textures/Icons/Marksmanship"
            , tooltip: "+1 penetration on all projectiles"
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
            , iconPath: "SkillTree/Textures/Icons/LayeredArmor"
            , tooltip: "Gain armor layers when not fighting I:(Always On)+5 Armor,II:+10 armor,III:+15 armor"
            , level: 1
            , requirements: requiredSkills
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
            , iconPath: "SkillTree/Textures/Icons/Block"
            , tooltip: "Block incoming damage [10% chance]"
            , level: 2
            , requirements: requiredSkills
            );
            skillDefinitions[skillName] = skill;

            return skill;
        }

        private Skill loadTrollsBlood(List<Skill> requiredSkills)
        {
            string skillName = Names.TROLLS_BLOOD;
            Skill skill = new Skill(
             name: skillName
            , displayName: "Trolls Blood"
            , iconPath: "SkillTree/Textures/Icons/TrollsBlood"
            , tooltip: "Provides hastened regeneration when in danger "
            , level: 3
            , cooldown: new Second(60)
            , cost: new Model.Mana(50)
            , requirements: requiredSkills
            ,useable: true
            );
            skillDefinitions[skillName] = skill;

            return skill;
        }


        private Skill loadMirrorShield(List<Skill> requiredSkills)
        {
            string skillName = Names.MIRROR_SHIELD;
            Skill skill = new Skill(
             name: skillName
            , displayName: "Trolls Blood"
            , iconPath: "SkillTree/Textures/Icons/MirrorShield"
            , tooltip: "Parry incoming hits/projectiles"
            , cooldown: new Second(5)
            , level: 4
            , requirements: requiredSkills
            , useable: true
            );
            skillDefinitions[skillName] = skill;

            return skill;
        }



        private Skill loadThrow(List<Skill> requiredSkills)
        {
            string skillName = Names.THROW;
            Skill skill = new Skill(
             name: skillName
            , displayName: "Trolls Blood"
            , iconPath: "SkillTree/Textures/Icons/Throw"
            , tooltip: "Throw closest enemy to mouse direction"
            , cooldown: new Second(5)
            , level: 5
            , requirements: requiredSkills
            , useable: true
            );
            skillDefinitions[skillName] = skill;

            return skill;
        }

        private Skill loadShockwave(List<Skill> requiredSkills)
        {
            string skillName = Names.SHOCKWAVE;
            Skill skill = new Skill(
             name: skillName
            , displayName: "Trolls Blood"
            , iconPath: "SkillTree/Textures/Icons/Shockwave"
            , tooltip: "Shoot 2 projectiles in both directions, which deal damage equal to your current health"
            , cooldown: new Second(5)
            , cost: new Model.Mana(40)
            , level: 6
            , requirements: requiredSkills
            , useable: true
            );
            skillDefinitions[skillName] = skill;

            return skill;
        }

        private Skill loadEnderLegacy(List<Skill> requiredSkills)
        {
            string skillName = Names.ENDER_LEGACY;
            Skill skill = new Skill(
             name: skillName
            , displayName: "Trolls Blood"
            , iconPath: "SkillTree/Textures/Icons/EnderLegacy"
            , tooltip: "Recived damage heals you"
            , cooldown: new Second(120)
            , cost: new Model.Mana(100)
            , level: 7
            , requirements: requiredSkills
            , useable: true
            );
            skillDefinitions[skillName] = skill;

            return skill;
        }




        private Skill loadBlank(string name, List<Skill> requiredSkils = null)
        {
            var skill = Skill.blankSkill(name, requiredSkils);
            skillDefinitions[name] = skill;

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
