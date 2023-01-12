# Sudoku Solver

This is a sudoku solver written in C# that uses the Dancing Links algorithm to solve puzzles. The solver is able to efficiently solve any Sudoku puzzle that follows the standard constraints:

- First constraint: Each cell can contain only one number, This means that each cell in the puzzle can contain only one number from 1 to 1/4/9/16/25 (relative to the appropriate board).

- Second constraint: Each row must contain the numbers 1 to 1/4/9/16/25: This means that each number from 1 to 1/4/9/16/25 must appear once and only once in each row of the puzzle.

Third constraint: Each column must contain the numbers 1 to 1/4/9/16/25: This means that each number from 1 to 1/4/9/16/25 must appear once and only once in each column of the puzzle.

Fourth constraint: Each sub square in the board (also known as a "block") must contain the numbers 1 to 1/4/9/16/25: This means that each number from 1 to 1/4/9/16/25 must appear once and only once in each sub square of the puzzle.


## Input

The program can read input from a file or from the console. The input should be a single string of numbers, where '0' represents an empty cell. The input string should match the dimensions of the desired board size (for example, a 9x9 board should have 81 characters in the input string).

For example, the following input string would represent a partially filled 9x9 Sudoku board:

003020600900305001001806400008102900700000008006708200002609500800203009005010300


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

Dancing Links is an algorithm for solving exact cover problems, such as the one used in Sudoku solving. The algorithm is based on the observation that the problem can be represented as a sparse matrix, where the rows represent constraints and the columns represent variables. The algorithm works by recursively deleting columns and rows from the matrix, until a solution is found or it is determined that no solution exists.
