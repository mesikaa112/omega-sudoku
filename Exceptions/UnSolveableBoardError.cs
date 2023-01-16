using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OmegaSudoku.Exceptions
{
    public class UnSolveableBoardError : Exception
    {
        /// <summary>
        /// this class is the unsolveable board custom exception
        /// </summary>
        public UnSolveableBoardError(string message)
        {
            Console.WriteLine(message);
        }
    }
}
