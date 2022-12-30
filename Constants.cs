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
        public static int ROWS;
        public static int COLS;
        // public static int[] ROWCOLVALUES = Enumerable.Range(1, 9).ToArray();
        public static char[] VALUESOFCELLS;
        public static System.Collections.ArrayList VALIDCHARACTERS = new ArrayList();
        
        public static ArrayList AddValidCharacters()
        {
            for (int i = 0; i <= ROWS; i++)
            {
                char possibleValue = (char)i;
                possibleValue += '0';
                VALIDCHARACTERS.Add(possibleValue);
            }
            return VALIDCHARACTERS;
        }


        public static char[] AddValuesOfCells()
        {
            VALUESOFCELLS = new char[ROWS];
            for (int i = 1; i <= ROWS; i++)
            {
                char value = (char)i;
                value += '0';
                VALUESOFCELLS[i - 1] = value;
            }
            return VALUESOFCELLS;
        }
    }
}
