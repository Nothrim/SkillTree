using SkillTree.Controls;
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
    class Player : ModPlayer
    {

        public override void ProcessTriggers(TriggersSet triggersSet)
        {
            base.ProcessTriggers(triggersSet);
            SkillTreeMod.GetInstance()?.hotkeyConfiguration.forEach((name, hotkey) =>
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
                    SkillTreeMod.GetInstance()?.toggleUI();
                    break;
            }
        }
    }
}
