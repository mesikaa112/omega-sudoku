using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace OmegaSudoku
{
    internal class HeaderNode : DancingNode
    {
        // The number of connected nodes in the current column
        public int _size;

        // The name of the column
        public string _name;

        public HeaderNode(string name) : base(null)
        {
            this._size = 0;
            this._name = name;
            this._header = this;
        }

        /// <summary>
        /// this method unlinks the rows that are connected to the current node
        /// </summary>
        public void Cover()
        {
            // this method

            // unlink the header node
            this.UnlinkLeftRight();
            // this is a pointer to the rows DancingNodes
            DancingNode rowNodes = this._down;

            while (rowNodes != this)
            {
                // this is a pointer to the current DancingNode
                DancingNode currentNode = rowNodes._right;

                while (rowNodes != currentNode)
                {
                    // Unlink the current node from it's column
                    currentNode.UnlinkUpDown();
                    currentNode._header._size--;
                    // move to the next node from the right
                    currentNode = currentNode._right;
                }
                // move to the next node from the bottom
                rowNodes = rowNodes._down;
            }
        }

        /// <summary>
        /// this method relinks the rows that are connected to the current node
        /// </summary>
        public void Uncover()
        {
            // this is a pointer to the rows DancingNodes
            DancingNode rowNodes = this._up;

            while (rowNodes != this)
            {
                // this is a pointer to the current DancingNode
                DancingNode currentNode = rowNodes._left;
                while (currentNode != rowNodes)
                {
                    // Relink the current node to its column
                    currentNode.RelinkUpDown();
                    currentNode._header._size++;
                    // move to the next node from the left
                    currentNode = currentNode._left;
                }
                // move to the next above node
                rowNodes = rowNodes._up;
            }

            // Relink the header node
            this.RelinkLeftRight();
        }
    }
}
