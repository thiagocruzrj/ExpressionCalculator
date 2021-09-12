using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using PeerIslands.ExpressionCalculator.OperationSymbols;

namespace PeerIslands.ExpressionCalculator.Tools
{
    public class StringExpressionParser : IParser
    {
        public IList<Symbol> Parse(string expression) => ResolveChars(expression.Replace(" ", ""));

        private IList<Symbol> ResolveChars(string expression)
        {
            var symbols = new List<Symbol>();

            for (int index = 0; index < expression.Length; index++)
            {
                if (char.IsDigit(expression[index]) || expression[index] == '.')
                {
                    var number = GetNumber(expression, index, out index);

                    symbols.Add(new NumberSymbol(number));
                    continue;
                }

                switch (expression[index])
                {
                    case '+':
                        symbols.Add(new OperatorSymbol(OperatorTypes.Sum));
                        break;
                    case '-':
                        symbols.Add(new OperatorSymbol(OperatorTypes.Subtract));
                        break;
                    case '*':
                        symbols.Add(new OperatorSymbol(OperatorTypes.Multiply));
                        break;
                    case '/':
                        symbols.Add(new OperatorSymbol(OperatorTypes.Divide));
                        break;
                    case '(':
                        symbols.Add(new SpecialSymbol(SpecialSymbolsTypes.OpenParentheses));
                        break;
                    case ')':
                        symbols.Add(new SpecialSymbol(SpecialSymbolsTypes.CloseParentheses));
                        break;
                    default:
                        throw new FormatException($"Unexpect symbol {expression[index]}");
                };
            }
            return symbols;
        }

        private double GetNumber(string expression, int index, out int currentIndex)
        {
            var stringNumber = new StringBuilder();
            bool isDouble = false;

            while (index < expression.Length)
            {
                if (char.IsDigit(expression[index]) || !isDouble && expression[index] == '.')
                {
                    stringNumber.Append(expression[index]);
                    isDouble = expression[index] == '.';
                    index += 1;
                    continue;
                }
                break;
            }

            currentIndex = index - 1;

            var number = double.Parse(stringNumber.ToString(), CultureInfo.InvariantCulture);

            return number;
        }
    }
}