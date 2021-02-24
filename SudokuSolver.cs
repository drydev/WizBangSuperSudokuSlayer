using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace WizBangSuperSudokuSlayer
{
    class SudokuSolver
    {
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
                        boxRowStart = SudokuNavigation.startingPoint(m);
                        boxColStart = SudokuNavigation.startingPoint(n);

                        // Create array of current box elements
                        for (int i = boxRowStart; i < 3; i++)
                        {
                            var boxTemp = SudokuNavigation.boxLooper(i, boxColStart, playBoard);

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
    }
}
