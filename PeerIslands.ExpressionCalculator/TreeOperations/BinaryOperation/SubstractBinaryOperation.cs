namespace PeerIslands.ExpressionCalculator.TreeOperations.BinaryOperation
{
    public class SubstractBinaryOperation : BinaryOperation
    {
        public SubstractBinaryOperation(TreeOperation leftSide, TreeOperation rightSide) : base(leftSide, rightSide, (a, b) => a - b) { }
    }
}