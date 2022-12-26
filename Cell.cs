using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OmegaSudoku
{
    internal class Cell
    {
        private int _value;
        // every empty cell in the sudoku board have an array of values that can be in this cell
        private int[]? _possibleValues;

        public Cell(int value)
        {
            // Initialize the cell with a value
            _value = value;
            if (value == 0)
            {
                // if the cell is empty, initialize an array of possible values from 1 to rows
                _possibleValues = Enumerable.Range(1, Constants.ROWCOLVALUES.Length).ToArray();
            }
            else
                _possibleValues = null;
        }

        public int GetValue()
        {
            return _value;
        }

        public void SetValue(int newValue)
        {
            _value = newValue;
        }


        public int[]? GetPossibleValues()
        {
            return _possibleValues;
        }


        public void EraseCellInPossibleValues(int value)
        {
            // this method gets a value and switch this value in _possibleValues to -1
            if (_possibleValues != null)
            {
                _possibleValues[value - 1] = -1;
            }
        }
    }
}
