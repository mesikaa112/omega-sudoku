using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OmegaSudoku.Exceptions;

namespace OmegaSudoku
{
    /// <summary>
    /// this class is responsible for the validation of the sudoku board before starting to solve the board
    /// </summary>
    internal class SudokuValidation
    {
        /// <summary>
        /// this method checks the validate of the board before starting solve it
        /// </summary>
        /// <param name="boardString"> the board in string type </param>
        /// <returns> if the board is validate, return the board in int[,] type </returns>
        /// <exception cref="InvalidBoardLengthError"> there are invalid amount of characters in the board string </exception>
        /// <exception cref="InvalidCharactersInTheStringError"> there are invalid characters that can't be in a cell </exception>
        /// <exception cref="TwoValuesInTheSameRowError"> there are two or more same values in the same row </exception>
        /// <exception cref="TwoValuesInTheSameColError"> there are two or more same values in the same column </exception>
        /// <exception cref="TwoValuesInTheSameSubSquareError"> there are two or more same values in the same sub square </exception>
        public static MatrixIntBoard CheckValidate(string? boardString)
        {
            // if the length have an integer sqrt, the length of the string is valid
            // and if the length of the string is valid, set the amount of rols and cols to this sqrt
            double sqrtSize = 0;
            // check if boardString is not null before 
            if (boardString != null)
                sqrtSize = Math.Sqrt(boardString.Length);
            else
                throw new InvalidBoardLengthError("there is an Error! you entered null instead the board");

            if (sqrtSize != (int)sqrtSize)
            {
                throw new InvalidBoardLengthError("there is an Error! you enterd invalid amount of cells");
            }
            else
            {
                Constants.SIZE = (int)sqrtSize;
            }
            // if there are invalid characters in the string, raise Error
            if (!CheckInvalidCharacters(boardString))
                throw new InvalidCharactersInTheStringError("there is an Error! you entered invalid characters");
            // create board object
            MatrixIntBoard board = new MatrixIntBoard(boardString);
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

        /// <summary>
        /// this method gets the board in string type and check if there are no invalid characters in it. 
        /// if there are, the method return false, and true otherwise
        /// </summary>
        /// <param name="boardString"> the board in string type </param>
        /// <returns> false if there are invalid characters in the board, and true otherwise </returns>
        public static bool CheckInvalidCharacters(string boardString)
        {
            Constants.VALID_CHARACTERS = Constants.AddValidCharacters();
            // loop on every character in the string and check if he is valid
            foreach (char c in boardString)
            {
                if (!Constants.VALID_CHARACTERS.Contains(c))
                    return false;
            }
            return true;
        }

        /// <summary>
        /// this method gets the baord, if there are 2 same numbers in the same row the method returns true, false otherwise
        /// </summary>
        /// <param name="board"> the board in int[,] type </param>
        /// <returns> true if there are 2 same values in the same row, and false otherwise </returns>
        public static bool CheckInRowValidate(MatrixIntBoard board)
        {
            // this method gets the baord, if there is 2 same numbers in the same row the method returns true, false otherwise
            for (int i = 0; i < Constants.SIZE; i++)
            {
                Constants.VALUES_OF_CELLS = Constants.AddValuesOfCells();

                // copy the elemnts of VALUESOFCELLS to a new array called temp
                char[] temp = new char[Constants.VALUES_OF_CELLS.Length];
                Constants.VALUES_OF_CELLS.CopyTo(temp, 0);

                for (int j = 0; j < Constants.SIZE; j++)
                {
                    // if temp contains the board[i, j], the cell in temp will be space
                    char value = (char)board.GetBoard()[i, j];
                    value += '0';
                    if (temp.Contains(value))
                    {
                        temp[board.GetBoard()[i, j] - 1] = ' ';
                    }
                    // if not, it means that there is a value twice or more in the same row or the value is 0
                    else
                    {
                        if (board.GetBoard()[i, j] == 0)
                            continue;
                        else
                            return false;
                    }
                }
            }
            return true;
        }

        /// <summary>
        /// this method gets the baord, if there are 2 same numbers in the same column the method returns true, false otherwise
        /// </summary>
        /// <param name="board"> the board in int[,] type </param>
        /// <returns> true if there are 2 same values in the same column, and false otherwise </returns>
        public static bool CheckInColValidate(MatrixIntBoard board)
        {
            // this method gets the baord, if there is 2 same numbers in the same col the method returns true, false otherwise
            for (int j = 0; j < Constants.SIZE; j++)
            {
                Constants.VALUES_OF_CELLS = Constants.AddValuesOfCells();

                // copy the elemnts of VALUESOFCELLS to a new array called temp
                char[] temp = new char[Constants.VALUES_OF_CELLS.Length];
                Constants.VALUES_OF_CELLS.CopyTo(temp, 0);

                for (int i = 0; i < Constants.SIZE; i++)
                {
                    // if temp contains the board[i, j], the cell in temp will be space
                    char value = (char)board.GetBoard()[i, j];
                    value += '0';
                    if (temp.Contains(value))
                    {
                        temp[board.GetBoard()[i, j] - 1] = ' ';
                    }
                    // if not, it means that there is a value twice or more in the same col or the value is 0
                    else
                    {
                        if (board.GetBoard()[i, j] == 0)
                            continue;
                        else
                            return false;
                    }
                }
            }
            return true;
        }

        /// <summary>
        /// this method gets the baord, if there are 2 same numbers in the same sub square the method returns true, false otherwise
        /// </summary>
        /// <param name="board"> the board in int[,] type </param>
        /// <returns> true if there are 2 same values in the same sub square, and false otherwise </returns>
        public static bool CheckInSubSqueresValidate(MatrixIntBoard board)
        {
            // this method gets the baord, if there is 2 same numbers in the same sub square the method returns true, false otherwise

            // squre root of ROWS and COLS
            int sqrtRow = (int)Math.Sqrt(Constants.SIZE);
            int sqrtCol = (int)Math.Sqrt(Constants.SIZE);

            for (int i = 0; i < Constants.SIZE; i += sqrtRow)
            {
                for (int j = 0; j < Constants.SIZE; j += sqrtCol)
                {
                    Constants.VALUES_OF_CELLS = Constants.AddValuesOfCells();

                    // copy the elemnts of VALUESOFCELLS to a new array called temp
                    char[] temp = new char[Constants.VALUES_OF_CELLS.Length];
                    Constants.VALUES_OF_CELLS.CopyTo(temp, 0);

                    // loop on the sub squares in the board
                    for (int row = i; row < i + sqrtRow; row++)
                    {
                        for (int col = j; col < j + sqrtCol; col++)
                        {
                            // if temp contains the board[i, j], the cell in temp will be space
                            char value = (char)board.GetBoard()[row, col];
                            value += '0';
                            if (temp.Contains(value))
                            {
                                temp[board.GetBoard()[row, col] - 1] = ' ';
                            }
                            // if not, it means that there is a value twice or more in the same sub square or the value is 0
                            else
                            {
                                if (board.GetBoard()[row, col] == 0)
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