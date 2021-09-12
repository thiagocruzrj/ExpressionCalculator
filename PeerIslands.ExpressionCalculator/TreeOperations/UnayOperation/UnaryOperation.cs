using System;

namespace PeerIslands.ExpressionCalculator.TreeOperations.UnayOperation
{
    public abstract class UnaryOperation : ITreeOperation
    {
        private readonly ITreeOperation _rightSide;
        private readonly Func<double, double> _operator;

        public UnaryOperation(ITreeOperation rightSide, Func<double, double> @operator)
        {
            _rightSide = rightSide;
            _operator = @operator;
        }

        public double Calculate()
        {
            var rightSideValue = _rightSide.Calculate();

            return _operator(rightSideValue);
        }
    }
}