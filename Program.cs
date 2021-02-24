using System;
using WizBangSuperSudokuSlayer;

namespace WizBangSudokuSlayer
{
    class Solution
    {
        static void Main(String[] args)
        {
            // Setup the board and problem with a 2d array
            var sudoku = CsvToSudoku.CsvImporter();

            // Solve the problem
            SudokuSolver.solver(sudoku);
            // Display the result
            if (SudokuSolver.solver(sudoku) == true)
            {
                PrintArray.Print2DArray(sudoku);
            }
            else
            {
                Console.WriteLine("This puzzle is not solvable");
            }
        }
    }
}
