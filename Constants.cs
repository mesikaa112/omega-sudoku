using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OmegaSudoku
{
    class Constants
    {
        public const int ROWS = 9;
        public const int COLS = 9;
        public static int[] ROWCOLVALUES = Enumerable.Range(1, Constants.ROWS).ToArray();
 
    }
}
