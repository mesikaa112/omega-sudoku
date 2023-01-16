using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OmegaSudoku.Exceptions
{
    public class TwoValuesInTheSameColError : Exception
    {
        /// <summary>
        /// this class is the two values in the same col custom exception
        /// </summary>
        public TwoValuesInTheSameColError(string message)
        {
            Console.WriteLine(message);
        }
    }
}
