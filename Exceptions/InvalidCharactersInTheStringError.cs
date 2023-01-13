using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OmegaSudoku.Exceptions
{
    public class InvalidCharactersInTheStringError : Exception
    {
        /// <summary>
        /// this class is the invalid character in the string custom exception
        /// </summary>
        public InvalidCharactersInTheStringError(string message)
        {
            Console.WriteLine(message);
        }
    }
}
