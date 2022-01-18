using System;


namespace CamelProgram
{
    class Program
    {

        // Variables
        static char userCommand;
        static bool done = false;
        static int milesTraveled = 0;
        static int thirst = 0;
        static int camelTiredness = 0;
        static int nativesTraveled = -10;
        static int drinksInCanteen = 3;
        static int oasis = -1;

        //Print the user options
        private static void PrintOptions()
        {
            // Print commands
            Console.WriteLine();
            Console.WriteLine("A. Drink from your canteen.");
            Console.WriteLine("B. Ahead moderate speed.");
            Console.WriteLine("C. Ahead full speed.");
            Console.WriteLine("D. Stop and rest.");
            Console.WriteLine("E. Status check.");
            Console.WriteLine("Q. Quit.");
        }

        //Funtion For Option A, Drink From Canteen
        private static void DrinkFromCanteen()
        {
            if (drinksInCanteen > 0)
            {
                drinksInCanteen -= 1;
                thirst = 0;
                Console.WriteLine("You take a drink from your canteen");
                Console.WriteLine("You have " + drinksInCanteen + " drinks left.");
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("Your canteen is empty. You have no drinks left.");
            }
        }

        //Function For Option B, User Moves Ahead At Moderate Speed
        private static void MoveAheadModerateSpeed(Random random)
        {
            int miles = random.Next(5, 12);
            milesTraveled += miles;
            thirst += 1;
            camelTiredness += 1;
            nativesTraveled += random.Next(7, 16);

            if (oasis == 10)
            {
                Console.WriteLine("You found an oasis!");
                drinksInCanteen = 3;
                thirst = 0;
                camelTiredness = 0;
            }
            else
            {
                Console.WriteLine("You traveled " + miles + " miles.");
                Console.WriteLine();
            }
        }

        //Function for Option C, User Moves Ahead At Full Speed
        private static void MoveAheadFullSpeed(Random random)
        {
            int miles = random.Next(10, 19);
            milesTraveled += miles;
            thirst += 1;
            camelTiredness += random.Next(1, 4);
            nativesTraveled += random.Next(7, 16);


            if (oasis == 10)
            {
                Console.WriteLine("You found an oasis!");
                drinksInCanteen = 3;
                thirst = 0;
                camelTiredness = 0;
            }
            else
            {
                Console.WriteLine("You traveled: " + miles + " miles");
                Console.WriteLine();
            }
        }

        //Function For Option D, User Stops And Rests
        private static void StopAndRest(Random random)
        {
            Console.WriteLine("You stop for the night.");
            Console.WriteLine("The camel is happy.");
            camelTiredness = 0;
            nativesTraveled += random.Next(7, 16);
            Console.WriteLine("The natives are " + (milesTraveled - nativesTraveled) + " miles behind you.");
            Console.WriteLine();
        }

        //Function For Option E, Check User Status
        private static void CheckStatus()
        {
            Console.WriteLine("Miles traveled: " + milesTraveled);
            Console.WriteLine("Drinks in canteen: " + drinksInCanteen);
            Console.WriteLine("The natives are " + (milesTraveled - nativesTraveled) + " miles behind you.");
            Console.WriteLine();
        }




        static void Main(string[] args)
        {

            // Introductory message
            Console.WriteLine("Welcome to Camel!");
            Random random = new Random();

            // Main game loop
            while (!done)
            {

                // Get user command
                PrintOptions();
                Console.Write("What is your command? ");
                userCommand = Console.ReadKey().KeyChar;
                Console.WriteLine();

                // Process user command
                if (char.ToUpper(userCommand) == 'Q')
                {
                    Console.WriteLine("You quit the game.");
                    done = true;
                }

                // Status Check
                else if (char.ToUpper(userCommand) == 'E')
                {
                    CheckStatus();
                }

                // Stop for the night
                else if (char.ToUpper(userCommand) == 'D')
                {
                    StopAndRest(random);
                }

                //Full Speed Ahead
                else if (char.ToUpper(userCommand) == 'C')
                {
                    MoveAheadFullSpeed(random);
                }

                //Moderate speed ahead
                else if (char.ToUpper(userCommand) == 'B')
                {
                    MoveAheadModerateSpeed(random);
                }

                //Drink From Your Canteen
                else if (char.ToUpper(userCommand) == 'A')
                {
                    DrinkFromCanteen();
                }

                //Unknown Command
                else
                {
                    Console.WriteLine("Unknown command.");
                }

                // Win
                if (milesTraveled >= 200)
                {
                    Console.WriteLine("You have traveled the entire desert.");
                    Console.WriteLine("You won!");
                    Console.WriteLine();
                    done = true;
                }

                // Thirst
                if (!done && thirst > 6)
                {
                    Console.WriteLine("You died of thirst!");
                    Console.WriteLine("Game over.");
                    Console.WriteLine();
                    done = true;
                }

                else if (!done && thirst > 4)
                {
                    Console.WriteLine("You are thirsty.");
                    Console.WriteLine();
                }

                // Camel tiredness
                if (!done && camelTiredness > 8)
                {
                    Console.WriteLine("Your camel died of exhaustion.");
                    Console.WriteLine("The natives catch up to you and kill you.");
                    Console.WriteLine("Game over.");
                    Console.WriteLine();
                    done = true;
                }

                else if (!done && camelTiredness > 5)
                {
                    Console.WriteLine("Your camel is getting tired.");
                    Console.WriteLine();
                }

                //Natives proximity to player
                if (milesTraveled - nativesTraveled <= 0)
                {
                    Console.WriteLine("The natives have caught up to you!");
                    Console.WriteLine("They kill you and take back their camel.");
                    Console.WriteLine("Game over.");
                    Console.WriteLine();
                    done = true;
                }

                else if (!done && milesTraveled - nativesTraveled < 15)
                {
                    Console.WriteLine("The natives are getting close!");
                    Console.WriteLine();
                }
            }
        }
    }
}