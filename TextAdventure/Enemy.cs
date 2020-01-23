using System;
using System.Collections.Generic;
using System.Text;

namespace TextAdventure
{   //abstract class - can't be instantiated
    abstract class Enemy : IEnemy
    {
        private readonly Location _location;
           
        public abstract int EnemyHealth { get; protected set; }
        public abstract int EnemyHitPower { get; protected set; }
        public abstract string EnemyName { get; protected set; }

        Location IMappable.Location => throw new NotImplementedException();

       

        public Location Location()
        {

            return null;
        }
        //set as virtual so it's polymorphic and I can set the method for each type of zombie
        public virtual void DecreaseEnemyHealth(int factor, Enemy name)
            {
                EnemyHealth -= factor;
                Console.WriteLine(name.GetEnemyName() + " got hit!");
            }

        public void Move()
        {
            throw new NotImplementedException();
        }

        public string GetEnemyName()
        {
            return EnemyName;
        }

        
    }
}
