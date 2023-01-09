using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace OmegaSudoku
{
    internal class MatrixIntBoard
    {
        // the sudoku board
        private int[,] _board;

        public MatrixIntBoard(string boardString)
        {
            // Initialize the board with a string from the user
            _board = new int[Constants.SIZE, Constants.SIZE];

            for (int i = 0; i < Constants.SIZE; i++)
            {
                for (int j = 0; j < Constants.SIZE; j++)
                {
                    // casting from string to int
                    _board[i, j] = boardString[(i * Constants.SIZE) + j] - '0';
                }
            }
        }

        /// <summary>
        /// this method returns the private feature of the class '_board'
        /// </summary>
        public int[,] GetBoard()
        {
            return _board;
        }

        /// <summary>
        /// this method prints the board before solving
        /// </summary>
        public void PrintBoard()
        {
            for (int i = 0; i < Constants.SIZE; i++)
            {
                for (int j = 0; j < Constants.SIZE; j++)
                {
                    string printValue = string.Format("{0, 3}", (char)(_board[i, j] + '0'));
                    Console.Write(printValue);
                }
                Console.WriteLine("");
            }
        }

        /// <summary>
        /// this method prints the board after solving
        /// </summary>
        /// <param name="board"> the solved board in int[,] </param>
        public static void PrintSolution(int[,] board)
        {
            for (int i = 0; i < Constants.SIZE; i++)
            {
                for (int j = 0; j < Constants.SIZE; j++)
                {
                    string printValue = string.Format("{0, 3}", (char)(board[i, j] + '0'));
                    Console.Write(printValue);
                }
                Console.WriteLine("");
            }
        }
    }
}