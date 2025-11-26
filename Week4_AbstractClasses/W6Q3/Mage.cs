using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week4Abstract.W6Q3
{
    internal class Mage : Character
    {
        public Mage() : base(300, 100, 50)
        {
        }

        public override void Attack(Character target)
        {
            this.mana -= 100;
            target.health -= 2 * this.damage;
        }
    }
}
