namespace PeerIslands.ExpressionCalculator.TreeOperations.BinaryOperation
{
    public class SubtractBinaryOperation : BinaryOperation
    {
        public SubtractBinaryOperation(TreeOperation leftSide, TreeOperation rightSide) : base(leftSide, rightSide, (a, b) => a - b) { }
    }
}