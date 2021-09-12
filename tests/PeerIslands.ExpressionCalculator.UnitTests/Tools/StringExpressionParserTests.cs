using PeerIslands.ExpressionCalculator.OperationSymbols;
using PeerIslands.ExpressionCalculator.Tools;
using System.Collections.Generic;
using Xunit;

namespace ConsoleExpressionCalculator.Tests
{
    public class StringExpressionParserTests
    {
        private IParser _parser;

        public StringExpressionParserTests()
        {
            _parser = new StringExpressionParser();
        }

        [Fact(DisplayName = "Using parse with sucess")]
        [Trait("Calculator", "ToolsTests")]
        public void Calculator_UsingParse_ShouldReturnSuccess()
        {
            var expression = "- 35+85.5*(35/5)";

            IList<Symbol> expectedSymbols = new List<Symbol>()
            {
                new OperatorSymbol(OperatorTypes.Subtract),
                new NumberSymbol(35),
                new OperatorSymbol(OperatorTypes.Sum),
                new NumberSymbol(85.5),
                new OperatorSymbol(OperatorTypes.Multiply),
                new SpecialSymbol(SpecialSymbolsTypes.OpenParentheses),
                new NumberSymbol(35),
                new OperatorSymbol(OperatorTypes.Divide),
                new NumberSymbol(5),
                new SpecialSymbol(SpecialSymbolsTypes.CloseParentheses),
            };

            var result = _parser.Parse(expression);

            Assert.Equal(expectedSymbols.Count, result.Count);

            for(int i = 0; i < result.Count; i++)
            {
                Assert.True(expectedSymbols[i].Type == result[i].Type);

                if (expectedSymbols[i] is OperatorSymbol expectedOperationSymbol && result[i] is OperatorSymbol resultOperationSymbol)
                {
                    Assert.True(expectedOperationSymbol.OperatorTypes == resultOperationSymbol.OperatorTypes);
                }
                else if (expectedSymbols[i] is NumberSymbol expectedNumberSymbol && result[i] is NumberSymbol resultNumberSymbol)
                {
                    Assert.True(expectedNumberSymbol.Number == resultNumberSymbol.Number);
                }
                else if (expectedSymbols[i] is SpecialSymbol expectedSpecialSymbol && result[i] is SpecialSymbol resultSpecialSymbol)
                {
                    Assert.True(expectedSpecialSymbol.SpecialSymbolType == resultSpecialSymbol.SpecialSymbolType);
                }
            }
        }
    }
}