using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace GambitsPeak
{
    class Program
    {
        public static Player currentPlayer = new Player();
        static void Main(string[] args)
        {
            Start();
        }


        static void Start()
        {
            Console.WriteLine("Welcome to Gambit's Peak");
            Console.WriteLine("");
            Console.WriteLine("Press any key to continue");
            Console.ReadKey();
            Console.Clear();
            Console.WriteLine("Please enter your name:");
            currentPlayer.name = Console.ReadLine();
            Console.Clear();

            const string quote = "\"";

            if (currentPlayer.name == "")
                Console.WriteLine("You must provide your name before you start your adventure. Please try again.");
            if (currentPlayer.name == "")
                Console.ReadKey();
            if (currentPlayer.name =="")
                Environment.Exit(0);
            else
                Console.WriteLine("Welcome to the adventure " + currentPlayer.name + ".");
            Console.ReadKey();
            Console.Clear();

            Console.WriteLine(currentPlayer.name +"," + " it's the morning after your 18th birthday. Your father wakes you up before sunrise.");
            Console.ReadKey();
            Console.Clear();
            Console.WriteLine(quote + "You're 18 now, it's time you prove your worth as a warrior for the village." + quote);
            Console.WriteLine(quote + "You must travel a dangerous path, up to Gambit's Peak to meet with King Stanislaus." + quote);
            Console.WriteLine(quote + "If you survive the journey, you will be crowned a warrior of the village." + quote);
            Console.ReadKey();
            Console.Clear();

            Console.WriteLine(quote + "Get dressed, then meet me in the living room when you are ready to begin." + quote);
            Console.WriteLine("Your father hands you a cloak and a rusty dagger.");
            Console.WriteLine("Your father says, " + quote + "it's recommended that you scavenge for items along your journey." + quote);
            Console.WriteLine(quote + "You may find potions while exploring. If you drink them, they will restore your wellbeing if you get hurt." + quote);
            Console.ReadKey();
            Console.Clear();

            Console.WriteLine("Your father then explains that along your way, you will encounter obstacles in your path.");
            Console.WriteLine("The pathway to Gambit's Peak is filled with citizens that have been cast out of the village.");
            Console.WriteLine("Many of these citizens are criminals and may cause trouble when trying to pass.");
            Console.ReadKey();
            Console.Clear();
            Console.WriteLine("Press any key to leave the village and begin the jounrey to Gambit's Peak.");
            Console.ReadKey();
            Console.Clear();

            Console.WriteLine("As you leave the village, you stumble upon a small campsite. You go to the campsite to");
            Console.WriteLine("check for extra supplies to aid you in your jourmey, however you are quickly met with a tall");
            Console.WriteLine("man who is not happy that you entered his campsite.");
            Console.ReadKey();
            Console.Clear();
        }
    }
}