namespace PeerIslands.ExpressionCalculator.TreeOperations.BinaryOperation
{
    public class MultiplyBinaryOperation : BinaryOperation
    {
        public MultiplyBinaryOperation(TreeOperation leftSide, TreeOperation rightSide) : base(leftSide, rightSide, (a, b) => a * b) { }
    }
}