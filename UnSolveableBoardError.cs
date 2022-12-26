using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OmegaSudoku
{
    internal class UnSolveableBoardError : Exception
    {
        public UnSolveableBoardError(string message)
        {
            Console.WriteLine(message);
        }
    }
}
