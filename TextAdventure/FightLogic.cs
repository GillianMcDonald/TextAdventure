using System;
using System.Collections.Generic;
using System.Text;

namespace TextAdventure
{
    class FightLogic
    {
       
        
        public void LetsFight(Player name, BasicZombie BasicZombie, Location location)
        {
            Logic Logic = new Logic();
            Game Game = new Game();
            Actions Actions = new Actions();
            Console.Write("Player Hit Power is " + name.PlayerHitPower + " per hit. ");
            Console.WriteLine("Player Health is " + name.PlayerHealth);
            Console.Write("Zombie Hit Power is " + BasicZombie.ZombieHealth + " per hit. ");
            Console.WriteLine("Zombie Health is " + BasicZombie.ZombieHealth);
            Game.FightPrompt();

            while (true)
            {
                string FightAction = Console.ReadLine();

                if (FightAction == "1" || FightAction == "2" || FightAction == "3")
                {
                    if(FightAction == "1") //View my items
                    {
                        name.ViewPlayerItems();
                        Game.FightPrompt();

                    }
                    if(FightAction == "2") //Use an item
                    {
                        name.ViewPlayerItems();
                        if (name.PlayerItems.Count >= 1)
                        {
                            Console.WriteLine("Please type the name of the Item would you like to use");
                            string Item1 = Console.ReadLine();
                            bool Item1Result = name.DoesPlayerHaveItem(Item1); // check player has item

                            if (Item1Result == true)
                            {
                                Actions.UseItem(Item1, name);
                                Game.FightPrompt();
                            }
                            if (Item1Result == false)
                            {
                                Console.WriteLine("You have not picked up that item");
                                Game.FightPrompt();
                            }
                        }
                        else
                        {
                            Game.FightPrompt();
                        }
                    }
                    if(FightAction == "3") //Hit the Zombie
                    {

                        //should there be a separate class for this 
                        // while loop that while players health is greater than zero and zombies health is greater than zero they trade blows
                        // if only players health over 0 player wins - break out back to logic function 
                        //if only zombies health over o player loses - End Game
                        //start again button?



                        //decrease zombie health by player hit power
                        BasicZombie.DecreaseZombieHealth(name.PlayerHitPower);
                        if(BasicZombie.ZombieHealth > 0)
                        {
                            Console.WriteLine("Zombie Health is " + BasicZombie.ZombieHealth);
                            //then zombie hits you and round and round 
                        }
                        else
                        {
                            Console.WriteLine("You killed the zombie (again)");
                            Logic.LocationLogic(name, location);
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Please enter a number between 1 and 3");
                }
            }
        }
    }
}
