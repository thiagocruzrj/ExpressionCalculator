namespace PeerIslands.ExpressionCalculator.TreeOperations.BinaryOperation
{
    public class SumBinaryOperation : BinaryOperation
    {
        public SumBinaryOperation(ITreeOperation leftSide, ITreeOperation rightSide) : base(leftSide, rightSide, (a, b) => a + b) { }
    }
}