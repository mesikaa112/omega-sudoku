using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OmegaSudoku
{
    internal class Cell
    {
        private int value;

        public Cell(int value)
        {
            // Initialize the cell with a value
            this.value = value;
        }

        public int GetValue()
        {
            return value;
        }

        public void SetValue(int newValue)
        {
            value = newValue;
        }
    }
}
