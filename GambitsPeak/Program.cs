using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.Intrinsics.X86;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;


namespace GambitsPeak
{
    [Serializable]
    public class Program
    {
        public static Player currentPlayer = new Player();
        public static bool primaryLoop = true;
        public static Random rnd = new Random();
        static void Main(string[] args)
        {
            if(!Directory.Exists("saves"))
            {
                Directory.CreateDirectory("saves");
            }
            currentPlayer = Load(out bool newP);
            if (newP)
                Encounters.FirstEncounter();
            while (primaryLoop)
            {
                FirstRandomEncounter(); // Random Encounter Dialogue Storyline
                Encounters.BasicFight(); // Assigning Random stats/Enemy
                FirstSerloEncounter(); // Serlo Fight Storyline
                Encounters.SerloEncounter(); // Serlo Fight
                Encounters.BasicFight(); // Assigning Random stats/Enemy
            }
        }


        static Player NewStart(int i)
        {
            Console.Clear();
            Player p = new Player();
            Console.WriteLine("Welcome to Gambit's Peak. This is a text based adventure game created by Jordan Smith.");
            Console.WriteLine("");
            Console.WriteLine("This project is a work in progress. I am focusing on the coding more than the story for now.");
            Console.WriteLine("");
            Console.WriteLine("Press any key to continue.");
            Console.ReadKey();
            Console.Clear();

            Console.WriteLine("Please enter your character's name:");
            p.name = Console.ReadLine();
            p.saveId = i; // sets unique player ID.
            Console.Clear();

            const string quote = "\"";

            if (p.name == "")
                Console.WriteLine("You must provide your character name before you start your adventure. Please try again.");
            if (p.name == "")
                Console.ReadKey();
            if (p.name == "")
                Environment.Exit(0);
            else
                Console.WriteLine("Welcome to the adventure " + p.name + ".");
            Console.ReadKey();
            Console.Clear();

            Console.WriteLine("You wake up feeling groggy and confused. How did you end up in this cold, dark, cave?");
            Console.WriteLine("You are struggling to remember how you got here. Your memory feels like its out of reach.");
            Console.WriteLine("Your body is very cold and your limbs feel numb. You have to focus on how you got here. What happened?");
            Console.ReadKey();
            Console.Clear();

            Console.WriteLine("A few seconds pass and the brain fog feels like its lifting away. Almost as if your body was releasing");
            Console.WriteLine("all of your stress at once. You begin to notice your surroundings and you sit up and lean up against the cave wall.");
            Console.WriteLine("You try to remeber any details from your past, however nothing is very clear as of yet.");
            Console.ReadKey();
            Console.Clear();

            Console.WriteLine("Abruptly, you get startled by the sound of metal grinding against stone. You look over and see");
            Console.WriteLine("an old man with long gray hair that blends into his beard and ends at his ankles.");
            Console.WriteLine("The man seems to be sharpening an iron dagger. The man looks over and sees that you are awake.");
            Console.ReadKey();
            Console.Clear();

            Console.WriteLine("The old man walks towards you but leaves the dagger at the sharpening station. He approaches you and reaches his");
            Console.WriteLine("hand out and asks you to see if you can stand up with his help. You reach out and grab the man's arm and stand up.");
            Console.ReadKey();
            Console.Clear();

            Console.WriteLine(quote + "I didn't think you was ever going to wake up! My name is Urazin. I am the wizard of Scovel.");
            Console.WriteLine("I think I have seen you around the village. Your name is, " + p.name + ".");
            Console.ReadKey();
            Console.Clear();

            Console.WriteLine("I found you laying against a tree in the woods, it seems like you are pretty badly beaten, may I ask what happened?" + quote);
            Console.ReadKey();
            Console.WriteLine("");
            Console.WriteLine("You think to yourself " + quote + "this man is asking a lot of questions.. And he's seen me around? But where?" + quote);
            Console.ReadKey();
            Console.WriteLine("");
            Console.WriteLine("The old man brought me under shelter when I could have been killed off by the wilderness.");
            Console.WriteLine("");
            Console.ReadKey();
            Console.WriteLine("He seems to be genuine and he's trying to help you. You begin to trust him, but you have some questions.");
            Console.ReadKey();
            Console.WriteLine("");
            Console.WriteLine(quote + "How do you know me? How do I know I can trust you? And lastly, why am I here now?" + quote);
            Console.ReadKey();
            Console.Clear();

            Console.WriteLine(quote + "Everyone in the village knows you " + p.name + ". There is a rumor that you are going to kill King Azori?");
            Console.WriteLine("");
            Console.WriteLine("Is that true? It seems a bit crazy to me.... However, I can see why someone would want to assassinate the king.");
            Console.WriteLine("");
            Console.WriteLine("You got my help if you need it. The king wants all wizards killed." + quote);
            Console.ReadKey();
            Console.Clear();

            Console.WriteLine("You think to yourself, " + quote + "If this old man knows my plans, I wonder who else knows?" + quote);
            Console.WriteLine("");
            Console.WriteLine(quote + "You're right, sorry to be so harsh on you. I trust you. And yes, I, have been sent to Enders Peak by the enders to");
            Console.WriteLine("put a stop to the corrupted King, Azori. He has threatened and starved this village for too long." + quote);
            Console.ReadKey();
            Console.Clear();

            Console.WriteLine(quote + "Let's eat. Afterwards you can put on this leather gear. It's not great but its better than no armour.");
            Console.WriteLine("I have also prepared a few health potions, an iron dagger. You can take them for your journey.");
            Console.WriteLine("");
            Console.ReadKey();

            Console.WriteLine("You sit down and eat with Urazin. Afterwards you put on the armour and sheathe your iron dagger.");
            Console.WriteLine("");
            Console.WriteLine("You gather " + Program.currentPlayer.potion + " health potions and stuff them into your backpack.");
            Console.WriteLine("");
            Console.WriteLine("It's time to leave. You begin to leave Urazin's cave. However, Urazin stops you at the door.");
            Console.WriteLine("");
            Console.WriteLine(quote + "Before you leave, I must warn you. The path to Gambit's Peak is dangerous. You will face deadly foes..");
            Console.WriteLine("");
            Console.WriteLine("I am sure you already knew that but I want to make sure you are truly prepared for the journey ahead.");
            Console.WriteLine("Loot enemies you defeat and use their gold coins to buy items from shops setup ");
            Console.WriteLine("along Gambit's path. That's the best way to survive..." + quote);
            Console.ReadKey();
            Console.Clear();

            Console.WriteLine("You thank Urazin, then leave the cave and head back onto Gambit's path.");
            Console.ReadKey();
            Console.Clear();

            Console.WriteLine("You begin to think about your mission ahead. It sparks a rush of adrenaline.");
            Console.WriteLine("Your village chose you to assassinate King Azori because you are the strongest warrior of the village.");
            Console.WriteLine("");
            Console.WriteLine("You come from a line of warriors and you've dedicated your life to training. Nothing you face will");
            Console.WriteLine("stand in your way. It's time to prove yourself to the village.");
            Console.ReadKey();
            Console.Clear();

            //First Encounter
            Console.WriteLine("You begin walking on a snowy path. The snow is so thick that you cannot see more than three feet ahead.");
            Console.WriteLine("As you are walking, you begin to see a light shine through the snowy distance. ");
            Console.WriteLine("You leave the path and head towards the light.");
            Console.ReadKey();
            Console.Clear();

            Console.WriteLine("You stumble onto a small camp in the woods. The light you seen earlier is coming from a firepit.");
            Console.WriteLine("Someone has been here recently...");
            Console.ReadKey();
            Console.Clear();

            Console.WriteLine("You begin to search the campsite in hopes to find gold coins or health potions.");
            Console.WriteLine();
            Console.WriteLine("While searching the camp, you suddenly hear the snow crunch under a someone's shoe.");
            Console.ReadKey();
            Console.Clear();

            Console.WriteLine("You turn around and see a man holding an axe and staring your down...");
            Console.WriteLine("");
            Console.WriteLine("The guy begins to sprint towards you screaming and slinging the axe around.");
            Console.WriteLine("");
            Console.WriteLine(quote + "I'M Viscount, YOU PICKED THE WRONG CAMP TO STEAL FROM. I WILL HAVE YOUR HEAD!" + quote);
            return p;
        }

        public static void Quit()
        {
            Save();
            Environment.Exit(0);
        }

        public static void Save()
        {
            BinaryFormatter binForm = new BinaryFormatter();
            string path = "saves/" +currentPlayer.saveId.ToString() + ".level";
            FileStream file = File.Open(path, FileMode.OpenOrCreate);
            binForm.Serialize(file, currentPlayer);
            file.Close();
        }

        public static Player Load(out bool newP)
        {
            newP = false;
            Console.Clear();
            string[] paths = Directory.GetFiles("saves");
            List<Player> players = new List<Player>();
            int idCount = 0;

            BinaryFormatter binForm = new BinaryFormatter();
            foreach (string p in paths)
            {
                FileStream file = File.Open(p, FileMode.Open);
                Player player = (Player)binForm.Deserialize(file);
                file.Close();
                players.Add(player);
            }

            idCount = players.Count;

            while (true)
            {
                Console.Clear();
                Console.WriteLine("Returning Player? Input your player name or player ID. (id:# or playername).");
                Console.WriteLine();

                foreach (Player p in players)
                {
                    Console.WriteLine(p.saveId + ": " + p.name + ", Coins: " + p.coins + ", Health: " + p.health);
                }
                Console.WriteLine("New players can type 'create' to start a new save file.");
                string[] data = Console.ReadLine().Split(':');

                try
                {
                    if (data[0] == "id")
                    {
                        if(int.TryParse(data[1], out int id))
                        {
                            foreach (Player player in players)
                            {
                                if(player.saveId == id)
                                {
                                    return player;
                                }
                            }
                            Console.WriteLine("Invalid player ID, try again.");
                            Console.ReadKey();
                        }
                        else
                        {
                            Console.WriteLine("Your id needs to be a number. Press any key to continue.");
                            Console.ReadKey();
                        }
                    }
                    else if (data[0] == "create")
                    {
                        Player newPlayer = NewStart(idCount);
                        newP = true;
                        return newPlayer;
                    }
                    else
                    {
                        foreach(Player player in players)
                        {
                            if(player.name == data[0])
                            {
                                return player;
                            }
                        }
                        Console.WriteLine("Playername is invalid. Try again. Press any key to continue.");
                        Console.ReadKey();
                    }
                }
                catch(IndexOutOfRangeException)
                {
                    Console.WriteLine("Your id needs to be a number. Press any key to continue.");
                    Console.ReadKey();
                }
            }

        }
        static void FirstRandomEncounter()
        {
            const string quote = "\"";
            Console.Clear();
            Console.WriteLine("After your interaction with Viscount, you leave the camp");
            Console.WriteLine("and return to Gambit's path. You eventually reach a part of");
            Console.WriteLine("the path where a bridge has collapsed and a river is between you");
            Console.WriteLine("and the other side. You decide to walk down towards the river to");
            Console.WriteLine("check for a shallow spot to step across. You head down a small hill");
            Console.WriteLine("and find a part of the river that is shallow enough to cross.");
            Console.ReadKey();
            Console.Clear();

            Console.WriteLine("As you get to the bottom of the hill near the river, you see something run towards you from the corner of your eye!");
            Console.ReadKey();
            Console.Clear();
        }
        static void FirstSerloEncounter()
        {
            const string quote = "\"";
            Console.Clear();
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine(quote + "Ah, it's funny that we meet. I've been looking for you... My name is Serlo. King Azori knows you plan and I am here to stop you.");
        }
    }
}
