using System;

namespace PeerIslands.ExpressionCalculator.TreeOperations.BinaryOperation
{
    public abstract class BinaryOperation : TreeOperation
    {
        private readonly TreeOperation _leftSide;
        private readonly TreeOperation _rightSide;
        private readonly Func<double, double, double> _operator;

        public BinaryOperation(TreeOperation leftSide, TreeOperation rightSide, Func<double, double, double> @operator)
        {
            _leftSide = leftSide;
            _rightSide = rightSide;
            _operator = @operator;
        }

        public override double Calculate() => _operator(_leftSide.Calculate(), _rightSide.Calculate());
    }
}