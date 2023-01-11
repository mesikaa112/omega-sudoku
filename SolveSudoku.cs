using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using OmegaSudoku.Exceptions;

namespace OmegaSudoku
{
    /// <summary>
    /// this class is responsible for loop the solving of the sudoku and catch all the exceptions
    /// </summary>
    internal class SolveSudoku
    {
        /// <summary>
        /// this method catches all the exceptions
        /// </summary>
        public static void StartSolving()
        {
            while (true)
            {
                try
                {
                    Solve();
                }
                catch (InvalidBoardLengthError error)
                {
                    Console.WriteLine(error.Message + "\n");
                }
                catch (InvalidCharactersInTheStringError error)
                {
                    Console.WriteLine(error.Message + "\n");
                }
                catch (TwoValuesInTheSameRowError error)
                {
                    Console.WriteLine(error.Message + "\n");
                }
                catch (TwoValuesInTheSameColError error)
                {
                    Console.WriteLine(error.Message + "\n");
                }
                catch (TwoValuesInTheSameSubSquareError error)
                {
                    Console.WriteLine(error.Message + "\n");
                }
                catch (UnSolveableBoardError error)
                {
                    Console.WriteLine(error.Message + "\n");
                }
                catch (FileNotFoundException error)
                {
                    Console.WriteLine(error.Message + "\n");
                }
                catch (NullReferenceException error)
                {
                    Console.WriteLine(error.Message + "\n");
                }
            }
        }

        /// <summary>
        /// this method solves the sudoku board
        /// </summary>
        /// <exception cref="UnSolveableBoardError"> the board is unsolveable </exception>
        public static void Solve()
        {
            string? boardString = GetBoardString();
            Stopwatch stopwatch = new Stopwatch();
            // start the clock
            stopwatch.Start();
            MatrixIntBoard board = SudokuValidation.CheckValidate(boardString);
            Console.WriteLine("The board before solving:");
            Output.PrintBoard(board);
            Console.WriteLine("------------------------------------------------");
            byte[,] cover = ExactCoverMatrix.ChangeToExactCoverMatrix(board);
            HeaderNode DLXStructure = DLXSolver.CreateDLXStructure(cover);
            List<DancingNode> solution = new List<DancingNode>();
            // if not solveable throw an error
            if (!DLXSolver.DLXSolve(DLXStructure, solution))
            {
                // stop the clock
                stopwatch.Stop();
                Console.WriteLine("time passed: {0} milliseconds", stopwatch.ElapsedMilliseconds);
                throw new UnSolveableBoardError("there is an Error! the board is not solveable");
            }
            // if solveable, print the solution
            HandleSolution.SolutionHandler(solution);
            stopwatch.Stop();
            Console.WriteLine("time passed: {0} milliseconds", stopwatch.ElapsedMilliseconds);
        }

        /// <summary>
        /// this method returns the string of the board by the relvant option
        /// </summary>
        /// <param name="readOption"> the input option of the board </param>
        /// <returns> the string of the board by the relvant option </returns>
        public static string? Menu(string? readOption)
        {
            switch (readOption)
            {
                case "file":
                    string? boardString = ReadFromFile();
                    return boardString;
                case "console":
                    boardString = Output.ReadFromConsole();
                    return boardString;
                case "end":
                    Output.GoodByeMessage();
                    Environment.Exit(0);
                    break;
                default:
                    return readOption;
            }
            return "";
        }

        /// <summary>
        /// this method returns the board string by the relevant option
        /// </summary>
        /// <returns> the board string by the relevant option </returns>
        public static string? GetBoardString()
        {
            string? boardString;
            while (true)
            {
                Output.StartSolvingOutput();
                string? readOption = Console.ReadLine();
                boardString = Menu(readOption);
                if (boardString != readOption)
                    break;
            }
            return boardString;
        }

        /// <summary>
        /// this method gets from a file the string of the board
        /// </summary>
        /// <returns> the string of the board </returns>
        public static string? ReadFromFile()
        {
            string? filePath = Output.GetFilePath();
            string? boardString = null;
            // if filePath is not null read from file, else throw an error
            if (filePath != null)
                boardString = File.ReadAllText(filePath);
            else
                throw new FileNotFoundException("there is an Error! file not found");
            return boardString;
        }
    }
}