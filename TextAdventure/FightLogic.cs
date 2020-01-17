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
            Console.Write(EnemyName.GetEnemyName() + " Hit Power is " + EnemyName.EnemyHitPower + " per hit. ");
            Console.WriteLine(EnemyName.GetEnemyName() + " health is " + EnemyName.EnemyHealth);
            Console.WriteLine("The Zombie lunges at you, you dodge out of the way" );
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
                    if(FightAction == "3") //trade blows with enemy
                    {
                        if (EnemyName.GetEnemyName() == "Zombie")
                        {
                            while (EnemyName.EnemyHealth >= 0 && name.PlayerHealth >= 0)
                            {
                                EnemyName.DecreaseEnemyHealth(name.PlayerHitPower, EnemyName);
                                Console.WriteLine(EnemyName.GetEnemyName() + " health is now " + EnemyName.EnemyHealth);
                                if (EnemyName.EnemyHealth <= 0)
                                {
                                    Console.WriteLine("You killed the " + EnemyName.GetEnemyName());
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
                                break;
                            }
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
