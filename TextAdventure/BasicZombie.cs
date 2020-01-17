using System;
using System.Collections.Generic;
using System.Text;

namespace TextAdventure
{
    class BasicZombie : Zombie
    {
        public override int ZombieHealth { get; protected set; } = 25;

        public override int ZombieHitPower { get; protected set; } = 25;

        public string ZombieName { get; private set; }


        public BasicZombie(Location location, string name)
        {
            this.ZombieName = name;
        }

        public string GetZombieName()
        {
            return ZombieName;
        }

        //when zombies are created, need to be given a location 
        //could you have it that when you re-enter a room a new zombie is created in that room?
    }
}
