using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OmegaSudoku.Exceptions
{
    internal class TwoValuesInTheSameRowError : Exception
    {
        /// <summary>
        /// this class is the two values in the same row custom exception
        /// </summary>
        public TwoValuesInTheSameRowError(string message)
        {
            Console.WriteLine(message);
        }
    }
}
