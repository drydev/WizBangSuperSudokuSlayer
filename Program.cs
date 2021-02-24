using System;
using System.IO;
using System.Linq;
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
            solver(sudoku);
            // Display the result
            if (solver(sudoku) == true)
            {
                PrintArray.Print2DArray(sudoku);
            }
            else
            {
                Console.WriteLine("This puzzle is not solvable");
            }
        }
        // The main recursive solver
        public static bool solver(int[,] playBoard)
        {
            //Get the size of the incoming board
            var rows = playBoard.GetLength(0);
            var cols = playBoard.GetLength(1);


            // declare some variables
            var rowArray = new int[rows];
            var colArray = new int[cols];
            var currentBox = new int[9];

            int boxRowStart;
            int boxColStart;

            // the next two loops and one conditional statement check game board spaces for a '.'
            for (int m = 0; m < playBoard.GetLength(0); m++)
            {

                for (int n = 0; n < playBoard.GetLength(1); n++)
                {
                    // check to see if the currently selected instance is a '.'
                    if (playBoard[m, n] == 0)
                    {

                        // Gets each element of row and add to array
                        for (int i = 0; i < rows; i++)
                        {
                            rowArray[i] = playBoard[m, i];
                        }

                        // Gets each element of Col and adds to array
                        for (int i = 0; i < cols; i++)
                        {
                            colArray[i] = playBoard[i, n];
                        }

                        // Find the current starting point for box, col and rows
                        boxRowStart = startingPoint(m);
                        boxColStart = startingPoint(n);

                        // Create array of current box elements
                        for (int i = boxRowStart; i < 3; i++)
                        {
                            var boxTemp = boxLooper(i, boxColStart, playBoard);

                            Array.Copy(boxTemp, 0, currentBox, (i * 3), 3);
                        }

                        // replace the '.' with a unique number 
                        for (int i = 1; i <= rows; i++)
                        {
                            var uniqueNum = i;

                            // Check the uniqueness of rows, columns and boxes, if so do the recursive strut. 
                            if (rowArray.Contains(uniqueNum) == false && colArray.Contains(uniqueNum) == false && currentBox.Contains(uniqueNum) == false)
                            {
                                playBoard[m, n] = uniqueNum;

                                if (solver(playBoard))
                                {
                                    return true;
                                }

                                else
                                {
                                    playBoard[m, n] = 0;
                                }
                            }
                        }
                        return false;
                    }

                }

            }
            return true;
        }

        public static int[] boxLooper(int row, int col, int[,] playBoard)
        {
            var inputBox = new int[3];

            for (int i = 0; i <= 2; i++)
            {
                inputBox[i] = playBoard[row, (col + i)];
            }
            return inputBox;
        }

        public static int startingPoint(int input)
        {
            var startingReturn = 0;

            // Work out starting col/row for box check
            if (input >= 0 && input <= 2)
            {
                startingReturn = 0;
            }

            else if (input >= 3 && input <= 5)
            {
                startingReturn = 3;
            }

            else if (input >= 6 && input <= 8)
            {
                startingReturn = 6;
            }
            return startingReturn;
        }
    }
}
