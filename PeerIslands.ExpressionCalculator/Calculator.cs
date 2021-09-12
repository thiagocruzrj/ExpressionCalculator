using PeerIslands.ExpressionCalculator.Tools;
using PeerIslands.ExpressionCalculator.TreeOperations;

namespace PeerIslands.ExpressionCalculator
{
    public class Calculator
    {
        private readonly ITreeOperationBuilder _buider;
        private readonly IParser _parser;

        public Calculator()
        {
            _parser = new StringExpressionParser();
            _buider = new TreeOperationBuilder();
        }

        public double Calculate(string expression)
        {
            var symbols = _parser.Parse(expression);
            var tree = _buider.CreateTreeOperation(symbols);

            return tree.Calculate();
        }
    }
}