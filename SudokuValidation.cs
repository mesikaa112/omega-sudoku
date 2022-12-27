using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OmegaSudoku
{
    internal class SudokuValidation
    {
        public static bool IsValidPlacement(Board board, int row, int col, int value)
        {
            // this method checks if a value can be placed in the board in the row, col placement

            // Check if the value appears in the same row or column
            for (int i = 0; i < Constants.ROWS; i++)
            {
                if (board.GetBoard()[row, i].GetValue() == value || board.GetBoard()[i, col].GetValue() == value) 
                    return false;
            }

            // check if the value appears in the same sub square
            // squre root of ROWS and COLS
            int sqrtRow = (int)Math.Sqrt(Constants.ROWS);
            int sqrtCol = (int)Math.Sqrt(Constants.COLS);

            int startRow = (row / sqrtRow) * sqrtRow;
            int startCol = (col / sqrtCol) * sqrtCol;
            for (int i = startRow; i < startRow + sqrtRow; i++)
            {
                for (int j = startCol; j < startCol + sqrtCol; j++)
                {
                    if (board.GetBoard()[i, j].GetValue() == value) 
                        return false;
                }
            }
            return true;
        }


        public static Board CheckValidate(string boardString)
        {
            // if the length of the string is not equals to rows*cols
            if (boardString.Length != Constants.ROWS * Constants.COLS)
            {
                throw new InvalidBoardLengthError("there is an Error! you enterd invalid amount of cells");
            }
            // if there are invalid characters in the string, raise Error
            if (!CheckInvalidCharacters(boardString))
                throw new InvalidCharactersInTheStringError("there is an Error! you entered invalid characters");
            // create board object
            Board board = new Board(boardString);
            // check validate of Rows before stating to solve the sudoku
            if (!CheckInRowValidate(board))
                throw new TwoValuesInTheSameRowError("there is an Error! there is two same values in the same row");
            // check validate of Cols before stating to solve the sudoku
            if (!CheckInColValidate(board))
                throw new TwoValuesInTheSameColError("there is an Error! there is two same values in the same col");
            // check validate of Sub Squares before stating to solve the sudoku
            if (!CheckInSubSqueresValidate(board))
                throw new TwoValuesInTheSameSubSquareError("there is an Error! there is two same values in the same sub square");
            return board;
        }



        public static bool CheckInvalidCharacters(string boardString)
        {
            // this method get the string of the baord and check if there are no invakid characters in it.
            // if there are, the method return false, and true otherwise

            // if the string is empty, return false
            if (boardString == "")
                return false;
            // loop on every character in the string and check if he is valid
            foreach(char c in boardString)
            {
                if (!Constants.VALIDCHARACTERS.Contains(c))
                    return false;
            }
            return true;
        }


        public static bool CheckInRowValidate(Board board)
        {
            // this method gets the baord, if there is 2 same numbers in the same row the method returns true, false otherwise
            for (int i = 0; i < Constants.ROWS; i++)
            {
                // copy the elemnts of ROWCOLVALUES to a new array called temp
                int[] temp = new int[Constants.ROWCOLVALUES.Length];
                Constants.ROWCOLVALUES.CopyTo(temp, 0);

                for (int j = 0; j < Constants.COLS; j++)
                {
                    // if temp contains the board[i, j], the cell in temp will be -1
                    if (temp.Contains(board.GetBoard()[i, j].GetValue()))
                    {
                        temp[board.GetBoard()[i, j].GetValue() - 1] = -1;
                    }
                    // if not, it means that there is a value twice or more in the same row or the value is 0
                    else
                    {
                        if (board.GetBoard()[i, j].GetValue() == 0)
                            continue;
                        else
                            return false;
                    }
                }
            }
            return true;
        }


        public static bool CheckInColValidate(Board board)
        {
            // this method gets the baord, if there is 2 same numbers in the same col the method returns true, false otherwise
            for (int j = 0; j < Constants.COLS; j++)
            {
                // copy the elemnts of ROWCOLVALUES to a new array called temp
                int[] temp = new int[Constants.ROWCOLVALUES.Length];
                Constants.ROWCOLVALUES.CopyTo(temp, 0);

                for (int i = 0; i < Constants.ROWS; i++)
                {
                    // if temp contains the board[i, j], the cell in temp will be -1
                    if (temp.Contains(board.GetBoard()[i, j].GetValue()))
                    {
                        temp[board.GetBoard()[i, j].GetValue() - 1] = -1;
                    }
                    // if not, it means that there is a value twice or more in the same col or the value is 0
                    else
                    {
                        if (board.GetBoard()[i, j].GetValue() == 0)
                            continue;
                        else
                            return false;
                    }
                }
            }
            return true;
        }


        public static bool CheckInSubSqueresValidate(Board board)
        {
            // this method gets the baord, if there is 2 same numbers in the same sub square the method returns true, false otherwise

            // squre root of ROWS and COLS
            int sqrtRow = (int)Math.Sqrt(Constants.ROWS);
            int sqrtCol = (int)Math.Sqrt(Constants.COLS);

            for (int i = 0; i < Constants.ROWS; i += sqrtRow)
            {
                for (int j = 0; j < Constants.COLS; j += sqrtCol)
                {
                    // copy the elemnts of box to a new matrix called temp
                    int[] temp = new int[Constants.ROWCOLVALUES.Length];
                    Constants.ROWCOLVALUES.CopyTo(temp, 0);

                    // loop on the sub squares in the board
                    for (int row = i; row < i + sqrtRow; row++)
                    {
                        for (int col = j; col < j + sqrtCol; col++)
                        {
                            // if temp contains the board[i, j], the cell in temp will be -1
                            if (temp.Contains(board.GetBoard()[row, col].GetValue()))
                            {
                                temp[board.GetBoard()[row, col].GetValue() - 1] = -1;
                            }
                            // if not, it means that there is a value twice or more in the same sub square or the value is 0
                            else
                            {
                                if (board.GetBoard()[row, col].GetValue() == 0)
                                    continue;
                                else
                                    return false;
                            }
                        }
                    }

                }
            }
            return true;
        }
    }
}