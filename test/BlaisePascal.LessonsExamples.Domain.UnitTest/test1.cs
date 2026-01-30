using BlaisePascal.LessonsExamples.Domain.Matrix;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.LessonsExamples.Domain.UnitTest
{
    public class Test1
    {
        [Fact]
        public void Determinant_3x3_ReturnsCorrectValue()
        {
            SquareMatrix m = new SquareMatrix(3);
            m[0, 0] = 1; m[0, 1] = 2; m[0, 2] = 3;
            m[1, 0] = 0; m[1, 1] = 4; m[1, 2] = 5;
            m[2, 0] = 1; m[2, 1] = 0; m[2, 2] = 6;

            double det = m.Determinant(m);

            Assert.Equal(22, det);
        }

        [Fact]
        public void SolveSystem_2x2_Test()
        {

            SquareMatrix m = new SquareMatrix(3);
            m[0, 0] = 2; m[0, 1] = 1; 
            m[1, 0] = 1; m[1, 1] = -1;

            double[] coeffs = { 5, 1 };

            double[] result = m.SolveSystemOfEquation(m, coeffs);

            Assert.Equal(2.0, result[0], 1e-9);
            Assert.Equal(1.0, result[1], 1e-9);
        }
    }
}
