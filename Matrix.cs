using System;

namespace AlgorithmIntro
{
    public class Matrix
    {
        /// <summary>
        /// Prints the 2 dimensional matrix
        /// </summary>
        /// <param name="twoDMatrix">Matrix</param>
        public static void Print(int[,] twoDMatrix)
        {
            for (int i = 0; i < twoDMatrix.GetLength(0); i++)
            {
                for (int j = 0; j < twoDMatrix.GetLength(1); j++)
                    Console.Write("{0,5}", twoDMatrix[i, j]);
                Console.Write("\n\n");
            }
        }

        /// <summary>
        /// Prints the one dimensional matrix
        /// </summary>
        /// <param name="oneDMatrix">Matrix</param>
        public static void Print(int[] oneDMatrix)
        {
            for (int i = 0; i < oneDMatrix.GetLength(0); i++)
                    Console.Write("{0,5}", oneDMatrix[i]);
        }

        /// <summary>
        /// Fills the one dimensional matrix with random numbers in the range of min and max value
        /// </summary>
        /// <param name="oneDMatrix">The one dimensional matrix</param>
        /// <param name="min">Minimum element value</param>
        /// <param name="max">Maximum element value</param>
        public static void Fill(int[] oneDMatrix, int min, int max)
        {
            for (int i = 0; i < oneDMatrix.Length; i++)
                oneDMatrix[i] = new Random().Next(min, max);
        }

        /// <summary>
        /// Fills the two dimensional matrix with random numbers in the range of min and max value
        /// </summary>
        /// <param name="twoDMatrix">The two dimensional matrix</param>
        /// <param name="min">Minimum element value</param>
        /// <param name="max">Maximum element value</param>
        public static void Fill(int[,] twoDMatrix, int min, int max)
        {
            for (int i = 0; i < twoDMatrix.GetLength(0); i++)
                for (int j = 0; j < twoDMatrix.GetLength(1); j++)
                    twoDMatrix[i, j] = new Random().Next(min, max);
        }




        /// <summary>
        /// Checks the matrix if its line and column is equal each other
        /// </summary>
        /// <param name="twoDMatrix">The matrix</param>
        /// <returns>( bool ) If it is square return true otherwise returns false</returns>
        public static bool IsSquareMatrix(int[,] twoDMatrix) => twoDMatrix.GetLength(0) == twoDMatrix.GetLength(1);

        /// <summary>
        /// Checks the matrices if they same
        /// </summary>
        /// <param name="twoDMatrix1">Matrix One</param>
        /// <param name="twoDMatrix2">Matrix Two</param>
        /// <returns>( Bool ) if they same return true otherwise returns false</returns>
        public static bool IsSame(int[,] twoDMatrix1, int[,] twoDMatrix2)
        {
            bool checker = true;
            if (twoDMatrix1.GetLength(0) == twoDMatrix2.GetLength(0) && twoDMatrix1.GetLength(1) == twoDMatrix2.GetLength(1))
            {
                for (int i = 0; i < twoDMatrix1.GetLength(0); i++)
                    for (int j = 0; j < twoDMatrix1.GetLength(1); j++)
                        if (twoDMatrix1[i, j] != twoDMatrix2[i, j])
                        {
                            checker = false;
                            break;
                        }
            }
            else
                checker = false;

            return checker;
        }

        /// <summary>
        /// Checks if the matrix is symmetrical
        /// </summary>
        /// <param name="twoDMatrix">The matrix</param>
        /// <returns>( Bool ) Returns true if it symmetrical otherwise returns false</returns>
        public static bool IsSymmetrical(int[,] twoDMatrix)
        {
            for (int i = 1; i < twoDMatrix.GetLength(0); i++)
                for (int j = 0; j <= i - 1; j++)
                    if (!(twoDMatrix[i, j] == twoDMatrix[j, i]))
                        return false;

            return true;
        }

        /// <summary>
        /// Checks if the diagonals is filled and the other elements are zero
        /// </summary>
        /// <param name="twoDMatrix">The matrix</param>
        /// <returns>( bool ) If the condition is met returns true otherwise returns false</returns>
        public static bool IsDiagonal(int[,] twoDMatrix)
        {
            for (int i = 0; i < twoDMatrix.GetLength(0); i++)
                for (int j = 0; j < twoDMatrix.GetLength(1); j++)
                    if (i != j)
                        if (!(twoDMatrix[i, j] == 0))
                            return false;


            return true;
        }

        /// <summary>
        /// Checks if the matrix is top triangle
        /// </summary>
        /// <param name="twoDMatrix">The matrix</param>
        /// <returns>( bool ) Returns true if it is top triangle otherwise returns false</returns>
        public static bool IsTopTriangle(int[,] twoDMatrix)
        {
            if (twoDMatrix.GetLength(1)!=twoDMatrix.GetLength(0))
                return false;

            for (int i = 0; i < twoDMatrix.GetLength(1); i++)
                for (int j = 0; j <= i - 1; j++)
                    if (twoDMatrix[i, j] != 0)
                        return false;

            return true;
        }

        /// <summary>
        /// Checks if the matrix is bottom triangle
        /// </summary>
        /// <param name="twoDMatrix">The matrix</param>
        /// <returns>( bool ) Returns true if it is bottom triangle otherwise returns false</returns>
        public static bool IsBottomTriangle(int[,] twoDMatrix)
        {
            if (twoDMatrix.GetLength(1) != twoDMatrix.GetLength(0))
                return false;

            for (int i = 0; i < twoDMatrix.GetLength(0) - 1; i++)
                for (int j = i + 1; j < twoDMatrix.GetLength(1); j++)
                    if (twoDMatrix[i, j] != 0)
                       return false;

            return true;
        }




        /// <summary>
        /// Finds the detarmiant of 2x2 or 3x3 matrix
        /// </summary>
        /// <param name="twoDMatrix">Matrix</param>
        /// <returns>( int ) Detarminant(X)</returns>
        public static int Detarminant(int[,] twoDMatrix)
        {
            if (twoDMatrix.GetLength(0) == twoDMatrix.GetLength(1))
            {
                if (twoDMatrix.Length == 4)
                    return twoDMatrix[0, 0] * twoDMatrix[1, 1] - twoDMatrix[0, 1] * twoDMatrix[1, 0];
                else if (twoDMatrix.Length == 9)
                    return twoDMatrix[0, 0] * (twoDMatrix[1, 1] * twoDMatrix[2, 2] - twoDMatrix[1, 2] * twoDMatrix[2, 1]) -
                           twoDMatrix[0, 1] * (twoDMatrix[1, 0] * twoDMatrix[2, 2] - twoDMatrix[2, 0] * twoDMatrix[1, 2]) +
                           twoDMatrix[0, 2] * (twoDMatrix[1, 0] * twoDMatrix[2, 1] - twoDMatrix[1, 1] * twoDMatrix[2, 0]);
                else
                {
                    Console.WriteLine("Invalid Matrix");
                    return 0;
                }
            }
            else
            {
                Console.WriteLine("Invalid Matrix");
                return 0;
            }
        }

        /// <summary>
        /// Collects all element in a two dimensional matrix.
        /// </summary>
        /// <param name="twoDMatrix">The matrix</param>
        /// <returns>( int ) Sum of the elements of matrix</returns>
        public static int SumOfElements(int[,] twoDMatrix)
        {
            int y = 0;
            for (int j = 0; j < twoDMatrix.GetLength(0); j++)
                for (int i = 0; i < twoDMatrix.GetLength(1); i++)
                    y += twoDMatrix[j, i];
            return y;
        }

        /// <summary>
        /// Collects all element in a one dimensional matrix.
        /// </summary>
        /// <param name="oneDMatrix">The matrix</param>
        /// <returns>( int ) Sum of the elements of matrix</returns>
        public static int SumOfElements(int[] oneDMatrix)
        {
            int y = 0;
            for (int j = 0; j < oneDMatrix.Length; j++)
                y += oneDMatrix[j];
            return y;
        }

        /// <summary>
        /// Finds trace of a square matrix
        /// </summary>
        /// <param name="twoDMatrix">The matrix</param>
        /// <returns>( int ) Sum of the diagonal elements</returns>
        public static int TraceOfMatrix(int[,] twoDMatrix)
        {
            if (twoDMatrix.GetLength(0) == twoDMatrix.GetLength(1))
            {
                int sum = 0;
                for (int i = 0; i < twoDMatrix.GetLength(0); i++)
                    sum += twoDMatrix[i, i];
                return sum;
            }
            else
            {
                Console.WriteLine("The given array is not a square matrix");
                return 0;
            }
        }




        /// <summary>
        /// Finds the numbers on the diagonal of the given square matrix
        /// </summary>
        /// <param name="twoDMatrix"></param>
        /// <returns></returns>
        public static int[] DiagonalElements(int[,] twoDMatrix)
        {
            if (twoDMatrix.GetLength(0)==twoDMatrix.GetLength(1))
            {
                int[] elements = new int[twoDMatrix.GetLength(0)];
                for (int i = 0; i < twoDMatrix.GetLength(0); i++)
                    elements[i] = twoDMatrix[i, i];
                return elements;
            }
            else
            {
                Console.WriteLine("The given array is not a square matrix");
                return new int[1];
            }
        }
        
        /// <summary>
        /// Creates a new two dimensional matrix
        /// </summary>
        /// <param name="line"="line">Line number</param>
        /// <param name="column">Column number</param>
        /// <param name="min">Minimum value</param>
        /// <param name="max">Maximum value</param>
        /// <returns>( int[,] ) Matrix X</returns>
        public static int[,] Create(int line = 3, int column = 3, int min = 1, int max = 9)
        {
            int[,] X = new int[line, column];
            
            for (int i = 0; i < line; i++)
                for (int j = 0; j < column; j++)
                    X[i, j] = new Random().Next(min, max);
            
            return X;
        }

        /// <summary>
        /// Creates a new two dimensional matrix
        /// </summary>
        /// <param name="length"="length">Line number</param>
        /// <param name="column">Column number</param>
        /// <param name="min">Minimum value</param>
        /// <param name="max">Maximum value</param>
        /// <returns>( int[,] ) Matrix X</returns>
        public static int[] Create(int length = 3, int min = 1, int max = 9)
        {
            int[] X = new int[length];
            for (int i = 0; i < length; i++)
                X[i] = new Random().Next(min, max);

            return X;
        }

        /// <summary>
        /// Creates a symmetrical matrix with random numbers in given range
        /// </summary>
        /// <param name="size">Column and line count</param>
        /// <param name="min">Minimum random value</param>
        /// <param name="max">Maximum random value</param>
        /// <returns>( int[,] ) Symmetrical matrix</returns>
        public static int[,] SymmetricalMatrix(int size, int min, int max)
        {
            int[,] X = new int[size, size];
            for (int i = 0; i < size; i++)
                for (int j = 0; j < size; j++)
                    if (i == j)
                    {
                        X[i, j] = new Random().Next(min, max + 1);
                        break;
                    }

            for (int i = 1; i < size; i++)
                for (int j = 0; j <= i - 1; j++)
                {
                    X[i, j] = new Random().Next(min, max);
                    X[j, i] = X[i, j];
                }

            return X;
        }

        /// <summary>
        /// Creates a matrix that all the numbers inside is zero
        /// </summary>
        /// <param name="line">Matrix line count</param>
        /// <param name="sutun">Matrix column count</param>
        /// <returns>( int[,] )Zero filled Matrix</returns>
        public static int[,] CloneNumbersMatrix(int line, int column) => new int[line, column];

        /// <summary>
        /// Creates a matrix that all the numbers inside is choosen number
        /// </summary>
        /// <param name="line">Matrix line number</param>
        /// <param name="column">Matrix column number</param>
        /// <param name="clone">Number that will fill inside</param>
        /// <returns>( int[,] )Clone filled matrix</returns>
        public static int[,] CloneNumbersMatrix(int line, int column, int clone)
        {
            int[,] matrix = new int[line, column];
            for (int i = 0; i < line; i++)
                for (int j = 0; j < column; j++)
                    matrix[i, j] = clone;

            return new int[1, 1];
        }

        /// <summary>
        /// Creates a square matrix and fill the diagonal with the given number
        /// </summary>
        /// <param name="size">Line and Coolumn number</param>
        /// <param name="number">Number that will fill the diagonal</param>
        /// <returns>( int[,] ) matrix with "number" filled diagonal</returns>
        public static int[,] DiagonalMatrix(int size, int number)
        {
            int[,] diagonal = new int[size, size];
            for (int i = 0; i < size; i++)
                    diagonal[i, i] = number;
                    
            return diagonal;
        }

        /// <summary>
        /// Creates a square matrix and fill the diagonal with the random numbers in the range of given minimum and maximum numbers
        /// </summary>
        /// <param name="size">Line and Coolumn number</param>
        /// <param name="minimum">Random number minimum value that will fill the diagonal</param>
        /// <param name="maximum">Random number minimum value that will fill the diagonal</param>
        /// <returns>( int[,] ) Matrix whose diagonal is filled with random numbers </returns>
        public static int[,] DiagonalMatrix(int size, int minimum, int maximum)
        {
            int[,] diagonal = new int[size, size];
            for (int i = 0; i < size; i++)
                diagonal[i, i] = new Random().Next(minimum, maximum);

            return diagonal;
        }

        /// <summary>
        /// Fills the diagonal and top of the the square matrix, fills the remain elements by zero
        /// </summary>
        /// <param name="size">Line and column</param>
        /// <param name="min">Minimum value that will fill</param>
        /// <param name="max">Maximum value that will fill</param>
        /// <returns>( int[,] ) Top Traiangle Matrix</returns>
        public static int[,] TopTriangle(int size, int min, int max)
        {
            int[,] X = new int[size, size];
            for (int i = 0; i < size; i++)
                for (int j = i; j < size; j++)
                    X[i, j] = new Random().Next(min, max + 1);

            return X;
        }

        /// <summary>
        /// Fills the diagonal and bottom of the square matrix, fills the remain elements by zero
        /// </summary>
        /// <param name="size">Line and column</param>
        /// <param name="min">Minimum value that will fill</param>
        /// <param name="max">Maximum value that will fill</param>
        /// <returns>( int[,] ) Bottom Traiangle Matrix</returns>
        public static int[,] BottomTriangle(int size, int min, int max)
        {
            int[,] X = new int[size, size];
            for (int i = 0; i < size; i++)
                for (int j = 0; j <= i; j++)
                    X[i, j] = new Random().Next(min, max + 1);

            return X;
        }

        /// <summary>
        /// Makes a new matrix with elements of the given matrix
        /// </summary>
        /// <param name="twoDMatrix">The matrix</param>
        /// <param name="newLineCount">New line count</param>
        /// <param name="newColumnCount">New column count</param>
        /// <returns>( int[,] ) New matrix with same lenght with X</returns>
        public static int[,] Reshaper(int[,] twoDMatrix, int newLineCount, int newColumnCount)
        {
            if (twoDMatrix.Length == newLineCount * newColumnCount)
            {
                int[] elements = new int[twoDMatrix.Length];
                int counter = 0;
                for (int i = 0; i < twoDMatrix.GetLength(0); i++)
                    for (int j = 0; j < twoDMatrix.GetLength(1); j++)
                    {
                        elements[counter] = twoDMatrix[i, j];
                        counter++;
                    }

                counter = 0;
                int[,] reShaped = new int[newLineCount, newColumnCount];
                for (int i = 0; i < newLineCount; i++)
                    for (int j = 0; j < newColumnCount; j++)
                    {
                        reShaped[i, j] = elements[counter];
                        counter++;
                    }

                return reShaped;
            }
            else
            {
                Console.Write("Out of the range");
                return new int[1, 1];
            }
        }

        /// <summary>
        /// Multiply each number in the matrix with given number
        /// </summary>
        /// <param name="twoDMatrix">The matrix</param>
        /// <param name="multiplier">Number</param>
        /// <returns>( int[,] ) Multplied Matrix</returns>
        public static int[,] MatrixMultiplying(int[,] twoDMatrix, int multiplier)
        {
            for (int j = 0; j < twoDMatrix.GetLength(0); j++)
                for (int i = 0; i < twoDMatrix.GetLength(1); i++)
                    twoDMatrix[j, i] *= multiplier;

            return twoDMatrix;
        }

        /// <summary>
        /// Multiply each number in the matrix with given number
        /// </summary>
        /// <param name="oneDMatrix">The matrix</param>
        /// <param name="multiplier">Number</param>
        /// <returns>( int[,] ) Multplied Matrix</returns>
        public static int[] MatrixMultiplying(int[] oneDMatrix, int multiplier)
        {
            for (int j = 0; j < oneDMatrix.GetLength(0); j++)
                oneDMatrix[j] *= multiplier;

            return oneDMatrix;
        }

        /// <summary>
        /// Turns the column to line and the the line to column of the matrix
        /// </summary>
        /// <param name="twoDMatrix">The matrix</param>
        /// <returns>( int[,] ) Transposed</returns>
        public static int[,] Transpose(int[,] twoDMatrix)
        {
            for (int i = 1; i < twoDMatrix.GetLength(0); i++)
                for (int j = 0; j <= i - 1; j++)
                {
                    int temporary = twoDMatrix[i, j];
                    twoDMatrix[i, j] = twoDMatrix[j, i];
                    twoDMatrix[j, i] = temporary;
                }
            return twoDMatrix;
        }
    }
}