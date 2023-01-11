﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OmegaSudoku
{
    internal class Output
    {
        /// <summary>
        /// this method prints the welcome message
        /// </summary>
        public static void StartSolvingOutput()
        {
            Console.WriteLine("Hello to SUDOKU SOLVER ! \n" +
                              "to solve a sudoku board that found in a file type 'file' \n" +
                              "to write a sudoku board in the console type 'console' \n" +
                              "to end the solving, type 'end' :)");
        }

        /// <summary>
        /// this method prints the goodbye message
        /// </summary>
        public static void GoodByeMessage()
        {
            Console.WriteLine("thank you for using SUDOKU SOLVER !");
        }

        /// <summary>
        /// this method get the file path from the input of the user
        /// </summary>
        /// <returns> the file path </returns>
        public static string? GetFilePath()
        {
            Console.WriteLine("Enter a File Path:");
            string? filePath = Console.ReadLine();
            return filePath;
        }

        /// <summary>
        /// this method get the sudoku board from the console
        /// </summary>
        /// <returns> the sudoku board in string type </returns>
        public static string? ReadFromConsole()
        {
            Console.WriteLine("Enter a sudoku board:");
            string? boardString = Console.ReadLine();
            return boardString;
        }

        /// <summary>
        /// this method prints the board before solving
        /// </summary>
        /// <param name="board"> the board of the sudoku </param>
        public static void PrintBoard(MatrixIntBoard board)
        {
            for (int i = 0; i < Constants.SIZE; i++)
            {
                for (int j = 0; j < Constants.SIZE; j++)
                {
                    string printValue = string.Format("{0, 3}", (char)(board.GetBoard()[i, j] + '0'));
                    Console.Write(printValue);
                }
                Console.WriteLine("");
            }
        }

        /// <summary>
        /// this method prints the board after solving
        /// </summary>
        /// <param name="board"> the solved board in int[,] </param>
        public static void PrintSolution(int[,] board)
        {
            for (int i = 0; i < Constants.SIZE; i++)
            {
                for (int j = 0; j < Constants.SIZE; j++)
                {
                    string printValue = string.Format("{0, 3}", (char)(board[i, j] + '0'));
                    Console.Write(printValue);
                }
                Console.WriteLine("");
            }
        }
    }
}