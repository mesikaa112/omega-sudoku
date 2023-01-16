using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OmegaSudoku.Exceptions
{
    public class NullBoardError : Exception
    {
        /// <summary>
        /// this class is the null input to the board custom exception
        /// </summary>
        public NullBoardError(string message)
        {
            Console.WriteLine(message);
        }
    }
}
