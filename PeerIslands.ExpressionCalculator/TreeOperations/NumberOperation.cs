namespace PeerIslands.ExpressionCalculator.TreeOperations
{
    public class NumberOperation : TreeOperation
    {
        private readonly double _number;

        public NumberOperation(double number)
        {
            _number = number;
        }

        public override double Calculate() => _number;
    }
}
