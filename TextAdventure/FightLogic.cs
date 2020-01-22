using System;
using System.Collections.Generic;
using System.Text;

namespace TextAdventure
{
    class FightLogic
    {
        public void LetsFight(Player name, Enemy EnemyName, Location location)
        {
            Logic Logic = new Logic();
            Game Game = new Game();
            Actions Actions = new Actions();
            Console.Write(name.GetPlayerName() + "'s Hit Power is " + name.PlayerHitPower + " per hit. ");
            Console.WriteLine(name.GetPlayerName() + "'s health is " + name.PlayerHealth);
            Console.Write(EnemyName.GetEnemyName() + " Hit Power is " + EnemyName.EnemyHitPower + " per hit. ");  //CURRENT PROBLEM - THIS IS WHERE IT'S SAYING THERE ISN'T A ZOMBIE KING BUT IT WOULDN'T HAVE GOT HERE IF THERE WASN'T!
            Console.WriteLine(EnemyName.GetEnemyName() + " health is " + EnemyName.EnemyHealth);
            Console.WriteLine("The Zombie lunges at you, you dodge out of the way" );
            Game.FightPrompt();


            while (true)
            {
                string FightAction = Console.ReadLine();

                if(FightAction == "1") //tried to use switches here but it broke out back to the logic code after every action or not at all.  
                {
                    name.ViewPlayerItems();
                    Game.FightPrompt();
                }
                if(FightAction == "2")
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
                        }
                    }
                    else
                    {
                        Game.FightPrompt();
                    }
                }
                if (FightAction == "3")
                {
                    if (EnemyName.GetEnemyName() == "Zombie")
                    {

                        while (EnemyName.EnemyHealth >= 1 && name.PlayerHealth >= 1)
                        {
                            EnemyName.DecreaseEnemyHealth(name.PlayerHitPower, EnemyName);
                            Console.WriteLine(EnemyName.GetEnemyName() + " health is now " + EnemyName.EnemyHealth);
                            if (EnemyName.EnemyHealth <= 0)
                            {
                                Console.WriteLine("You killed the " + EnemyName.GetEnemyName());
                                //put in a remove the enemey from it's original location here?  or fight the zombie every time you go into the room?
                                location.LocationEnemies.Remove(EnemyName);
                                location.WhereAmI(location);
                                break;
                            }

                            name.DecreasePlayerHealth(EnemyName.EnemyHitPower, name);
                            Console.WriteLine(name.GetPlayerName() + "'s health is now " + name.PlayerHealth);
                            if (name.PlayerHealth <= 0)
                            {
                                Console.WriteLine(name.GetPlayerName() + " got killed in a brutal way.  Thanks for Playing");
                                break;
                            }
                        }
                        break;
                    }
                    if (EnemyName.GetEnemyName() == "The Zombie King")
                    { 
                        while (EnemyName.EnemyHealth >= 0 && name.PlayerHealth >= 0)
                        {
                            EnemyName.DecreaseEnemyHealth(name.PlayerHitPower, EnemyName);
                            Console.WriteLine(EnemyName.GetEnemyName() + " health is now " + EnemyName.EnemyHealth);
                            if (EnemyName.EnemyHealth <= 0)
                            {
                                Console.WriteLine("You killed the " + EnemyName.GetEnemyName() + " and have won the game.  You run up the stairs and into the distance.");
                                break;
                            }

                            name.DecreasePlayerHealth(EnemyName.EnemyHitPower, name);
                            Console.WriteLine(name.GetPlayerName() + "'s health is now " + name.PlayerHealth);
                            if (name.PlayerHealth <= 0)
                            {
                                Console.WriteLine(name.GetPlayerName() + " got killed in a brutal way.  Thanks for Playing");
                                break;
                            }
                        }
                        break;
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
