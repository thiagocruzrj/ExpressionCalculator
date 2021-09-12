namespace PeerIslands.ExpressionCalculator.TreeOperations.BinaryOperation
{
    public class DivideBinaryOperation : BinaryOperation
    {
        public DivideBinaryOperation(TreeOperation leftSide, TreeOperation rightSide) : base(leftSide, rightSide, (a, b) => a / b) { }
    }
}