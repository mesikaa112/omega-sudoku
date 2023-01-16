using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OmegaSudoku.Exceptions
{
    public class FileIsNotTextFileException : Exception
    {
        /// <summary>
        /// this class is a custom exception if a file is not a text file
        /// </summary>
        public FileIsNotTextFileException(string message)
        {
            Console.WriteLine(message);
        }
    }
}
