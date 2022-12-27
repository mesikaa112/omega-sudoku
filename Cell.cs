using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace OmegaSudoku
{
    internal class Cell
    {
        private int _value;
        // every empty cell in the sudoku board have an array list of values that can be in this cell
        private ArrayList? _possibleValues;

        public Cell(int value)
        {
            // Initialize the cell with a value
            _value = value;
            if (value == 0)
            {
                // if the cell is empty, initialize an array of possible values that contains all the possible values
                _possibleValues = new ArrayList();
                foreach (var possibleValue in Constants.ROWCOLVALUES)
                {
                    _possibleValues.Add(possibleValue);
                }
                
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


        public ArrayList? GetPossibleValues()
        {
            return _possibleValues;
        }



        public void EraseCellInPossibleValues(int value)
        {
            // this method gets a value and erase the value from the array list
            if (_possibleValues != null && _possibleValues.Contains(value))
            {
                _possibleValues.Remove(value);
            }
        }
    }
}
