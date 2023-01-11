using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OmegaSudoku
{
    class Constants
    {
        // The number of constraints there are for each cell in the board
        public const int NUMBER_OF_CONSTRAINTS = 4;

        public static int SIZE;
        // public static int[] ROWCOLVALUES = Enumerable.Range(1, 9).ToArray();
        public static char[] VALUES_OF_CELLS;
        public static System.Collections.ArrayList VALID_CHARACTERS = new ArrayList();

        /// <summary>
        /// thid method added an array list of all the valid characters that can be in the input
        /// </summary>
        /// <returns> array list of all the valid characters that can be in the input </returns>
        public static ArrayList AddValidCharacters()
        {
            for (int i = 0; i <= SIZE; i++)
            {
                char possibleValue = (char)i;
                possibleValue += '0';
                VALID_CHARACTERS.Add(possibleValue);
            }
            return VALID_CHARACTERS;
        }

        /// <summary>
        /// this method added an array of char with values that can be in a cell
        /// </summary>
        /// <returns></returns>
        public static char[] AddValuesOfCells()
        {
            VALUES_OF_CELLS = new char[SIZE];
            for (int i = 1; i <= SIZE; i++)
            {
                char value = (char)i;
                value += '0';
                VALUES_OF_CELLS[i - 1] = value;
            }
            return VALUES_OF_CELLS;
        }
    }
}