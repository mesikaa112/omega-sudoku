using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ExceptionServices;
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
            // afetr giving every cell his possible values, optimize the values
            BoardOptimization(board);
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


        public static void BoardOptimization(Board board)
        {
            // this method optimize the solving of the sudoku board with the Naked Single Cell and Hidden Singles techniques
            for (int i = 0; i < Constants.ROWS; i++)
            {
                for (int j = 0; j < Constants.COLS; j++)
                {
                    // if the cell in boars[i, j] is empty
                    if (board.GetBoard()[i, j].GetValue() == 0)
                    {
                        int value;
                        // Naked Single Cell

                        // if there is only two possible value for this cell,
                        // erase this value from all the other possible values array list
                        // in this row, cell and sub square of the empty cell and place this value in the borad[i, j] spot
                        if (board.GetBoard()[i, j].GetPossibleValues().Count == 1)
                        {
                            value = (int)board.GetBoard()[i, j].GetPossibleValues()[0];
                            ErasePossibleValues(board, i, j, value);
                            
                            // set the value of board[i, j] to the single possible value
                            board.GetBoard()[i, j].SetValue(value);
                        }

                        // Hidden Single in Cell

                        // if there is a value that found only in one cell of the sub square,
                        // erase this value from all the other possible values array list
                        // in this row, cell and sub square of the empty cell and place this value in the borad[i, j] spot
                        value = CheckForHiddenSingle(board, i, j);
                        if (board.GetBoard()[i, j].GetPossibleValues().Contains(value))
                        {
                            ErasePossibleValues(board, i, j, value);

                            // set the value of board[i, j] to the value that found only in one cell of the sub square possible value
                            board.GetBoard()[i, j].SetValue(value);
                        }

                        //// 

                        //// if there are only two possible value for this cell, and in the same row, col or sub square
                        //// those are the only possible values, erase those values from all the other possible values array list
                        //// in this row, cell and sub square of the empty cell 
                        //if (board.GetBoard()[i, j].GetPossibleValues().Count == 2)
                        //{
                        //    // search for another empty cell that his possible values are equal to this cell possible values
                        //    if (CheckForCell(board, i, j, 2))

                        //}
                    }
                }
            }
        }


        public static void ErasePossibleValues(Board board, int row, int col, int value)
        {
            // thid method gets the board, row, col, and value and erase the value
            // from all the other possible values array list in this row, cell and sub square of the empty cell 

            // loop on the rows and cols
            for (int i = 0; i < Constants.ROWS; i++)
            {
                // if the cell is empty in the same row
                if (board.GetBoard()[i, col].GetValue() == 0 && i != row)
                {
                    board.GetBoard()[i, col].EraseCellInPossibleValues(value);
                }


                // if the cell is empty in the same col
                if (board.GetBoard()[row, i].GetValue() == 0 && i != col)
                {
                    board.GetBoard()[row, i].EraseCellInPossibleValues(value);
                }
            }

            // loop on the sub square
            // squre root of ROWS and COLS
            int sqrtRow = (int)Math.Sqrt(Constants.ROWS);
            int sqrtCol = (int)Math.Sqrt(Constants.COLS);

            int startRow = (row / sqrtRow) * sqrtRow;
            int startCol = (col / sqrtCol) * sqrtCol;
            for (int i = startRow; i < startRow + sqrtRow; i++)
            {
                for (int j = startCol; j < startCol + sqrtCol; j++)
                {
                    // if the cell is empty in the same sub square
                    if (board.GetBoard()[i, j].GetValue() == 0 && i != row && j != col)
                    {
                        board.GetBoard()[i, j].EraseCellInPossibleValues(value);
                    }
                }
            }
        }



        public static int CheckForHiddenSingle(Board board, int row, int col)
        {
            // this method return the value if there is a value that found only in one cell of the sub square, -1 otherwise

            int hiddenSingleValue = -1;

            foreach (int value in board.GetBoard()[row, col].GetPossibleValues())
            {
                hiddenSingleValue = value;

                int sqrtRow = (int)Math.Sqrt(Constants.ROWS);
                int sqrtCol = (int)Math.Sqrt(Constants.COLS);

                int startRow = (row / sqrtRow) * sqrtRow;
                int startCol = (col / sqrtCol) * sqrtCol;

                // loop on the sub square of board[i, j]
                for (int i = startRow; i < startRow + sqrtRow; i++)
                {
                    for (int j = startCol; j < startCol + sqrtCol; j++)
                    {
                        // if the cell is empty
                        if (board.GetBoard()[i, j].GetValue() == 0 && (i != row || j != col))
                        {
                            // loop on the possible values of the empty cell in board[i, j]
                            foreach (int possibleValue in board.GetBoard()[i, j].GetPossibleValues())
                            {
                                // if there is a possible value in other cell that equals to the value of the cell in board[row, col], 
                                // check the next possible value of the cell in board[row, col]
                                if (possibleValue == value)
                                {
                                    hiddenSingleValue = -1;
                                    break;
                                }
                            }
                        }
                        if (hiddenSingleValue == -1)
                            break;
                    }
                    if (hiddenSingleValue == -1)
                        break;
                }
            }
            return hiddenSingleValue;
        }
    }
}
