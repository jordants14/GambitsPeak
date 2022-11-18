using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GambitsPeak
{
    public class Shop
    {
        public static void RunStore(Player p)
        {
            RunStore(p);
        }

        public static void RunStore(Player p)
        {
            int potionPrice;
            int weaponPrice;
            int armorPrice;
            int difficultyPrice;


            while (true)
            {

                potionPrice = 20 + 10 * p.modifications;
                weaponPrice = 100 * p.weaponValue;
                armorPrice = 100 * p.armorValue+ 1;
                difficultyPrice = 200 + 100 * p.modifications;

                Console.Clear();
                Console.WriteLine(" ======================");
                Console.WriteLine("  Welcome to Gambit's  ");
                Console.WriteLine("          Shop         ");
                Console.WriteLine(" ~~~~~~~~~~~~~~~~~~~~~~");
                Console.WriteLine("  Available for sale:  ");
                Console.WriteLine(" ~~~~~~~~~~~~~~~~~~~~~~");
                Console.WriteLine(" (P)otion:  $ " + potionPrice);
                Console.WriteLine(" (W)eapon:   $ " + weaponPrice);
                Console.WriteLine(" (A)rmor:   $ " + armorPrice);
                Console.WriteLine(" (D)ifficulty Mod: $ " + difficultyPrice);
                Console.WriteLine(" ======================");
                Console.WriteLine();

                Console.WriteLine();
                Console.WriteLine(" ======================");
                Console.WriteLine("  " + p.name + "'s     ");
                Console.WriteLine("          Stats        ");
                Console.WriteLine(" ~~~~~~~~~~~~~~~~~~~~~ ");
                Console.WriteLine("  Coins: " +p.coins);
                Console.WriteLine("  " + p.name + "'s Health: " + p.health);
                Console.WriteLine("  Weapon Strength: " + p.weaponValue);
                Console.WriteLine("  Armor Stats: " + p.armourValue);
                Console.WriteLine("  Potions: " + p.potion);
                Console.WriteLine("  Difficulty Mods: " + p.modifications);
                Console.WriteLine(" ======================");
                Console.WriteLine();

                Console.WriteLine();
                Console.WriteLine(" =======================");
                Console.WriteLine("        (E)xit Shop     ");
                Console.WriteLine(" =======================");
                Console.WriteLine();
                Console.WriteLine();

                //Wait for input
                string input = Console.ReadLine().ToLower();
                if (input == "p" || input == "potion")
                {
                    AttemptBuy("potion", potionPrice, p);
                }
                else if (input == "w" || input == "weapon")
                {
                    AttemptBuy("weapon", weaponPrice, p);
                }
                else if (input == "a" || input == "armor")
                {
                    AttemptBuy("armor", armorPrice, p);
                }
                else if (input == "d" || input == "difficulty mod")
                {
                    AttemptBuy("difficulty mod", difficultyPrice, p);
                }
                else if (input == "e" || input == "exit")
                    break;
            }
        }
        static void AttemptBuy(string item, int cost, Player p)
        {
            if(p.coins >= cost)
            {
                if (item == "potion")
                    p.potion++;
                else if(item == "weapon")
                    p.weaponValue++;
                else if(item == "armor")
                    p.armorValue++;
                else if(item == "difficulty mod")
                    p.modifications++;

                p.coins -= cost;

            }
            else
            {
                Console.WriteLine("Not enough gold coins. Collect more and try again.");
                Console.ReadKey();

            }
        }
    }
}