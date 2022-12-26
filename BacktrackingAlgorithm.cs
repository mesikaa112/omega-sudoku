using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OmegaSudoku
{
    internal class BacktrackingAlgorithm
    {
        public static bool SolveBacktracking(Board board)
        {
            // this method solve the sudoku board by backtracking algorithm.
            // the backtracking algorithm is a systematic method for finding a solution
            // to a Sudoku puzzle by trying all possible combinations of numbers until a valid solution is found

            // Find the next empty cell
            int row = -1, col = -1;
            for (int i = 0; i < Constants.ROWS; i++)
            {
                for (int j = 0; j < Constants.COLS; j++)
                {
                    // if the board[i, j] is empty cell, break
                    if (board.GetBoard()[i, j].GetValue() == 0)
                    {
                        row = i;
                        col = j;
                        break;
                    }
                }
                // if there was found an empty cell in i row, break
                if (row != -1) 
                    break;
            }

            // If there are no empty cells, the puzzle is solved
            if (row == -1) 
                return true;

            // Try all possibilities values in the empty cell
            foreach (int value in board.GetBoard()[row, col].GetPossibleValues())
            {
                if (value != -1)
                {
                    // Check if the value is valid in the current cell
                    if (SudokuValidation.IsValidPlacement(board, row, col, value))
                    {
                        // If the value is valid, fill in the cell and try to solve the rest of the puzzle
                        board.GetBoard()[row, col].SetValue(value);
                        if (SolveBacktracking(board))
                            return true;

                        // If the puzzle could not be solved, backtrack and try a different number
                        board.GetBoard()[row, col].SetValue(0);
                    }
                }
            }

            // If no valid value was found it means that the board is not aolveable, return false
            return false;
        }
    }
}
