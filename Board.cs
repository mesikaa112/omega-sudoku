using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace OmegaSudoku
{
    internal class Board
    {
        // the sudoku board
        private Cell[,] board;

        public Board(string boardString)
        {
            // Initialize the board with a string from the user
            board = new Cell[Constants.ROWS, Constants.COLS];

            for (int i = 0; i < Constants.ROWS; i++)
            {
                for (int j = 0; j < Constants.COLS; j++)
                {
                    // casting from string to int
                    board[i, j] = new Cell(boardString[(i * Constants.ROWS) + j] - '0');
                }
            }
        }

        public Cell[,] GetBoard()
        {
            return board;
        }


        public void PrintBoard()
        {
            for (int i = 0; i < Constants.ROWS; i++)
            {
                for (int j = 0; j < Constants.COLS; j++)
                {
                    Console.Write(board[i, j].GetValue() + " "); 
                }
                Console.WriteLine("");
            }
        }
    }
}
