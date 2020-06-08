using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Terraria.ModLoader;

namespace SkillTree.Controls
{
    public class HotkeyConfiguration
    {
        public const string TOGGLE_UI = "toggleUI";
        private readonly Dictionary<String, ModHotKey> hotkeys = new Dictionary<string, ModHotKey>();

        public HotkeyConfiguration(Mod mod)
        {
            hotkeys.Add(TOGGLE_UI, mod.RegisterHotKey(TOGGLE_UI, "X"));
        }

        public ModHotKey getHotKey(String name)
        {
            return hotkeys[name];
        }

        public void forEach(Action<String, ModHotKey> lambda ){
            foreach(var entry in hotkeys)
            {
                lambda.Invoke(entry.Key, entry.Value);
            }
        }
    }
}
