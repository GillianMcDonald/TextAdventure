using System;
using System.Collections.Generic;
using System.Text;

namespace TextAdventure
{
    class ZombieKing : Enemy
    {
        public override int EnemyHealth { get; protected set; } = 100;

        public override int EnemyHitPower { get; protected set; } = 50;

        public override string EnemyName { get; protected set; }
        

        public ZombieKing(Location location, string name)
        {
            this.EnemyName = name;
        }

        public string GetEnemyName()
        {
            return EnemyName;
        }
    }
}
