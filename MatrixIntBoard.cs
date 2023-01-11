using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace OmegaSudoku
{
    /// <summary>
    /// this class is responsible for creating the matrix[size, size]
    /// </summary>
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
    }
}