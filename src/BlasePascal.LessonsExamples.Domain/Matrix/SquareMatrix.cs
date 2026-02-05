using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.LessonsExamples.Domain.Matrix
{
    public class SquareMatrix : Matrix
    {
        public SquareMatrix(int dimension) : base(dimension, dimension)
        { }

        public SquareMatrix(double[] original) : base((int)Math.Sqrt(original.Length), (int)Math.Sqrt(original.Length))
        {
            int end = vector.Length;
            for (int i = 0; i < end; i++)
                vector[i] = original[i];
        }

        public SquareMatrix() : this(3)
        { }

        public int Dimension => Rows;

        public double Determinant(SquareMatrix matrix)
        {
            // Restituisce il determinante della matrice.
            //
            // 'matrix': matrice quadrata, di dimensione almeno 2.
            //

            int dim = matrix.Dimension;   // Dimensione matrice di input.
            double result = 0;


            if (dim == 2)
            {
                result = matrix[0, 0] * matrix[1, 1] - matrix[0, 1] * matrix[1, 0];
            }
            else
            {
                int r = 0;   // Riga sulla quale si calcola il determinante.
                int k = 0;   // +1 o -1, coefficiente.

                for (int c = 0; c < dim; c++)
                {
                    // Calcolo del segno basato sulla posizione (r+c)
                    if ((r + c) % 2 == 0)
                        k = 1;
                    else
                        k = -1;

                    // Espansione di Laplace: elemento * segno * determinante del
                    // la sottomatrice
                    result += k * matrix[r, c] * Determinant(SubMatrix(matrix, r, c));
                }
            }

            return result;
        }

        private SquareMatrix SubMatrix(SquareMatrix matrix, int row, int col)
        {
            SquareMatrix subMatrix = new SquareMatrix(matrix.Rows-1);
            
            int r = 0;
            int c = 0;
            for (int j = 0; j< matrix.Rows; j++)
            {
                if (row == j)
                    continue;

                c= 0;   

                for (int k = 0; k < matrix.Rows; k++)
                {
                    if (col == k)
                        continue;
                    
                    subMatrix[r, c] = matrix[j, k];
                    c++;
                }

                r++;
            }
            return subMatrix;
        }

        public double[] SolveSystemOfEquation(SquareMatrix matrix, double[] coeffArray) 
        { 

            int dim = matrix.Dimension;
            double detA = Determinant(matrix);

            if (Math.Abs(detA) < 1e-15)
                throw new Exception("The system has no determined solution");

            double[] solutions = new double[dim];

            for (int i = 0; i < dim; i++)
            {
                double detAi = Determinant(ChangeColumn(matrix, coeffArray, i));
                solutions[i] = detAi / detA;
            }
            return solutions;
        }

        public SquareMatrix ChangeColumn(SquareMatrix matrix, double[] newColumn, int colIndex)
        {
            SquareMatrix newMatrix = new SquareMatrix(matrix.Dimension);
            for (int r = 0; r < matrix.Dimension; r++)
            {
                for (int c = 0; c < matrix.Dimension; c++)
                {
                    if (c == colIndex)
                        newMatrix[r, c] = newColumn[r];
                    else
                        newMatrix[r, c] = matrix[r, c];
                }
            }
            return newMatrix;
        }


    }

}
