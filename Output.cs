using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OmegaSudoku
{
    internal class Output
    {
        public static void StartSolvingOutput()
        {
            Console.WriteLine("Hello to SUDOKU SOLVER ! \n" +
                              "to solve a sudoku board that found in a file type 'file' \n" +
                              "to write a sudoku board in the console type 'console' \n" +
                              "to end the solving, type 'end' :)");
        }


        public static string GetNewOption()
        {
            Console.WriteLine("You entered invalid option! \n" +
                              "to solve a sudoku board that found in a file type 'file' \n" +
                              "to write a sudoku board in the console type 'console' \n" +
                              "to end the solving, type 'end' :)");
            string readOption = Console.ReadLine();
            return readOption;
        }


        public static void GoodByeMessage()
        {
            Console.WriteLine("thank you for using SUDOKU SOLVER !");
        }


        public static string GetFilePath()
        {
            // this method get the file path from the user

            Console.WriteLine("Enter a File Path:");
            string filePath = Console.ReadLine();
            return filePath;
        }


        public static string ReadFromConsole()
        {
            // this method get the sudoku board from the user in the console

            Console.WriteLine("Enter a sudoku board:");
            string boardString = Console.ReadLine();
            return boardString;
        }
    }
}
