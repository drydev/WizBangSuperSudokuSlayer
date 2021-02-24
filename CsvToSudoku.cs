using System;
using System.IO;
using System.Linq;

namespace WizBangSuperSudokuSlayer
{
    class CsvToSudoku
    {
        public static char[,] CsvImporter()
        {
            Console.WriteLine("Please input CSV location: ");
            var inputLoc = Console.ReadLine();
            var csvCols = File.ReadAllLines(inputLoc);
            var csvInput = File.ReadAllLines(inputLoc).Select(l => l.Split(',').ToArray()).ToArray();

            //Get number of rows in the above:
            var rows = csvInput.Count();
            //Get number of columns from the above
            var cols = csvCols[0].Split(',').Count();

            var boardArray = new char[rows, cols];

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    boardArray[i, j] = Convert.ToChar(csvInput[i][j]);
                }
            }
            return boardArray;
        }
    }
}
