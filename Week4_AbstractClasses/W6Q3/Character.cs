using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week4Abstract.W6Q3
{
    public abstract class Character : IAttack
    {
        public int mana { get; set; }
        public int health { get; set; }
        public int damage { get; set; }

        protected Character(int Mana, int Health, int Damage)
        {
            mana = Mana;
            health = Health;
            damage = Damage;
        }
        public abstract void Attack(Character target);
    }
}
