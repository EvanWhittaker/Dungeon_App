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

            //TODO: Create a Player object to track info/stats

            #region Main Game Loop

            //Bool (counter) for the loop
            bool exit = false;

            //Create the main loop
            do
            {
                Console.WriteLine(GetRoom());

                //TODO Select a Monster (at random) for the player to encounter

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
                            Console.WriteLine("Combat");
                            //TODO Combat
                            break;

                        case ConsoleKey.R:
                            Console.WriteLine("Run away");
                            //TODO Run away
                            break;

                        case ConsoleKey.P:
                            Console.WriteLine("Player info");
                            //TODO Player info
                            break;

                        case ConsoleKey.M:
                            Console.WriteLine("Monster info");
                            //TODO Monster info
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


                } while (!exit && !reload); //Condition - while exit AND reload are NOT true, keep looping

                #endregion


            } while (!exit); //Condition for loop - While exit is NOT true, keep looping

            #endregion

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
