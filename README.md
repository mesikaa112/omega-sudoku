# Sudoku Solver

This is a sudoku solver written in C# that uses the backtracking algorithm to solve puzzles. It also includes techniques for identifying and solving Naked Single Cells and Hidden Singles.


## Installation

To install this sudoku solver, follow these steps:

1. Clone this repository to your local machine using Git:

```git
  git clone https://github.com/mesikaa112/omega-sudoku
```

2. Open the solution file (OmegaSudoku.sln) in Visual Studio.

3. Build the solution by going to Build > Build Solution or by pressing 'Ctrl + Shift + B'.


## Usage

To use the sudoku solver, follow these steps:

1. Open the SudokuProgram.cs file in Visual Studio.

2. Run the program by going to 'Debug' > 'Start Debugging' or by pressing 'F5'.

After strat to running, need to type choose the option of type the board (from the console or from a file)

The sudoku solver will output the solution to the puzzle to the console.


## Algorithm

The sudoku solver uses the backtracking algorithm to search for a solution to the puzzle. It starts at the first empty cell, and tries each possible value to this cell until it finds a solution or determines that no solution is possible. If no solution is found, it backtracks to the previous cell and tries a different value.



In addition to the backtracking algorithm, the sudoku solver also uses two techniques to identify and solve cells with a single possibility:

- Naked Single Cells: A cell with a single possible value is called a Naked Single Cell. The solver will automatically fill in any Naked Single Cells it finds.

- Hidden Singles: A cell with a single possible value that is not visible in any of the other cells in its row, column, or sub square is called a Hidden Single. The solver will use the Hidden Singles technique to identify and solve these cells.
