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
            Console.WriteLine("");
            Console.WriteLine("Press any key to get dressed and go to the living room.");
            Console.ReadKey();
            Console.Clear();

            Console.WriteLine("You enter the living room and sit on the couch. Your father hands you a map and a rusty dagger.");
            Console.WriteLine("Your father says, " + quote + "it's recommended that you scavenge for items along your journey." + quote);
            Console.WriteLine(quote + "You may find shops while exploring. Visit them and pay coins to obtain healing potions." + quote);
            Console.ReadKey();
            Console.Clear();

            Console.WriteLine("Your father then explains that along your way, you will encounter obstacles in your path.");
            Console.WriteLine(quote + "The pathway to Gambit's Peak is filled with citizens that have been cast out of the village." + quote);
            Console.WriteLine("you learn that many of these citizens are criminals and may cause trouble when trying to pass.");
            Console.ReadKey();
            Console.Clear();

            Console.WriteLine("Press" + " " + quote + "any key" + quote + " " + "to leave the village and begin the jounrey to Gambit's Peak.");
            Console.ReadKey();
            Console.Clear();

            Console.WriteLine("You approach the village gate, a guard opens the gate and lets you out. The guard closes the gate behind you.");
            Console.WriteLine("You look at your map and begin walking on a narrow dirt path. The further you walk away from the village,  ");
            Console.WriteLine("you begin to see a torch from what looks to be a small campsite in the distance ahead.");
            Console.WriteLine("You continue on the path until you reach the small campsite. It looks to be abandoned, however the firepit");
            Console.WriteLine("seems to have been used recently. You start to look around the campsite for supplies to aid you in your journey.");
            Console.ReadKey();
            Console.Clear();
            
            Console.WriteLine("As you are searching the campsite, you begin to hear footsteps approach.");
            Console.WriteLine(quote + "WHO ARE YOU!?" + quote + " You turn around to see a very tall man weilding an axe.");
            Console.WriteLine("You realize quickly that the tall man is hostile and you must fight or run.");
            Console.ReadKey();
            Console.Clear();
        }
    }
}