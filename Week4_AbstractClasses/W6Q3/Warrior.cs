using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week4Abstract.W6Q3
{
    internal class Warrior : Character
    {
        public Warrior() : base(0, 300, 120)
        {
        }

        public override void Attack(Character target)
        {
            target.health -= this.damage;
        }
    }
}
