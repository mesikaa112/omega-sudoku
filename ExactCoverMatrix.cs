using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OmegaSudoku
{
    /// <summary>
    /// this class is responsible for the creation of the exact cover matrix of the sudoku board
    /// </summary>
    internal class ExactCoverMatrix
    {
        private static byte[,] _coverMatrix = new byte[Constants.SIZE * Constants.SIZE * Constants.SIZE, Constants.SIZE * Constants.SIZE * Constants.NUMBER_OF_CONSTRAINTS];

        /// <summary>
        /// this method changes the int[,] matrix board to a binary exact cover matrix
        /// </summary>
        /// <param name="board"> the int[,] matrix board </param>
        /// <returns> the binary exact cover matrix </returns>
        public static byte[,] ChangeToExactCoverMatrix(MatrixIntBoard board)
        {
            // The current column for the cell constraint
            int currentCellConstraintColumn = 0;
            // The current column for the column constraint
            int currentColumnConstraintColumn = Constants.SIZE * Constants.SIZE;
            // The current column for the row constraint
            int currentRowConstraintColumn = 2 * Constants.SIZE * Constants.SIZE;
            // The current column for the square constraint
            int currentSubSquareConstraintColumn = 3 * Constants.SIZE * Constants.SIZE;

            // The current row in the cover matrix
            int currentRow = 0;

            // Loop through the cells of the grid
            for (int row = 0; row < Constants.SIZE; row++)
            {
                // Move the column constraint column back to the start
                currentColumnConstraintColumn = Constants.SIZE * Constants.SIZE;

                for (int col = 0; col < Constants.SIZE; col++)
                {
                    // Get the current value in the grid
                    int value = board.GetBoard()[row, col];

                    // Get the current box number (1 -> size)
                    int square = (row / (int)Math.Sqrt(Constants.SIZE)) * (int)Math.Sqrt(Constants.SIZE) + col / (int)Math.Sqrt(Constants.SIZE);

                    // Loop through the possible numbers in the current cell
                    for (byte possibleValueForCell = 1; possibleValueForCell <= Constants.SIZE; possibleValueForCell++)
                    {
                        // Put a 1 only if the value is 0 or the number is the same as the value
                        if (value == 0 || possibleValueForCell == value)
                        {
                            // Fill the cell constraint
                            _coverMatrix[currentRow, currentCellConstraintColumn] = 1;

                            // Fill the column constraint
                            _coverMatrix[currentRow, currentColumnConstraintColumn] = 1;

                            // Fill the row constraint
                            _coverMatrix[currentRow, currentRowConstraintColumn + possibleValueForCell - 1] = 1;

                            // Fill the square constraint
                            _coverMatrix[currentRow, currentSubSquareConstraintColumn + square * Constants.SIZE + possibleValueForCell - 1] = 1;
                        }
                        currentRow++;
                        currentColumnConstraintColumn++;
                    }
                    currentCellConstraintColumn++;
                }
                currentRowConstraintColumn += Constants.SIZE;
            }
            return _coverMatrix;
        }
    }
}