using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatrixDeterminant
{
    internal class Program
    {
        /* Write a function that accepts a square matrix(N x N 2D array) and returns the determinant of the matrix.

 How to take the determinant of a matrix -- it is simplest to start with the smallest cases:

 A 1x1 matrix |a| has determinant a.

 A 2x2 matrix[[a, b], [c, d] ] or

 |a b|
 |c d|
 has determinant: a* d - b* c.

  The determinant of an n x n sized matrix is calculated by reducing the problem to the calculation of the determinants of n matrices ofn-1 x n-1 size.

  For the 3x3 case, [ [a, b, c], [d, e, f], [g, h, i] ] or

 |a b c|  
 |d e f|  
 |g h i|  
 the determinant is: a* det(a_minor) - b* det(b_minor) + c* det(c_minor) where det(a_minor) refers to taking the determinant of the 2x2 matrix created by crossing out the row and column in which the element a occurs:

 |- - -|
 |- e f|
 |- h i|  
 Note the alternation of signs.

 The determinant of larger matrices are calculated analogously, e.g. if M is a 4x4 matrix with first row[a, b, c, d], then:


 det(M) = a* det(a_minor) - b* det(b_minor) + c* det(c_minor) - d* det(d_minor)*/
       /* Напишите функцию, которая принимает квадратную матрицу(массив N x N 2D) и возвращает определитель матрицы.

Как взять определитель матрицы — проще всего начать с наименьших случаев:

Матрица 1x1 |a| имеет определитель а.

Матрица 2x2[[a, b], [c, d]] или

|а б|
|с г|
имеет определитель: a* d - b* c.

 Определитель матрицы размера n x n вычисляется путем сведения задачи к вычислению определителей n матриц размера n-1 x n-1.


 Для случая 3x3[[a, b, c], [d, e, f], [g, h, i]] или

|а б в|
|d е е|
|г ч я|
определитель: a* det(a_minor) - b* det(b_minor) + c* det(c_minor), где det(a_minor) относится к определителю матрицы 2x2, созданной путем вычеркивания строки и столбца, в котором элемент происходит:

|- - -|
|- е е|
|- ч я|
Обратите внимание на чередование знаков.

Определитель больших матриц вычисляется аналогично, например.если M - матрица 4x4 с первой строкой[a, b, c, d], то:

det(M) = a* det(a_minor) - b* det(b_minor) + c* det(c_minor) - d* det(d_minor)*/

        static void Main(string[] args)
        {
        }

        public static int Determinant(int[][] matrix)
        {
            int numRows = matrix.Length;
            int numCols = matrix[0].Length;

            if (numRows != numCols)
            {
                throw new ArgumentException("Матрица должна быть квадратной");
            }

            if (numRows == 1 && numCols == 1)
            {
                return matrix[0][0];
            }

            if (numRows == 2 && numCols == 2)
            {
                return matrix[0][0] * matrix[1][1] - matrix[0][1] * matrix[1][0];
            }

            int result = 0;

            for (int col = 0; col < numCols; col++)
            {
                if (col % 2 == 0)
                    result += matrix[0][col] * Determinant(GetminorMatrix(0, col, matrix));
                else
                    result -= matrix[0][col] * Determinant(GetminorMatrix(0, col, matrix));
                
            }

            /*  if (numRows == 3 && numCols == 3)
              {
                  return matrix[0][0] * Determinant(GetminorMatrix(0, 0, matrix)) -
                         matrix[0][1] * Determinant(GetminorMatrix(0, 1, matrix)) +
                         matrix[0][2] * Determinant(GetminorMatrix(0, 2, matrix));
              }*/
            return result;
        }

        public static int[][] GetminorMatrix(int row,int col, int[][] matrix)
        {
            int numRows = matrix.Length;
            int numCols = matrix[0].Length;
            int[][] minor = new int[numRows-1][];
            int rowIndex = 0;
            for (int i = 0; i < numRows; i++)
            {
                if (i == row)
                    continue;

                minor[rowIndex] = new int[numCols - 1];
                int colIndex = 0;
                for (int j = 0; j < numCols; j++)
                {
                    if (j == col)
                        continue;

                    minor[rowIndex][colIndex++] = matrix[i][j];
                    
                }
                ++rowIndex;                
            }
            return minor;
        }

        public static void PrintMatrix(int[][] matrix)
        {
            int numRows =matrix.Length;
            for (int i = 0; i < numRows; i++)
            {
                int[] row = matrix[i];
                string rowVals = $"Row {i}";

                foreach (int n in row)
                {
                    rowVals += $"{n}, ";
                }
                Console.WriteLine(rowVals);
            }
        }

       /* public static int Determinant(int[][] matrix)
        {
            int det = 0;
            if (matrix.Length != matrix[0].Length)
                return -1;
            if (matrix.Length == 1)
                return matrix[0][0];

            for (int i = 0; i < matrix.Length; i++)
                det += (int)Math.Pow(-1, i) * matrix[0][i] * Determinant(Minor(matrix, i));

            return det;
        }

        public static int[][] Minor(int[][] matrix, int pos)
        {
            int[][] minor = new int[matrix.Length - 1][];
            for (int i = 0; i < minor.Length; i++)
                minor[i] = new int[minor.Length];

            for (int i = 1; i < matrix.Length; i++)
            {
                for (int j = 0; j < pos; j++)
                    minor[i - 1][j] = matrix[i][j];
                for (int j = pos + 1; j < matrix.Length; j++)
                    minor[i - 1][j - 1] = matrix[i][j];
            }
            return minor;
        }*/
    }
}
