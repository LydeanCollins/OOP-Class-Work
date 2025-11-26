using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week4Abstract.W6Q3
{
    internal class Priest : Character, IHeal
    {
        public Priest() : base(200, 125, 100)
        {
        }

        public override void Attack(Character target)
        {
            target.health -= this.damage;
            this.health += this.damage / 10;
        }

        public void Heal(Character target)
        {
            this.mana -= 100;   
            target.health += 150;
        }
    }
}
