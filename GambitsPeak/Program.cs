using System;
using System.Collections.Generic;
using System.Linq;
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
            Console.WriteLine("Please enter your name:");
            currentPlayer.name = Console.ReadLine();
            Console.Clear();

            if (currentPlayer.name == "")
                Console.WriteLine("You must provide your name before you start your adventure. Please try again.");
            if (currentPlayer.name == "")
                Console.ReadKey();
            if (currentPlayer.name =="")
                Environment.Exit(0);
            else
                Console.WriteLine("Welcome to the adventure " + currentPlayer.name);
            Console.ReadKey();
            Console.Clear();

            Console.WriteLine(currentPlayer.name + " It's the morning after your 18th birthday. Your father wakes you up before sunrise.");
            Console.WriteLine("He tells you that when you turn 18, it's a village tradition to test your worth.");
            Console.WriteLine("You must travel a dangerous path, up to Gambit's Peak to meet with King Stanislaus.");
            Console.WriteLine("If you make the journey, you will be rewarded with a feast and riches.");
            Console.ReadKey();
            Console.Clear();
        }
    }
}