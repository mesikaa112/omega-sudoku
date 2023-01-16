using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OmegaSudoku.Exceptions
{
    public class InvalidBoardLengthError : Exception
    {
        /// <summary>
        /// this class is the invalid board length custom exception
        /// </summary>
        public InvalidBoardLengthError(string message)
        {
            Console.WriteLine(message);
        }
    }
}
