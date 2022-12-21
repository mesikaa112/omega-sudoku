using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OmegaSudoku
{
    internal class Board
    {
        const int ROWS = 9;
        const int COLS = 9;
        // the sudoku board
        protected Cell[,] board;

        public Board(string boardString)
        {
            // Initialize the board with a string from the user
            board = new Cell[ROWS, COLS];

            for (int i = 0; i < ROWS; i++)
            {
                for (int j = 0; j < COLS; j++)
                {
                    board[i, j] = new Cell(boardString[i + j] - '0');
                }
            }
        }
    }
}
