using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace OmegaSudoku
{
    /// <summary>
    /// Author: Yonatan Mesika
    /// Date of Submission: 16.01.23
    /// </summary>
    internal class SudokuProgram
    {
        /// <summary>
        /// this is the Main function
        /// </summary>
        public static void Main()
        {
            SolveSudoku.StartSolving();
        }
    }
}
