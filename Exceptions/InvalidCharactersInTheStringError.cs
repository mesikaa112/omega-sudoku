﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OmegaSudoku.Exceptions
{
    internal class InvalidCharactersInTheStringError : Exception
    {
        public InvalidCharactersInTheStringError(string message)
        {
            Console.WriteLine(message);
        }
    }
}
