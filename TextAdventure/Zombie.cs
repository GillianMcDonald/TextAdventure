using System;
using System.Collections.Generic;
using System.Text;

namespace TextAdventure
{   //abstract class - can't be instantiated
    abstract class Zombie : IZombie
    {
        private readonly Location _location;
        public bool HasHit { get; set; }
           
        public abstract int ZombieHealth { get; protected set; }
        public abstract int ZombieHitPower { get; protected set; }
        public bool ZombieNeutralized { get; set; }
        public bool ZombieActive { get; set; }

        Location IMappable.Location => throw new NotImplementedException();

        

        public Location Location()
        {

            return null;
        }
        //set as virtual so it's polymorphic and I can set the method for each type of zombie
        public virtual void DecreaseZombieHealth(int factor)
            {
                ZombieHealth -= factor;
                Console.WriteLine("Zombie hit!");
            }

        public void Move()
        {
            throw new NotImplementedException();
        }
    }
}
