using FluentAssertions;
using Moq;
using PeerIslands.ExpressionCalculator.OperationSymbols;
using PeerIslands.ExpressionCalculator.Tools;
using System;
using System.Collections.Generic;
using Xunit;

namespace PeerIslands.ExpressionCalculator.UnitTests.UseCase
{
    public class CalculatorTests
    {
        private Mock<IParser> _parser;
        private Calculator _calculator;

        public CalculatorTests()
        {
            _parser = new Mock<IParser>();
            _calculator = new Calculator();
        }

        [Fact(DisplayName = "Valid Sum Calculation")]
        [Trait("Calculator", "CalculatorTests")]
        public void Calculator_SumOperator_ResultShoudBeCorrect()
        {
            var expression = "10 + 31";

            _parser.Setup(i => i.Parse(expression)).Returns(new List<Symbol>
            {
                new NumberSymbol(10),
                new OperatorSymbol(OperatorTypes.Sum),
                new NumberSymbol(31),
            });

            var result = _calculator.Calculate(expression);

            result.Should().Equals(41);
        }

        [Fact(DisplayName = "Valid Subtract Calculation")]
        [Trait("Calculator", "CalculatorTests")]
        public void Calculator_SubtractOperator_ResultShoudBeCorrect()
        {
            var expression = "29 - 10";

            _parser.Setup(i => i.Parse(expression)).Returns(new List<Symbol>
            {
                new NumberSymbol(29),
                new OperatorSymbol(OperatorTypes.Subtract),
                new NumberSymbol(10),
            });

            var result = _calculator.Calculate(expression);

            result.Should().Be(19);
        }

        [Fact(DisplayName = "Valid Multiply Calculation")]
        [Trait("Calculator", "CalculatorTests")]
        public void Calculator_MultiplyOperator_ResultShoudBeCorrect()
        {
            var expression = "10 * 13";

            _parser.Setup(i => i.Parse(expression)).Returns(new List<Symbol>
            {
                new NumberSymbol(10),
                new OperatorSymbol(OperatorTypes.Multiply),
                new NumberSymbol(13),
            });

            var result = _calculator.Calculate(expression);

            result.Should().Be(130);
        }

        [Fact(DisplayName = "Valid Divide Calculation")]
        [Trait("Calculator", "CalculatorTests")]
        public void Calculator_DivideOperator_ResultShoudBeCorrect()
        {
            var expression = "63 / 2";

            _parser.Setup(i => i.Parse(expression)).Returns(new List<Symbol>
            {
                new NumberSymbol(63),
                new OperatorSymbol(OperatorTypes.Divide),
                new NumberSymbol(2),
            });

            var result = _calculator.Calculate(expression);

            result.Should().Be(31.5);
        }

        [Fact(DisplayName = "Valid Unary Subtract Calculation")]
        [Trait("Calculator", "CalculatorTests")]
        public void Calculator_UnarySubtract_ResultShoudBeCorrect()
        {
            var expression = "- 15.2 + 2";

            _parser.Setup(i => i.Parse(expression)).Returns(new List<Symbol>
            {
                new OperatorSymbol(OperatorTypes.Subtract),
                new NumberSymbol(15.2),
                new OperatorSymbol(OperatorTypes.Sum),
                new NumberSymbol(2),
            });

            var result = _calculator.Calculate(expression);

            result.Should().Be(-13.2);
        }

        [Fact(DisplayName = "Valid Priority Expression Calculation")]
        [Trait("Calculator", "CalculatorTests")]
        public void Calculator_ExpressionWithPriority_ResultShoudBeCorrect()
        {
            var expression = "8 + 2 * 2";

            _parser.Setup(i => i.Parse(expression)).Returns(new List<Symbol>
            {
                new NumberSymbol(8),
                new OperatorSymbol(OperatorTypes.Sum),
                new NumberSymbol(2),
                new OperatorSymbol(OperatorTypes.Multiply),
                new NumberSymbol(2),
            });

            var result = _calculator.Calculate(expression);

            result.Should().Be(12);
        }

        [Fact(DisplayName = "Valid Parentheses Expression Calculation")]
        [Trait("Calculator", "CalculatorTests")]
        public void Calculator_ParenthesesExperssion_ResultShoudBeCorrect()
        {
            var expression = "(2 - 0) * 2";

            _parser.Setup(i => i.Parse(expression)).Returns(new List<Symbol>
            {
                new SpecialSymbol(SpecialSymbolsTypes.OpenParentheses),
                new NumberSymbol(2),
                new OperatorSymbol(OperatorTypes.Sum),
                new NumberSymbol(2),
                new SpecialSymbol(SpecialSymbolsTypes.CloseParentheses),
                new OperatorSymbol(OperatorTypes.Multiply),
                new NumberSymbol(2),
            });

            var result = _calculator.Calculate(expression);

            result.Should().Be(4);
        }

        [Fact(DisplayName = "Throw Format Exception by Number of Parentheses")]
        [Trait("Calculator", "CalculatorTests")]
        public void Calculator_ParenthesesExpression_ShouldThrowFormatException()
        {
            var expression = "89-98*(415-2)+(32/2+";

            Assert.Throws<FormatException>(() => _calculator.Calculate(expression));
        }

        [Fact(DisplayName = "Throw Unexpected Symbol Exception by Number of Parentheses")]
        [Trait("Calculator", "CalculatorTests")]
        public void Calculator_UnexpectedSymbolS_ShouldThrowFormatException()
        {
            var expression = "85-89-y78";

            Assert.Throws<FormatException>(() => _calculator.Calculate(expression));
        }
    }
}
