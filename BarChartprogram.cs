//////////////////////////////////////////////////////////////////////////////////////////////////////////////
// Shawn Wu, TINFO-200A,Programming II for ITS
// BarChart assignment -  Displaying a Bar Chart program.
// This assignment has the following purpose: It will show the use of 
// for loops , as well as demostrate the use of nested for loops
///////////////////////////////////////////////////////////////////////////////////////////
// Change History
// Date         Developer        Description
// 2022-02-11   ShawnW           Some description having to do with the creation and use of this file.
// 2022-02-11   ShawnW           Creation of for loops.
// 2022-02-11   ShawnW           Creation of 3 different bar charts.
// 2022-02-11   ShawnW           Prompt user for input.


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarChart
{
    internal class Program
    {
        // Main
        static void Main(string[] args)
        {
Console.WriteLine(@"
*****************************************************
       Welcome to the BarChart!
*****************************************************
This app will generate asterisks based on the number inputed. 
");

            Console.WriteLine("Please enter the number you want to be displayed below.");

            // Define each number

            int firstNumber = Convert.ToInt32(Console.ReadLine());  

            // Loop to display *

            for(int i = 0; i < firstNumber; i++)
                Console.Write("*");

            Console.WriteLine();

            // Define each number

            int secondNumber = Convert.ToInt32(Console.ReadLine());
            
            // Loop to display *

            for (int i = 0; i < secondNumber; i++)
                Console.Write("*");

            Console.WriteLine();

            // Define each number

            int thirdNumber = Convert.ToInt32(Console.ReadLine());

            // Loop to display *

            for (int i = 0; i < thirdNumber; i++)
                Console.Write("*");

        }
    }
}
