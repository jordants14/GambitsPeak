using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace GambitsPeak
{
    public class Encounters
    {
        //Makes quoting text easier to remember
        const string quote = "\"";

        //Declaring "random"
        static Random rand = new Random();

        //Encounter Generic


        //Encounters
        public static void FirstEncounter()
        {
            Console.WriteLine("");
            Console.WriteLine("");
            Console.ReadKey();
            Combat(false, "Viscount", 1, 4);
        }
        public static void BasicFight()
        {
            Console.Clear();
            Console.WriteLine("You are now entering combat. Prepare to fight!");
            Console.ReadKey();
            Combat(true, "",0,0);
        }
        public static void SerloEncounter()
        {
            Console.WriteLine("");
            Console.WriteLine("");
            Console.ReadKey();
            Combat(false, "Serlo", 2, 5);
        }


        //Encounter Tools
        //public static void RandomEncounter()
        //{
        //    switch(rand.Next(0,2))
        //    {
        //       case 0:
        //            BasicFight();
        //            break;
        //        case 1:
        //            SerloEncounter();
        //            break;
        //    }
        //}

        public static void Combat(bool random, string name, int power, int health)
        {
            string n = "";
            int p = 0;
            int h = 0;

            //Settings for generating enemy name, power level, and health values.
            if (random)
            {
                n = GetName();
                p = Program.currentPlayer.GetEnemyPower();
                h = Program.currentPlayer.GetEnemyHealth();
            }
            else
            {
                n = name;
                p = power;
                h = health;
            }
            while (h > 0)
            {

                Console.Clear();

                //Displays Enemy Information During Encounter
                Console.WriteLine("Enemy: "+ (n));
                Console.WriteLine("Toughness: " + p);
                Console.WriteLine("Health: " + h);
                Console.WriteLine("");

                //Encounter Controls GUI
                Console.WriteLine(" =======================");
                Console.WriteLine(" ~~~~~~~~~~~~~~~~~~~~~~~");
                Console.WriteLine("   (A) ttack (D) efend  ");
                Console.WriteLine("    (R) un    (H) eal   ");
                Console.WriteLine(" ~~~~~~~~~~~~~~~~~~~~~~~");
                Console.WriteLine(" =======================");
                Console.WriteLine();
                Console.WriteLine("Controls: ");
                Console.WriteLine("Press " + quote + "A" + quote + " for attack,  " + quote + "D" + quote + " for defend, " + quote + "R" + quote + " for run,  " + quote + "H" + quote + " for heal. Then hit the " + quote + "Enter key." + quote);

                //Shows Player's Health and Health Potion Count
                Console.WriteLine();
                Console.WriteLine(Program.currentPlayer.name + " Stats:");
                Console.WriteLine("Potions: " + Program.currentPlayer.potion + "  Health: " + Program.currentPlayer.health);
                Console.WriteLine();
                string input = Console.ReadLine();

                //Check invalid input incase user is confused with the text-based encounter GUI system.
                if (String.IsNullOrEmpty(input))
                {
                    Console.WriteLine("Invalid Input. Please review the controls and try again. Press " + quote + "Enter" + quote + " to continue.");
                    Console.ReadKey();
                }
                else if (input.ToLower() == "a" || input.ToLower() == "attack")
                {
                    //Attack - Heavy attack but no defense against your opponents counter attack
                    Console.WriteLine();
                    Console.WriteLine("You swing your weapon into the enemy and inflict impressive damange, however " +n+ " counter attacks with a swing of their weapon.");
                    int damage = p - Program.currentPlayer.armorValue;

                    // Damage Check
                    if (damage < 0)
                        damage = 0;

                    int attack = rand.Next(0, Program.currentPlayer.weaponValue) + rand.Next(1, 4);
                    Console.WriteLine();
                    Console.WriteLine("You lose " + damage + " health and deal " + attack + " damage");
                    Program.currentPlayer.health -= damage;
                    h -= attack;
                }
                else if (input.ToLower() == "d" || input.ToLower() == "defend")
                {
                    //Defend - Block some enemy damage while countering with a lighter attack
                    Console.WriteLine();
                    Console.WriteLine("As " + n + " prepares to attack, you get ready to defend the attack");
                    int damage = (p / 4) - Program.currentPlayer.armorValue;

                    //Damage Check
                    if (damage < 0)
                        damage = 0;

                    int attack = rand.Next(0, Program.currentPlayer.weaponValue) / 2;
                    Console.WriteLine();
                    Console.WriteLine("You lose " + damage + " health and deal " + attack + " damage");
                    Program.currentPlayer.health -= damage;
                    h -= attack;
                }
                else if (input.ToLower() == "r" || input.ToLower() == "run")
                {
                    //Run - 50/50 chance to run away successfully from the encounter
                    if (rand.Next(0, 2) == 0)
                    {
                        Console.WriteLine();
                        Console.WriteLine("As you swing to stun your enemy, " + n + " hits you with their weapon, forcing you to stay and fight.");
                        int damage = p - Program.currentPlayer.armorValue;

                        //Damage Check
                        if (damage < 0)
                            damage = 0;

                        Console.WriteLine();
                        Console.WriteLine("You lose " + damage + " health and fail to run away.");
                        Console.ReadKey();
                    }
                    else
                    {
                        Console.WriteLine();
                        Console.WriteLine("You manage to stun " + n + " with your weapon and make an escape.");
                        Console.Clear();
                        Console.WriteLine("");
                        Console.WriteLine("You get away from " + n + " and you find the nearest shop. Check it out!");
                        Console.ReadKey();

                        //Load into shop menu
                        Console.Clear();
                        Console.WriteLine("You run away and find the nearest shop. Check it out!");
                        Shop.LoadShop(Program.currentPlayer);
                    }
                }
                else if (input.ToLower() == "h" || input.ToLower() == "heal")
                {
                    //Heal
                    if (Program.currentPlayer.potion == 0)
                    {
                        Console.WriteLine();
                        Console.WriteLine("You quickly look into your backpack and realize you are out of health potions.");
                        int damage = p - Program.currentPlayer.armorValue;

                        //Damage Check
                        if (damage < 0)
                            damage = 0;

                        Console.WriteLine();
                        Console.WriteLine("While you are distracted looking for a health potion, " + n + " swings their weapon and strikes you! You lose " + damage + " health!");
                    }
                    else
                    {
                        Console.WriteLine();
                        Console.WriteLine("You quickly reach into your backpack and find a health potion. You chug it to feel less damage.");
                        int potionValue = 5;
                        Console.WriteLine("You begin to feel the health effects and gain " + potionValue + " health.");
                        Program.currentPlayer.health += potionValue;
                        Console.WriteLine();
                        Console.WriteLine("As you were distracted drinking your health potion, the " + n + " snuck up and attacked you.");
                        int damage = (p/2)-Program.currentPlayer.armorValue;

                        //Damage Check
                        if (damage < 0)
                            damage = 0;

                        Console.WriteLine();
                        Console.WriteLine("You lose " + damage + " health.");
                    }
                    Console.ReadKey();
                }
                if(Program.currentPlayer.health <= 0)
                {
                    //Players health = 0 - Failed Game Code
                    Console.WriteLine();
                    Console.WriteLine("The " + n + " delivers a mighty blow to your skull. You have failed the game, please retry.");
                    Console.ReadKey();
                    System.Environment.Exit(0);
                }
                Console.ReadKey();
            }
            int c = Program.currentPlayer.GetCoins();
            Console.WriteLine();
            Console.WriteLine("You have slain the "+n+". You then proceed to loot their body and find "+c+" gold coins!");
            Program.currentPlayer.coins += c;
            Console.ReadKey();
        }

        public static string GetName()
        {
            switch(rand.Next(0, 20))
            {
                case 0:
                    return "Ninja";
                case 1:
                    return "Skeleton";
                case 2:
                    return "Zombie";
                case 3:
                    return "Witch";
                case 4:
                    return "Drunk Man";
                case 5:
                    return "Warrior";
                case 6:
                    return "Feind";
                case 7:
                    return "Thug";
                case 8:
                    return "Henchman";
                case 9:
                    return "Swordsman";
            }
            return "Thief";
        }
    }
}