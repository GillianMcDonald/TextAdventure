using System;
using System.Collections.Generic;
using System.Text;

namespace TextAdventure
{
    //interfaces don't have constructors, like abstract classes they can't be instantiated. They don't need virutal or abstract     
    //modifiers or use public keywords.  It doesn't need setters -they are set in the subclasses (the classes that inherit from IZombie)
    //thes are the recipe of what other subclasses should have. 
     //You can have multiple interfaces in one abstract class. 

    interface IMappable
        {
            Location Location { get; }
        }

    interface IMovable
        {
        void Move();
        }
    interface IEnemy : IMappable, IMovable
        {
            int EnemyHealth { get; }
          
            int EnemyHitPower { get; }
        void DecreaseEnemyHealth(int factor, Enemy name);
        }
}
