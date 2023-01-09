using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OmegaSudoku
{
    internal class HandleSolution
    {
        /// <summary>
        /// this method convert the DLX structure into a int[,] matrix that present the solved board
        /// </summary>
        /// <param name="solution"> the solution of the board in list<DancingNode> </param>
        public static void SolutionHandler(List<DancingNode> solution)
        {
            // Initialize the output grid
            int[,] board = new int[Constants.SIZE, Constants.SIZE];

            // Loop through the nodes in the list
            while (solution.Count != 0)
            {
                DancingNode node = solution.Last();
                solution.RemoveAt(solution.Count - 1);

                // Find the first node in the row (the node whose column is the smallest)
                DancingNode firstNode = node;
                DancingNode nodePointer = node._right;

                while (nodePointer != node)
                {
                    if (int.Parse(nodePointer._header._name) < int.Parse(firstNode._header._name))
                    {
                        firstNode = nodePointer;
                    }
                    nodePointer = nodePointer._right;
                }

                // Get the names of the first and second headers
                int firstColumnName = int.Parse(firstNode._header._name);
                int secondColumnName = int.Parse(firstNode._right._header._name);

                // Calculate the indices in the grid and the number
                int row = firstColumnName / Constants.SIZE;
                int col = firstColumnName % Constants.SIZE;
                int num = secondColumnName % Constants.SIZE + 1;

                // Place the number in the grid
                board[row, col] = num;
            }
            // print the solution of the sudoku board
            MatrixIntBoard.PrintSolution(board);
        }
    }
}