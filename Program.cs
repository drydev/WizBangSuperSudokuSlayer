using System;
using WizBangSuperSudokuSlayer;

namespace WizBangSudokuSlayer
{
    class Solution
    {
        static void Main(String[] args)
        {
            // Setup the board and problem with a 2d array
            var inputPath = Console.ReadLine();
            var sudoku = CsvToSudoku.CsvImporter(inputPath);

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
