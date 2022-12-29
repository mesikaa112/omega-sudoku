using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace OmegaSudoku
{
    internal class SolveSudoku
    {
        public static void StartSolving()
        {
            // this method catch all the errors

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



        public static void Solve()
        {
            // this method solve the sudoku board

            Stopwatch stopwatch = new Stopwatch();
            // start the clock
            string boardString = GetBoardString();
            stopwatch.Start();
            Board board = SudokuValidation.CheckValidate(boardString);
            Console.WriteLine("The board before solving:");
            board.PrintBoard();
            Console.WriteLine("------------------------------------------------");
            // optimize the solving of the board
            CrookAlgorithm.SetPossibleValues(board);
            // solve the board
            bool solveable = BacktrackingAlgorithm.SolveBacktracking(board);
            // if not solveable throw an error
            if (!solveable)
                throw new UnSolveableBoardError("there is an Error! the board is not solveable");
            Console.WriteLine("The solved Board:");
            board.PrintBoard();
            Console.WriteLine("------------------------------------------------");
            // stop the clock
            stopwatch.Stop();
            Console.WriteLine("time passed: {0} milliseconds", stopwatch.ElapsedMilliseconds);
        }



        public static string Menu(string readOption)
        {
            // this method return the string of the board by the relvant option
            switch (readOption)
            {
                case "file":
                    string boardString = ReadFromFile();
                    return boardString;
                case "console":
                    boardString = Output.ReadFromConsole();
                    return boardString;
                case "end":
                    Output.GoodByeMessage();
                    Environment.Exit(0);
                    break;
                default:
                    Menu(Output.GetNewOption());
                    break;
            }
            return "";
        }



        public static string GetBoardString()
        {
            // this method return the board string by the relevant option
            Output.StartSolvingOutput();
            string readOption = Console.ReadLine();
            string boardString = Menu(readOption);
            return boardString;
        }


        public static string ReadFromFile()
        {
            // this method gets from a file the string of the board
            string filePath = Output.GetFilePath();
            string boardString = File.ReadAllText(filePath);
            return boardString;
        }
    }
}
