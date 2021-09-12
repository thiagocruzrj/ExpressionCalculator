using System;
using System.Linq;

namespace PeerIslands.ExpressionCalculator.Tools
{
    public class StringExpressionVerifier
    {
        public static void VerifyExpression(string expression)
        {
            if (string.IsNullOrWhiteSpace(expression))
                throw new FormatException("Empty Expression, try again !");

            var openParenthesesCount = expression.Count(c => c == '(');
            var closeParenthesessCount = expression.Count(c => c == ')');

            if (openParenthesesCount != closeParenthesessCount)
                throw new FormatException("Wrong number of parentheses in the expression!");

            var bracketsOrder = expression
                .Where(c => c == '(' || c == ')')
                .Aggregate("", (current, next) => current + next);

            while (bracketsOrder.Contains("(" + ")"))
                bracketsOrder = bracketsOrder.Replace("(" + ")", "");

            if (!string.IsNullOrEmpty(bracketsOrder))
                throw new FormatException("Wrong order of parentheses in the expression!");
        }
    }
}