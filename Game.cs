//////////////////////////////////////////////////////////////////////////////////////////////////////////////
// Shawn Wu, TINFO-200A,Programming II for ITS
// L5life assignment - John Conway's Game of Life program.
// This assignment has the following purpose: It will show the use of 
// two dimensional arrays , as well as demostrate the use of nested for loops
///////////////////////////////////////////////////////////////////////////////////////////
// Change History
// Date         Developer        Description
// 2022-02-05   ShawnW           Some description having to do with the creation and use of this file.
// 2022-02-05   ShawnW           Creation of game boards and objects.
// 2022-02-05   ShawnW           Inserted start up arrangements of lives.
// 2022-02-05   ShawnW           Some description having to do with the initilization of gameboard.
// 2022-02-05   ShawnW           Prompt user for how many generation of lives.
// 2022-02-05   ShawnW           Created processing gameboard logic with the B3/S23 rules.
// 2022-02-05   ShawnW           Some description with display current generation.


using System;

namespace GLife
{
    internal class Game
    {

        private char[,] gameBoard;
        private char[,] buffBoard;

        // cahr constants for the alive, dead, and empty WS chars 
        public const char LIVE = '@';
        public const char DEAD = '-';
        public const char SPACE = ' ';

        public readonly int ROW_SIZE = 46;
        public readonly int COL_SIZE = 80;


        public Game()
        {
            // initalize major objects here
            gameBoard = new char[ROW_SIZE, COL_SIZE];
            buffBoard = new char[ROW_SIZE, COL_SIZE];

            // initalize the game boards
            InitalizeGameBoards();

            // insert the startup pattern or arrangement of lives
            InsertStartupPatterns(10, 10);
            InsertStartupPatterns(20, 20);
            InsertStartupPatterns(30, 30);


        }

        // Start up patterns
        private void InsertStartupPatterns(int r, int c)

        {
            gameBoard[r, c + 1] = LIVE;
            gameBoard[r, c + 2] = LIVE;
            gameBoard[r, c + 3] = LIVE;
            gameBoard[r, c + 4] = LIVE;
            gameBoard[r, c + 5] = LIVE;
            gameBoard[r, c + 6] = LIVE;
            gameBoard[r, c + 7] = LIVE;
            gameBoard[r, c + 8] = LIVE;

            // leave 1 DEAD
            // insert 5 LIVE
            gameBoard[r, c + 10] = LIVE;
            gameBoard[r, c + 11] = LIVE;
            gameBoard[r, c + 12] = LIVE;
            gameBoard[r, c + 13] = LIVE;
            gameBoard[r, c + 14] = LIVE;
            // leave 3 DEAD
            // insert 3 LIVE
            gameBoard[r, c + 18] = LIVE;
            gameBoard[r, c + 19] = LIVE;
            gameBoard[r, c + 20] = LIVE;
            // after 6 DEAD cell to start
            // insert 7 LIVE cells
            gameBoard[r, c + 27] = LIVE;
            gameBoard[r, c + 28] = LIVE;
            gameBoard[r, c + 29] = LIVE;
            gameBoard[r, c + 30] = LIVE;
            gameBoard[r, c + 31] = LIVE;
            gameBoard[r, c + 32] = LIVE;
            gameBoard[r, c + 33] = LIVE;
            // after 1 DEAD cell to start
            // insert 5 LIVE cells
            gameBoard[r, c + 35] = LIVE;
            gameBoard[r, c + 36] = LIVE;
            gameBoard[r, c + 37] = LIVE;
            gameBoard[r, c + 38] = LIVE;
            gameBoard[r, c + 39] = LIVE;
          
        }

        // Initalize gameboard
        private void InitalizeGameBoards()
        {
            for (int r = 0; r < ROW_SIZE; r++)
            {
                for (int c = 0; c < COL_SIZE; c++)
                {
                    gameBoard[r, c] = DEAD;
                    buffBoard[r, c] = DEAD;
                }
            }
        }

        // Prompt user for how many generations
        internal void PlayTheGame()
        {
            Console.Write("ENTER the number of generations to display: ");
            int numGenerations = int.Parse(Console.ReadLine());

            for (int generation = 1; generation <= numGenerations; generation++)
            {
                // display the game board
                DisplayCurrentGameBoard(generation);


                // process the game board - prepare the next generation
                ProccessGameBoard();

                // swap the two boards
                SwapTheGameBoard();


            }
        }

        // Changing gameboards

        private void SwapTheGameBoard()
        {
            // tmp = A
            // A = B
            // B = tmp
            char[,] tmp = gameBoard;
            gameBoard = buffBoard;
            buffBoard = tmp;
        }

        // Processing logic based on the B3/S23 rules
        private void ProccessGameBoard()
        {
            // iterate through the entire 2 dimensional array
            for (int r = 0; r < ROW_SIZE; r++)
            {
                for (int c = 0; c < COL_SIZE; c++)
                {
                    // consider the current cell (loc r,c) - determine if this cell
                    // will be live or dead in the next generation (on the buffer board)
                    // (calculate which state to store in the results board)
                    buffBoard[r, c] = DeteremineLifeOrDeath(r,c);

                }
            }
        }

        // now we are considering an individual cell in the game board
        // how do we determine life or death (next time)
        private char DeteremineLifeOrDeath(int r, int c)
        {
            // 1 - count the number of neighbor cells that currently hold LIVE orgs
            int count = GetNeighborCount(r, c);

            // 2 - apply the rules of the game (standard B3/S23)
            // 0,1,2,3,4,5,6,7,8

            //Any live cell with fewer than two live neighbours dies, as if by underpopulation.
            if (gameBoard[r, c] == LIVE && count < 2) return DEAD;

            //Any live cell with two or three live neighbours lives on to the next generation.
            if (gameBoard[r, c] == LIVE && (count == 2 || count == 3)) return LIVE;

            //Any live cell with more than three live neighbours dies, as if by overpopulation.
            if (gameBoard[r, c] == LIVE && count > 3) return DEAD;

            //Any dead cell with exactly three live neighbours becomes a live cell, as if by reproduction.
            if (gameBoard[r, c] == DEAD && count == 3) return LIVE;

            //////////////////////////////////////////////////////
            if (count == 2) return gameBoard[r, c];
            else if (count == 3) return LIVE;
            else return DEAD;

        }

        // Game rules
        private int GetNeighborCount(int r, int c)
        {
            int neighborcount = 0;

            if (r == 0 && c == 0)
            {
                // TOP LEFT corner
                if (gameBoard[r, c + 1] == LIVE) neighborcount++;
                if (gameBoard[r + 1, c] == LIVE) neighborcount++;
                if (gameBoard[r + 1, c + 1] == LIVE) neighborcount++;


            }
            else if (r == 0 && c == COL_SIZE - 1)
            {
                // TOP RIGHT corner
                if (gameBoard[r, c - 1] == LIVE) neighborcount++;
                if (gameBoard[r + 1, c - 1] == LIVE) neighborcount++;
                if (gameBoard[r + 1, c] == LIVE) neighborcount++;
            }
            else if (r == ROW_SIZE - 1 && c == COL_SIZE - 1)
            {
                // BOTTOM RIGHT corner
                if (gameBoard[r - 1, c - 1] == LIVE) neighborcount++;
                if (gameBoard[r - 1, c] == LIVE) neighborcount++;
                if (gameBoard[r, c - 1] == LIVE) neighborcount++;
            }
            else if (r == ROW_SIZE - 1 && c == 0)
            {
                // BOTTOM LEFT corner
                if (gameBoard[r - 1, c] == LIVE) neighborcount++;
                if (gameBoard[r - 1, c + 1] == LIVE) neighborcount++;
                if (gameBoard[r, c + 1] == LIVE) neighborcount++;
            }
            else if (r == 0)
            {
                // TOP EDGE (not corner)
                if (gameBoard[r, c - 1] == LIVE) neighborcount++;
                if (gameBoard[r, c + 1] == LIVE) neighborcount++;
                if (gameBoard[r + 1, c - 1] == LIVE) neighborcount++;
                if (gameBoard[r + 1, c] == LIVE) neighborcount++;
                if (gameBoard[r + 1, c + 1] == LIVE) neighborcount++;

            }
            else if (c == COL_SIZE - 1)
            {
                // RIGHT EDGE (not corner)
                if (gameBoard[r - 1, c - 1] == LIVE) neighborcount++;
                if (gameBoard[r - 1, c] == LIVE) neighborcount++;
                if (gameBoard[r, c - 1] == LIVE) neighborcount++;
                if (gameBoard[r + 1, c - 1] == LIVE) neighborcount++;
                if (gameBoard[r + 1, c] == LIVE) neighborcount++;

            }
            else if (r == ROW_SIZE - 1)
            {
                // BOTTOM EDGE (not corner)
                if (gameBoard[r - 1, c - 1] == LIVE) neighborcount++;
                if (gameBoard[r - 1, c] == LIVE) neighborcount++;
                if (gameBoard[r - 1, c + 1] == LIVE) neighborcount++;
                if (gameBoard[r, c - 1] == LIVE) neighborcount++;
                if (gameBoard[r, c + 1] == LIVE) neighborcount++;
            }
            else if (c == 0)
            {
                // LEFT EDGE (not corner)
                if (gameBoard[r - 1, c] == LIVE) neighborcount++;
                if (gameBoard[r - 1, c + 1] == LIVE) neighborcount++;
                if (gameBoard[r, c + 1] == LIVE) neighborcount++;
                if (gameBoard[r + 1, c] == LIVE) neighborcount++;
                if (gameBoard[r + 1, c + 1] == LIVE) neighborcount++;

            }
            else
            {
                // nominal case
                if (gameBoard[r - 1, c - 1] == LIVE) neighborcount++;
                if (gameBoard[r - 1, c] == LIVE) neighborcount++;
                if (gameBoard[r - 1, c + 1] == LIVE) neighborcount++;
                if (gameBoard[r, c - 1] == LIVE) neighborcount++;
                // r,c
                if (gameBoard[r, c + 1] == LIVE) neighborcount++;
                if (gameBoard[r + 1, c - 1] == LIVE) neighborcount++;
                if (gameBoard[r + 1, c] == LIVE) neighborcount++;
                if (gameBoard[r + 1, c + 1] == LIVE) neighborcount++;



            }
            return neighborcount;
        }

        // Display current generation

        private void DisplayCurrentGameBoard(int gen)
        {
            Console.WriteLine($"Displaying generation #{gen}");
            for (int r = 0; r < ROW_SIZE; r++)
            {
                for (int c = 0; c < COL_SIZE; c++)
                {
                    Console.Write($"{SPACE}{gameBoard[r, c]}");
                }
                Console.WriteLine();
            }
        
        }
    }
}