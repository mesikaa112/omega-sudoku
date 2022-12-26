using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OmegaSudoku
{
    internal class CrookAlgorithm
    {
        public static void SetPossibleValues(Board board)
        {
            // this method loop on every cell in the board and set the possible values of the cell
            for (int i = 0; i < Constants.ROWS; i++)
            {
                for (int j = 0; j < Constants.COLS; j++)
                {
                    // if the cell is empty, set the possible values array
                    if (board.GetBoard()[i, j].GetValue() == 0)
                    {
                        setForSpecificCell(board, i, j);
                    }
                }
            }
        }


        public static void setForSpecificCell(Board board, int row, int col)
        {
            // this method set the possible values of a cell
            
            // loop on the row and col of the cell
            for (int i = 0; i < Constants.ROWS; i++)
            {
                // this value represent the value of the other cells in the same row 
                int value = board.GetBoard()[row, i].GetValue();
                if (value != 0)
                    board.GetBoard()[row, col].EraseCellInPossibleValues(value);

                // this value represent the value of the other cells in the same col
                value = board.GetBoard()[i, col].GetValue();
                if (value != 0)
                    board.GetBoard()[row, col].EraseCellInPossibleValues(value);
            }

            // loop on the sub square values

            // squre root of ROWS and COLS
            int sqrtRow = (int)Math.Sqrt(Constants.ROWS);
            int sqrtCol = (int)Math.Sqrt(Constants.COLS);

            int startRow = (row / sqrtRow) * sqrtRow;
            int startCol = (col / sqrtCol) * sqrtCol;
            for (int i = startRow; i < startRow + sqrtRow; i++)
            {
                for (int j = startCol; j < startCol + sqrtCol; j++)
                {
                    // this value represent the value of the other cells in the same sub square
                    int value = board.GetBoard()[i, j].GetValue();
                    if (value != 0)
                        board.GetBoard()[row, col].EraseCellInPossibleValues(value);
                }
            }
        }
    }
}
