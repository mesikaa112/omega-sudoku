using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OmegaSudoku.Exceptions
{
    internal class TwoValuesInTheSameSubSquareError : Exception
    {
        /// <summary>
        /// this class is the two values in the same sub square custom exception
        /// </summary>
        public TwoValuesInTheSameSubSquareError(string message)
        {
            Console.WriteLine(message);
        }
    }
}
