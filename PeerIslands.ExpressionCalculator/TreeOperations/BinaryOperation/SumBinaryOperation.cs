namespace PeerIslands.ExpressionCalculator.TreeOperations.BinaryOperation
{
    public class SumBinaryOperation : BinaryOperation
    {
        public SumBinaryOperation(TreeOperation leftSide, TreeOperation rightSide) : base(leftSide, rightSide, (a, b) => a + b) { }
    }
}