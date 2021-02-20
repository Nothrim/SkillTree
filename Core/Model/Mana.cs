using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkillTree.Core.Model
{
    public class Mana
    {
        public readonly int amount;

        public Mana(int amount)
        {
            if(amount < 0)
            {
                throw new Exception("Mana cost canot be lesser than 0");
            }
            this.amount = amount;
        }
    }
}
