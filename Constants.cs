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
        public const int ROWS = 4;
        public const int COLS = 4;
        public static int[] ROWCOLVALUES = Enumerable.Range(1, Constants.ROWS).ToArray();
        public static readonly System.Collections.ArrayList VALIDCHARACTERS = new ArrayList()
        { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
 
    }
}
