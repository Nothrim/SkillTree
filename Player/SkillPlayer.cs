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
        private List<string> ownedSkills = new List<string> { SkillDefinitionLoader.Names.BLOCK, SkillDefinitionLoader.Names.LAYERED_ARMOR };
        private Way currentWay;
        private SkillDefinitionLoader skillDefinitionLoader;


        public override void OnEnterWorld(Terraria.Player player)
        {
            base.OnEnterWorld(player);
            var mod = ModContent.GetInstance<SkillTreeMod>();
            this.skillDefinitionLoader = mod.skillDefinitionLoader;
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
