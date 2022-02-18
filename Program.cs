//////////////////////////////////////////////////////////////////////////////////////////////////////////////
// Shawn Wu, TINFO-200A,Programming II for ITS
// L5life assignment - John Conway's Game of Life program.
// This assignment has the following purpose: It will show the use of 
// two dimensional arrays , as well as demostrate the use of nested for loops
///////////////////////////////////////////////////////////////////////////////////////////
// Change History
// Date         Developer        Description
// 2022-02-05   ShawnW           Some description having to do with the creation and use of this file.
// 2022-02-05   ShawnW           Added game description.
// 2022-02-05   ShawnW           https://en.wikipedia.org/wiki/Conway%27s_Game_of_Life#:~:text=The%20Game%20of%20Life%2C%20also,state%2C%20requiring%20no%20further%20input.


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GLife
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(@"
*****************************************************
        Welcome to the Game Of Life program!
*****************************************************
It is a zero-player game, meaning that its evolution 
is determined by its initial state, requiring no further 
input. One interacts with the Game of Life by creating an 
initial configuration and observing how it evolves. 

Rule - The universe of the Game of Life is an infinite, 
two-dimensional orthogonal grid of square cells, 
each of which is in one of two possible states, live or dead. 
");

            // want to be able to create a game obj and call the ctor
            // to kick off the simulation
            Game game = new Game();
            game.PlayTheGame();
         
        }
    }
}
