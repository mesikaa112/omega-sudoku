using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace OmegaSudoku
{
    /// <summary>
    /// this class is responsible for the regular node of the DLX structure
    /// </summary>
    internal class DancingNode
    {
        // the linked nodes
        public DancingNode _left, _right, _up, _down;
        // the header node
        public HeaderNode _header;

        public DancingNode(HeaderNode header)
        {
            // initialize the DLX structure to null
            this._right = this._left = this._up = this._down = this;
            this._header = header;
        }

        /// <summary>
        /// this method links the current node to the right column
        /// </summary>
        /// <param name="node"> the right node that should be linked to the current column </param>
        /// <returns> the DancingNode that linked </returns>
        public DancingNode LinkRight(DancingNode node)
        {
            node._right = this._right;
            this._right._left = node;
            this._right = node;
            node._left = this;
            return node;
        }


        /// <summary>
        /// this method links the current node to the bottom column
        /// </summary>
        /// <param name="node"> the bottom node that should be linked to the current column </param>
        /// <returns> the DancingNode that linked </returns>
        public DancingNode LinkDown(DancingNode node)
        {
            node._down = this._down;
            this._down._up = node;
            this._down = node;
            node._up = this;
            return node;
        }

        /// <summary>
        /// this method unlinks the current node from his right and left nodes
        /// </summary>
        public void UnlinkLeftRight()
        {
            this._right._left = this._left;
            this._left._right = this._right;
        }

        /// <summary>
        /// this method relinks the current node from his right and left nodes
        /// </summary>
        public void RelinkLeftRight()
        {
            this._left._right = this._right._left = this;
        }

        /// <summary>
        /// this method unlinks the current node from his up and bottom nodes
        /// </summary>
        public void UnlinkUpDown()
        {
            this._down._up = this._up;
            this._up._down = this._down;
        }

        /// <summary>
        /// this method relinks the current node from his up and bottom nodes
        /// </summary>
        public void RelinkUpDown()
        {
            this._up._down = this._down._up = this;
        }
    }
}