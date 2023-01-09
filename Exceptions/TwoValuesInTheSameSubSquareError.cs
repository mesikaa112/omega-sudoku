using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OmegaSudoku.Exceptions
{
    internal class TwoValuesInTheSameSubSquareError : Exception
    {
        public TwoValuesInTheSameSubSquareError(string message)
        {
            Console.WriteLine(message);
        }
    }
}
