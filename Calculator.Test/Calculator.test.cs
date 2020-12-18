using System;
using Xunit;

namespace Calculator.Test
{
    public class UnitTest1
    {
        [Fact]
        public void Evaluate_SimplestExpression_EvaluatesToThree()
        {
            Assert.Equal(3, Calculator.Solve("+ 1 2".Split(' ')));    
        }

        [Fact]
        public void Evaluate_ExpressionWithMoreThanTwoTerms_EvaluatesToFour()
        {
            Assert.Equal(4, Calculator.Solve("+ + 1 1 2".Split(' ')));
        }

        [Fact]
        public void Evaluate_UseAllOperationTypes_EvaluatesToFive()
        {
            Assert.Equal(5, Calculator.Solve("+ - / * 4 5 5 7 8".Split(' ')));
        }

        [Fact]
        public void Evaluate_TwoExpressions_EvaluatesToTen()
        {
            Assert.Equal(1549.4166259765625, Calculator.Solve("+ / * + 56 45 46 3 - 1 0.25".Split(" ")));
        }

        [Fact]
        public void Evaluate_MultipleExpressions_EvaluatesToSixteen()
        {
            Assert.Equal(16, Calculator.Solve("* + 1 3 * - + 5 3 4 - 3 2".Split(" ")));
        }
    }
}
