using System;

using System.Linq;

class Solution
{
    static void Main(String[] args)
    {
        // Setup the board and problem with a 2d array
        var sudoku = new char[,]
        {
            { '5', '3', '.', '.', '7', '.', '.', '.', '.' },
            { '6', '.', '.', '1', '9', '5', '.', '.', '.' },
            { '.', '9', '8', '.', '.', '.', '.', '6', '.' },
            { '8', '.', '.', '.', '6', '.', '.', '.', '3' },
            { '4', '.', '.', '8', '.', '3', '.', '.', '1' },
            { '7', '.', '.', '.', '2', '.', '.', '.', '6' },
            { '.', '6', '.', '.', '.', '.', '2', '8', '.' },
            { '.', '.', '.', '4', '1', '9', '.', '.', '5' },
            { '.', '.', '.', '.', '8', '.', '.', '7', '9' }
        };

        // Solve the problem
        solver(sudoku);
        // Display the result
        Print2DArray(sudoku);
    }

    // The main recursive solver
    public static bool solver(char[,] playBoard)
    {

        // declare some variables
        var rowArray = new char[9];
        var colArray = new char[9];
        var currentBox = new char[9];

        int boxRowStart;
        int boxColStart;

        // the next two loops and one conditional statement check game board spaces for a '.'
        for (int m = 0; m < playBoard.GetLength(0); m++)
        {

            for (int n = 0; n < playBoard.GetLength(1); n++)
            {
                // check to see if the currently selected instance is a '.'
                if (playBoard[m, n] == '.')
                {

                    // Gets each element of row and add to array
                    for (int i = 0; i <= 8; i++)
                    {
                        rowArray[i] = playBoard[m, i];
                    }

                    // Gets each element of Col and adds to array
                    for (int i = 0; i <= 8; i++)
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
                    for (int i = 1; i < 10; i++)
                    {
                        var uniqueNum = i.ToString()[0];

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
                                playBoard[m, n] = '.';
                            }
                        }
                    }
                    return false;
                }

            }

        }
        return true;
    }

    public static char[] boxLooper(int row, int col, char[,] playBoard)
    {
        var inputBox = new char[3];

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



    public static void Print2DArray<T>(T[,] matrix)
    {
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                Console.Write(matrix[i, j] + "\t");
            }
            Console.WriteLine();
        }
    }
}