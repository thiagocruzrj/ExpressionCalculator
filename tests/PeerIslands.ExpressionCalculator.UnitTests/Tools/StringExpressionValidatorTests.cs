using PeerIslands.ExpressionCalculator.OperationSymbols;
using PeerIslands.ExpressionCalculator.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace ConsoleExpressionCalculator.Tests
{
    public class StringExpressionValidatorTests
    {
        [Theory(DisplayName = "Validating null or empty expression throw exception")]
        [InlineData("")]
        [InlineData(null)]
        [Trait("Calculator", "ToolsTests")]
        public void Calculator_UsingStringValidatorWithNullOrEmptyExpression_ShouldThrowFormatException(string expression)
        {
            Assert.Throws<FormatException>(() => StringExpressionValidator.ValidateExpression(expression));
        }

        [Fact(DisplayName = "Validating parentheses in expression throw exception")]
        [Trait("Calculator", "ToolsTests")]
        public void Calculator_UsingStringValidatorWithWrongParentheses_ShouldThrowFormatException()
        {
            var expression = "89 - 98 * (415 - 2) + (32 / 2 +";
            Assert.Throws<FormatException>(() => StringExpressionValidator.ValidateExpression(expression));
        }

        [Fact(DisplayName = "Validating parentheses with wrong order in expression throw exception")]
        [Trait("Calculator", "ToolsTests")]
        public void Calculator_UsingStringValidatorWithWrongOrderParentheses_ShouldThrowFormatException()
        {
            var expression = "89 - 98 * )415 - 2(";
            Assert.Throws<FormatException>(() => StringExpressionValidator.ValidateExpression(expression));
        }
    }
}