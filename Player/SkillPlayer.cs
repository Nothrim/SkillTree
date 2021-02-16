using SkillTree.Controls;
using SkillTree.Core;
using SkillTree.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.GameInput;
using Terraria.ModLoader;

namespace SkillTree.Player
{
    public class SkillPlayer : ModPlayer
    {
        private int skillPoints = 10;

        private Way currentWay;


        public override void OnEnterWorld(Terraria.Player player)
        {
            base.OnEnterWorld(player);
            var mod = ModContent.GetInstance<SkillTreeMod>();
        }
  

        public override void ProcessTriggers(TriggersSet triggersSet)
        {
            base.ProcessTriggers(triggersSet);
            ModContent.GetInstance<SkillTreeMod>()?.hotkeyConfiguration.forEach((name, hotkey) =>
            {
                if (hotkey.JustPressed)
                {
                    doHotkeyAction(name);
                }
            });
        }

        public bool learnSkill(Skill skill)
        {
            if (skill.learned || skillPoints < skill.skillPointsCost) return false;
            skillPoints -= skill.skillPointsCost;
            skill.learn();

            return true;
        }

        private void doHotkeyAction(string name)
        {
            switch (name)
            {
                case HotkeyConfiguration.TOGGLE_UI:
                    ModContent.GetInstance<SkillTreeMod>()?.toggleUI(this);
                    break;
            }
        }

        public bool hasPickedWay()
        {
            return currentWay != null;
        }

        public void pickWay(Way way)
        {
            this.currentWay = way;
        }
    }
}
