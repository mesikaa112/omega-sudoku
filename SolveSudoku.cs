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
    public class SolveSudoku
    {
        /// <summary>
        /// this method catches all the exceptions
        /// </summary>
        public static void StartSolving()
        {
            // print welcome message
            Output.WelcomeMessage();
            while (true)
            {
                try
                {
                    string? boardString = GetBoardString();
                    string? outputFilePath = GetOutputString();
                    string solutionString = Solve(boardString, outputFilePath);
                    Output.PrintInTheStringFormatSolution(solutionString);
                }
                catch (NullBoardError error)
                {
                    Console.WriteLine(error.Message + "\n");
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
            }
        }

        /// <summary>
        /// this method solves the sudoku board
        /// </summary>
        /// <param name="boardString"> the unsolved board in string type </param>
        /// <returns> the solved board in string type </returns>
        /// <exception cref="UnSolveableBoardError"> the board is unsolveable </exception>
        public static string Solve(string? boardString, string? outputFilePath)
        {
            Stopwatch stopwatch = new Stopwatch();
            // start the clock
            stopwatch.Start();

            // check validate of boardString, if valid insert boardString into MatrixIntBoard
            MatrixIntBoard board = SudokuValidation.CheckValidate(boardString);

            // print the board before solved
            Console.WriteLine("The board before solving:");
            Output.PrintBoard(board);
            Console.WriteLine("------------------------------------------------");

            // create the exact cover matrix
            byte[,] cover = ExactCoverMatrix.ChangeToExactCoverMatrix(board);

            // convert the exact cover matrix to DLX structure
            HeaderNode DLXStructure = DLXSolver.CreateDLXStructure(cover);

            List<DancingNode> solution = new List<DancingNode>();
            // solve the DLX structure, if not solveable throw an error
            bool isSolveabale = DLXSolver.DLXSolve(DLXStructure, solution);
            if (!isSolveabale)
            {
                // stop the clock and print the time passed
                stopwatch.Stop();
                Console.WriteLine("solving time passed: {0} milliseconds \n", stopwatch.ElapsedMilliseconds);
                throw new UnSolveableBoardError("there is an Error! the board is not solveable");
            }
            // if solveable, print the solution
            int[,] solutionMatrix = HandleSolution.SolutionHandler(solution);

            // print the solution of the sudoku board
            Output.PrintSolution(solutionMatrix);

            // stop the clock and print the time passed
            stopwatch.Stop();
            Console.WriteLine("solving time passed: {0} milliseconds \n", stopwatch.ElapsedMilliseconds);

            // convert the solution into string
            string solutionString = HandleSolution.ConvertFromIntMatrixToString(solutionMatrix);

            // write the solution into file (if it should be written into)
            WriteToFile(outputFilePath, solutionString);

            // returns the solved board
            return solutionString;
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
        /// this method returns the path of the file if the user wants to print the solution into file,
        /// if not, return empty path
        /// </summary>
        /// <param name="outputOption"> the option that the user selected to print the solution </param>
        /// <returns> the path of the file if the user wants to print the solution into file, if not, empty path </returns>
        public static string? OutputMenu(string? outputOption)
        {
            switch (outputOption)
            {
                case "file":
                    string? filePath = Output.GetFilePath();
                    return filePath;
                case "console":
                    return "";
                default:
                    return outputOption;
            }
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
                // the readOption is not valid
                Output.InvalidReadOption(readOption);
            }
            return boardString;
        }

        /// <summary>
        /// this method gets from the user the path of the file that the solution will be written into
        /// </summary>
        /// <returns> the path of the file that the solution will be written into </returns>
        public static string? GetOutputString()
        {
            string? filePath = "";
            while (true)
            {
                Output.PrintOutputOption();
                string? outputOption = Console.ReadLine();
                filePath = OutputMenu(outputOption);
                if (filePath != outputOption)
                    break;
                // the outputOption is not valid
                Output.InvalidOutputOption(outputOption);
            }
            return filePath;
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

        /// <summary>
        /// this method writes the solution in string type to file
        /// </summary>
        /// <param name="filePath"> the full path of the file that the solution should be written into </param>
        /// <param name="solutionString"> the solution of the board in string type </param>
        public static void WriteToFile(string? filePath, string solutionString)
        {
            // if the file path is empty or only spaces, don't write the silution into file,
            // otherwise write the solution into filePath file
            if (filePath != "" && filePath != null && !SudokuValidation.CheckForSpaces(filePath))
                File.WriteAllText(filePath, solutionString);
        }
    }
}