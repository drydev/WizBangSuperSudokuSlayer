using System;
using System.Collections.Generic;
using System.Text;

namespace WizBangSuperSudokuSlayer
{
    class SudokuNavigation
    {
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
