//////////////////////////////////////////////////////////////////////////////////////////////////////////////
// Shawn Wu, TINFO-200A,Programming II for ITS
// AITeacher assignment - Computer-Assisted Instruction program.
// This assignment has the following purpose: It will show the use of 
// random generator , as well as demostrate the use while loops
///////////////////////////////////////////////////////////////////////////////////////////
// Change History
// Date         Developer        Description
// 2022-02-11   ShawnW           Some description having to do with the creation and use of this file.
// 2022-02-11   ShawnW           Creation of random number generator and objects.
// 2022-02-11   ShawnW           Inserted while loop.
// 2022-02-11   ShawnW           Prompt user to begin the game.
// 2022-02-11   ShawnW           Added determining correct and incorrect function.


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AITeacher
{
    internal class Program
    {

        // int method
        static int genrateQuestion()
        {
            // Random number generator

            Random random = new Random();

            // Generate random numbers from 1 to 10

            int first = random.Next(1, 10);
            int second = random.Next(1, 10);

            Console.WriteLine("\nHow much is " + first + " times " + second + " ?");
            return first * second;
        }

        // Main
        static void Main(string[] args)
        {
            Console.WriteLine(@"
*****************************************************
       Welcome to the AI Teacher program!
*****************************************************
This app will generate single digit multiplication numbers
that will help an elementary-school student learn multiplication. 
");
            // Declaring variables

            int count = 0, result, number;

            string input;

            Console.WriteLine("\nLets multiply");

            // While loop to keep repeating

            while (count < 5)
            {
                result = genrateQuestion();
                while (true)
                {
                    Console.Write("\nAnswer: ");
                    input = Console.ReadLine();
                    Int32.TryParse(input, out number);

                    // Determining correct and incorrect answer

                    if (result != number)
                        Console.WriteLine("No. Please try again.");
                    else
                    {
                        Console.WriteLine("Very good");
                        break;
                    }
                }
             
            }
            count++;


        }
    }
}
