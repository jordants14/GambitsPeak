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
            Console.ReadLine();
        }
    }
}