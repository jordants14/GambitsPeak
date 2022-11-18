using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace GambitsPeak
{
    public class Player
    {
        Random rand = new Random();

        public string name;
        public int coins = 30000;
        public int weaponValue = 1;
        public int health = 10;
        public int damage = 1;
        public int armorValue = 0;
        public int potion = 5;

        public int modifications = 0;

        // Game Difficulty Multiplyer Purchasable From Shop
        public int GetEnemyHealth()
        {
            int upper = (2 * modifications + 4);
            int lower = (modifications + 2);
            return rand.Next(lower,upper);
        }
        public int GetEnemyPower()
        {
            int upper = (2 * modifications + 2);
            int lower = (modifications + 1);
            return rand.Next(lower, upper);
        }
        public int GetCoins()
        {
            int upper = (15 * modifications + 50);
            int lower = (15 * modifications + 15);
            return rand.Next(lower, upper);
        }
    }
}