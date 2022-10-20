using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GambitsPeak
{
    class Encounters
    {
        //Encounter Generic


        //Encounters
        public static void FirstEncounter()
        {
            Console.WriteLine("The tall man shouts I WILL HAVE YOUR HEAD and he charges towards you.");
            Console.WriteLine("He quickly stops three feet away from you...");
            Console.ReadKey();


        }

        //Encounter Tools
        public static void Combat(bool random, string name, int power, int health)
        {
            string n = "";
            int p = 0;
            int h = 0;
            if (random)
            {

            }
            else
            {
                n = name;
                p = power;
                h = health;
            }
            while (h > 0)
            {
                Console.WriteLine("====================");
                Console.WriteLine("| (A)ttack (D)efend |");
                Console.WriteLine("|   (R)un   (H)eal  |");
                Console.WriteLine("====================");
                Console.WriteLine(" Potions: " + Program.currentPlayer.potion + "  Health: " + Program.currentPlayer.health);
                string input = Console.ReadLine();
                if (input.ToLower() == "a" ||input.ToLower()=="attack")
                {
                    //Attack
                }
            }
        }
    }
}
