using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OmegaSudoku
{
    /// <summary>
    /// this class is responsible for handling the solution - converts the solutions
    /// </summary>
    internal class HandleSolution
    {
        /// <summary> 
        /// this method convert the DLX structure into a int[,] matrix that present the solved board
        /// </summary>
        /// <param name="solution"> the solution of the board in list<DancingNode> </param>
        public static int[,] SolutionHandler(List<DancingNode> solution)
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
            return board;
        }

        /// <summary>
        /// this method converts the solution from int[,] matrix into string
        /// </summary>
        /// <param name="solution"> the solution of the board in int[,] matrix </param>
        /// <returns> the solution of the board in string </returns>
        public static string ConvertFromIntMatrixToString(int[,] solution)
        {
            string solutionString = "";

            for (int i = 0; i < solution.GetLength(0); i++)
            {
                for (int j = 0; j < solution.GetLength(1); j++)
                {
                    // add to solutionString the board solution
                    solutionString += (char)(solution[i, j] + '0');
                }
            }
            return solutionString;
        }
    }
}