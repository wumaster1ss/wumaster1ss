//////////////////////////////////////////////////////////////////////////////////////////////////////////////
// Shawn Wu, TINFO-200A,Programming II for ITS
// GuessTheNumber assignment - Guess-the-Number Game program.
// This assignment has the following purpose: It will show the use of 
// random generator , as well as demostrate the use of nested for loops
///////////////////////////////////////////////////////////////////////////////////////////
// Change History
// Date         Developer        Description
// 2022-02-05   ShawnW           Some description having to do with the creation and use of this file.
// 2022-02-05   ShawnW           Creation of game objects.
// 2022-02-05   ShawnW           Created nested loops.
// 2022-02-05   ShawnW           Created different responses.


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuessTheNumber
{
    internal class Program
    {

        // Main
        static void Main(string[] args)
        {
Console.WriteLine(@"
*****************************************************
       Welcome to the Guess the Number program!
*****************************************************
This app will generate a number between 1 and 1000
and your job is to guess the correct number. 
");
            //  Random number generator

            Random random = new Random();

            // Between 1 and 1000

            int secretNumber = (random.Next()%1000) + 1;

            int userGuess = 0;

            // While loop to keep guess the number
            
            while(userGuess != secretNumber)
            {
                Console.Write("\nGuess a number between 1 and 1000: ");
                userGuess = int.Parse(Console.ReadLine());

                if (userGuess == secretNumber)
                {
                    Console.WriteLine("Congratulations. You guessed the number!");

                    Console.Write("\nDo you want to play again? (y/n)");
                    string ch = Console.ReadLine().ToLower();
                    
                    // Continue the game
                    
                    if (ch.Equals("y"))

                    {
                        secretNumber = (random.Next() % 1000) + 1;
                        userGuess = 0;
                    }
                }
                // Different responses based on the guess
                 
                else if (userGuess < secretNumber)
                {
                    Console.WriteLine("Too low. Try again.");
                }
                else
                {
                    Console.WriteLine("Too high. Try again");
                }

                
            }

            Console.ReadKey();

        }
    }
}
