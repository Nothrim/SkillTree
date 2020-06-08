using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria.ModLoader;

namespace SkillTree.Controls
{
    class HotkeyConfiguration
    {
        public static readonly String TOGGLE_UI = "toggleUI";
        private readonly Dictionary<String,ModHotKey> hotkeys = new Dictionary<string, ModHotKey>();

        public HotkeyConfiguration(Mod mod)
        {
            hotkeys.Add(TOGGLE_UI,mod.RegisterHotKey(TOGGLE_UI, "X"));
        }

        public ModHotKey getHotKey(String name)
        {
            return hotkeys[name];
        }
    }
}
