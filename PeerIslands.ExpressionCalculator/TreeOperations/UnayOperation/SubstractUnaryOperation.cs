namespace PeerIslands.ExpressionCalculator.TreeOperations.UnayOperation
{
    public class SubstractUnaryOperation : UnaryOperation
    {
        public SubstractUnaryOperation(TreeOperation rightSide) : base(rightSide, (a) => -a) { }
    }
}