using System;

namespace PeerIslands.ExpressionCalculator.TreeOperations.BinaryOperation
{
    public abstract class BinaryOperation : ITreeOperation
    {
        private readonly ITreeOperation _leftSide;
        private readonly ITreeOperation _rightSide;
        private readonly Func<double, double, double> _operator;

        public BinaryOperation(ITreeOperation leftSide, ITreeOperation rightSide, Func<double, double, double> @operator)
        {
            _leftSide = leftSide;
            _rightSide = rightSide;
            _operator = @operator;
        }

        public double Calculate()
        {
            var leftSideValue = _leftSide.Calculate();
            var rightSideValue = _rightSide.Calculate();

            return _operator(leftSideValue, rightSideValue);
        }
    }
}