using System;
using System.Linq;

namespace PeerIslands.ExpressionCalculator.Tools
{
    public class StringExpressionValidator
    {
        public static void ValidateExpression(string expression)
        {
            if (string.IsNullOrWhiteSpace(expression))
                throw new FormatException("Empty Expression, try again !");

            var openParenthesesCount = expression.Count(c => c == '(');
            var closeParenthesessCount = expression.Count(c => c == ')');

            if (openParenthesesCount != closeParenthesessCount)
                throw new FormatException("Wrong number of parentheses in the expression!");

            var parenthesesOrder = expression
                .Where(c => c == '(' || c == ')')
                .Aggregate("", (current, next) => current + next);

            while (parenthesesOrder.Contains("(" + ")"))
                parenthesesOrder = parenthesesOrder.Replace("(" + ")", "");

            if (!string.IsNullOrEmpty(parenthesesOrder))
                throw new FormatException("Wrong order of parentheses in the expression!");
        }
    }
}