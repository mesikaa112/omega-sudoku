using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace OmegaSudoku
{
    internal class DLXSolver
    {
        /// <summary>
        /// this method create a DLX structure by the cover matrix that recive in parameter
        /// </summary>
        /// <param name="coverMatrix"> the cover matrix (an exact cover binary matrix) </param>
        /// <returns> a pointer to the header node of the structure </returns>
        public static HeaderNode CreateDLXStructure(byte[,] coverMatrix)
        {
            HeaderNode headerNode = new HeaderNode("header");
            HeaderNode[] columnNodes = new HeaderNode[coverMatrix.GetLength(1)];

            // add the columns headers
            for (int i = 0; i < coverMatrix.GetLength(1); i++)
            {
                HeaderNode currentHeader = new HeaderNode(System.Convert.ToString(i));
                columnNodes[i] = currentHeader;

                // Link the current header to the other headers
                headerNode = (HeaderNode)headerNode.LinkRight(currentHeader);
            }

            // return the pointer of header node to point on the header node
            headerNode = headerNode._right._header;

            // loop threw the rows in the cover matrix
            for (int row = 0; row < coverMatrix.GetLength(0); row++)
            {
                DancingNode prev = null;
                // loop threw the cols in the cover matrix
                for (int col = 0; col < coverMatrix.GetLength(1); col++)
                {
                    if (coverMatrix[row, col] == 1)
                    {
                        // connect the value to the relevant place in the structure
                        HeaderNode currentHeader = columnNodes[col];
                        DancingNode newNode = new DancingNode(currentHeader);
                        currentHeader._up.LinkDown(newNode);
                        if (prev == null)
                            prev = newNode;
                        else
                        {
                            prev.LinkRight(newNode);
                            prev = prev._right;
                        }
                        currentHeader._size++;
                    }
                }
            }
            return headerNode;
        }

        /// <summary>
        /// this method select a column node with the minimize size of the column
        /// </summary>
        /// <param name="header"> pointer to the header node of the structure </param>
        /// <returns> a pointer to the minimize size of the column </returns>
        public static HeaderNode selectColumnNodeHeuristic(HeaderNode header)
        {
            HeaderNode minimizeSizeColumn = (HeaderNode)header._right;
            int minimumSize = Constants.SIZE;

            // loop threw the columns 
            HeaderNode headerNode = (HeaderNode)header._right;
            while (headerNode != header)
            {
                if (headerNode._size < minimumSize)
                {
                    minimumSize = headerNode._size;
                    minimizeSizeColumn = headerNode;
                }

                headerNode = (HeaderNode)headerNode._right;
            }
            return (HeaderNode)minimizeSizeColumn;
        }

        /// <summary>
        /// this method solve the board in a recursive way, every iteration the function unlinks the noded that link from the right
        /// and relink the nodes that link from the left
        /// </summary>
        /// <param name="header"> pointer to the header node of the structure </param>
        /// <param name="answer"> a list<DancingNode> that contains the solution of the board </param>
        public static bool DLXSolve(HeaderNode header, List<DancingNode> answer)
        {
            // If there are no more columns, there is a solution, then print the board in the regular format
            // and end the recursive finction 
            if (header._right == header)
            {
                return true;
            }

            // loop until find the first minimize size column that his down node not equal to the column
            HeaderNode minimizeSizeColumn = selectColumnNodeHeuristic(header);
            minimizeSizeColumn.Cover();

            // loop threw the minimum column nodes
            DancingNode minimizeSizeColumnNode = minimizeSizeColumn._down;
            while (minimizeSizeColumnNode != minimizeSizeColumn)
            {
                answer.Add(minimizeSizeColumnNode);

                // loop threw the right nodes of the minimizeSizeColumnNode
                DancingNode rowNode = minimizeSizeColumnNode._right;
                while (rowNode != minimizeSizeColumnNode)
                {
                    rowNode._header.Cover();
                    rowNode = rowNode._right;
                }

                // call recursively to the function
                if (DLXSolve(header, answer))
                    return true;

                // remove the last element from the answer
                minimizeSizeColumnNode = answer.Last();
                answer.RemoveAt(answer.Count - 1);

                minimizeSizeColumn = minimizeSizeColumnNode._header;

                // loop threw the left nodes of the minimizeSizeColumnNode
                rowNode = minimizeSizeColumnNode._left;
                while (rowNode != minimizeSizeColumnNode)
                {
                    rowNode._header.Uncover();
                    rowNode = rowNode._left;
                }

                minimizeSizeColumnNode = minimizeSizeColumnNode._down;
            }
            minimizeSizeColumn.Uncover();
            return false;
        }
    }
}