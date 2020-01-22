using System;
using System.Collections.Generic;
using System.Text;

namespace TextAdventure
{
    class Mage : Enemy
    {
        public override int EnemyHealth { get; protected set; } = 50;

        public override int EnemyHitPower { get; protected set; } = 25;

        public override string EnemyName { get; protected set; }


        public Mage(Location location, string name)
        {
            this.EnemyName = name;
        }

    }
}
