using System;

namespace PeerIslands.ExpressionCalculator.TreeOperations.UnayOperation
{
    public abstract class UnaryOperation : TreeOperation
    {
        private readonly TreeOperation _rightSide;
        private readonly Func<double, double> _operator;

        public UnaryOperation(TreeOperation rightSide, Func<double, double> @operator)
        {
            _rightSide = rightSide;
            _operator = @operator;
        }

        public override double Calculate() => _operator(_rightSide.Calculate());
    }
}