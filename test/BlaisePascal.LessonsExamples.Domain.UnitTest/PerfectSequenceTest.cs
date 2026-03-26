using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.LessonsExamples.Domain.UnitTest
{
    using Xunit;
    using BlaisePascal.LessonsExamples.Domain.PerfectSequence;

    public class PerfectSequenceTests
    {
        [Fact]
        public void IsPerfect_ShouldReturnTrue_ForValidSequence()
        {
            int[] validSequence = {
            1, 9, 1, 2, 1, 8, 2, 4, 6,
            2, 7, 9, 4, 5, 8, 6, 3, 4,
            7, 5, 3, 9, 6, 8, 3, 5, 7
        };

            var sequence = new PerfectSequence(validSequence);

            bool result = sequence.isPerfect();

            Assert.True(result);
        }

        [Fact]
        public void IsPerfect_ShouldReturnFalse_WhenLengthIsWrong()
        {
            int[] invalidSequence = { 1, 1, 1 };

            var sequence = new PerfectSequence(invalidSequence);

            bool result = sequence.isPerfect();

            Assert.False(result);
        }

        [Fact]
        public void IsPerfect_ShouldReturnFalse_WhenOccurrencesAreWrong()
        {
            int[] invalidSequence = new int[27];

            for (int i = 0; i < 27; i++)
                invalidSequence[i] = 1; // solo 1 ripetuti

            var sequence = new PerfectSequence(invalidSequence);

            bool result = sequence.isPerfect();

            Assert.False(result);
        }

        [Fact]
        public void IsPerfect_ShouldReturnFalse_WhenDistanceRuleIsViolated()
        {
            int[] invalidSequence = {
            1,1,1,2,2,2,3,3,3,
            4,4,4,5,5,5,6,6,6,
            7,7,7,8,8,8,9,9,9
        };

            var sequence = new PerfectSequence(invalidSequence);

            bool result = sequence.isPerfect();

            Assert.False(result);
        }
    }

}
