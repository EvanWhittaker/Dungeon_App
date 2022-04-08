using DungeonLibrary;

namespace Dungeon
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Title / Introduction

            Console.Title = "DUNGEON OF DOOM";

            Console.WriteLine("Your journey begins...");

            #endregion

            //TODO Create a variable to track the score
            int score = 0;

            //TODO: Create a Player object to track info/stats
            Weapon longSword = new Weapon(1, 8, "Long Sword", 10, false, WeaponType.Sword);

            //Possible Expansion:
            //Character Creation / Name Selection
            //Console.Write("Enter your name: ");
            //string userName = Console.ReadLine();
            //Console.WriteLine("Welcome, {0}!", userName);
            //
            //Console.WriteLine("Choose a race: H) Human\nE) Elf\nO) Orc...");
            //string userRaceChoice = Console.ReadLine().ToUpper();
            //
            //Race playerRace = new Race();
            //
            //switch (userRaceChoice)
            //{
            //    case "H":
            //        playerRace = Race.Human;
            //        break;
            //
            //    default:
            //        break;
            //}
            //Player player = new Player(userName, 70, 5, 40, 40, playerRace, longSword);

            Player player = new Player("Leeroy Jenkins", 70, 5, 40, 40, Race.Human, longSword);

            #region Main Game Loop

            //Bool (counter) for the loop
            bool exit = false;

            //Create the main loop
            do
            {
                //TODO Generate a random room
                Console.WriteLine(GetRoom());

                //TODO Select a Monster (at random) for the player to encounter
                #region Monster Objects

                Rabbit rabbit = new Rabbit("White Rabbit", 25, 25, 50, 20, 2, 8, 
                    "That's no ordinary rabbit! Look at the bones!", true);

                Rabbit babyRabbit = new Rabbit();

                Vampire vampire = new Vampire("Dracula", 25, 30, 70, 8, 1, 8, "The father of all undead.");

                Turtle turtle = new Turtle("Mikey", 17, 25, 50, 10, 1, 4, 
                    "He's no longer a teenager, but he's still a mutant turtle.", 3, 10);

                Dragon dragon = new Dragon("Smaug", 10, 20, 65, 20, 1, 15, "The last great dragon.", true);

                Dragon babyDragon = new Dragon();

                #endregion

                #region Monster Selection

                //Add the monsters to a collection
                Monster[] monsters = { rabbit, turtle, vampire, dragon };

                //Pick one at random to place in the room
                Random rand = new Random();
                int randomNbr = rand.Next(monsters.Length);
                Monster monster = monsters[randomNbr];

                //Output
                Console.WriteLine("\nIn this room you encounter: " + monster.Name);

                #endregion

                #region Gameplay Menu Loop

                //Bool (counter) for the gameplay loop
                bool reload = false;

                //Create the gameplay loop
                do
                {
                    //Create the gameplay menu
                    #region Gameplay Menu

                    //Prompt the user
                    Console.Write("\nPlease choose an action:\n" +
                        "A) Attack\n" +
                        "R) Run away\n" +
                        "P) Player info\n" +
                        "M) Monster info\n" +
                        "X) Exit\n");


                    //Capture the user's menu selection
                    ConsoleKey userChoice = Console.ReadKey(true).Key; //Executes on key press

                    //Clear the console
                    Console.Clear();

                    //Use branching logic to execute code based on user's menu selection
                    switch (userChoice)
                    {

                        case ConsoleKey.A:
                            //TODO Combat
                            Combat.DoBattle(player, monster);

                            //Check if the monster is dead
                            if (monster.Life <= 0)
                            {
                                //Use green text to highlight winning combat
                                Console.ForegroundColor = ConsoleColor.Green;

                                //Output the result
                                Console.WriteLine("\nYou killed {0}!\n", monster.Name);

                                //Reset the color
                                Console.ResetColor();

                                //Update the score
                                score++;

                                //Flip the reload bool to exit the current menu
                                //loop so we can get a new room & monster
                                reload = true;
                            }

                            break;

                        case ConsoleKey.R:
                            //TODO Run away
                            Console.WriteLine($"{monster.Name} attacks you as you flee!");
                            Combat.DoAttack(monster, player);

                            //Formatting
                            Console.WriteLine();

                            //Flip the reload bool to exit the current menu
                            //and get a new room & monster
                            reload = true;

                            break;

                        case ConsoleKey.P:
                            //TODO Player info
                            Console.WriteLine(player);
                            Console.WriteLine("Monsters defeated: " + score);
                            break;

                        case ConsoleKey.M:
                            //TODO Monster info
                            Console.WriteLine(monster);
                            break;

                        //Allows the user to exit if they hit X OR E
                        case ConsoleKey.X:
                        case ConsoleKey.E:
                            Console.WriteLine("No one likes a quitter...");

                            //Flip the bool to break from the loop
                            exit = true;
                            break;

                        default:

                            Console.WriteLine("Thou hast chosen an improper action. Triest thou again.");

                            break;
                    }

                    #endregion

                    //Check the Player's life
                    if (player.Life <= 0)
                    {
                        Console.WriteLine("You have been defeated by {0}!", monster.Name);

                        //Flip the exit bool to end the game
                        exit = true;
                    }


                } while (!exit && !reload); //Condition - while exit AND reload are NOT true, keep looping

                #endregion


            } while (!exit); //Condition for loop - While exit is NOT true, keep looping

            #endregion

            //Output the final score
            Console.WriteLine("You defeated " + score + " monster" + 
                ((score == 1) ? "." : "s."));

        }//end Main()

        #region GetRoom()

        private static string GetRoom()
        {
            //Create a collection of "rooms"
            string[] rooms =
            {
                "The room is dark and musty with the smell of lost souls.",
                "You enter a pretty pink powder room and instantly get glitter on you.",
                "You arrive in a room filled with chairs and a ticket stub machine... the dreaded DMV",
                "You enter a quiet library... silence... nothing but silence....",
                "As you enter the room, you realize you are standing on a platform surrounded by sharks",
                "Oh my.... what is that smell? You appear to be standing in a compost pile",
                "You enter a dark room and all you can hear is hair metal music blaring.... This is going to be bad!",
                "The room looks just like the room you are sitting in right now... or does it?",
            };

            //Create a Random object
            Random rand = new Random();

            //Use the Random object's Next() to generate a number based on the length of the array
            int indexNbr = rand.Next(rooms.Length);

            //Create a variable to store the chosen "room"
            string room = rooms[indexNbr];

            //Return the chosen "room" to be displayed in a Console.WriteLine() in the Main()
            return room;
        }

        #endregion

    }//end class

}//end Namespace
