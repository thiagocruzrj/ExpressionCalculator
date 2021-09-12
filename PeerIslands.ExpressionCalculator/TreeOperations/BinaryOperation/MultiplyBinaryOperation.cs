namespace PeerIslands.ExpressionCalculator.TreeOperations.BinaryOperation
{
    public class MultiplyBinaryOperation : BinaryOperation
    {
        public MultiplyBinaryOperation(ITreeOperation leftSide, ITreeOperation rightSide) : base(leftSide, rightSide, (a, b) => a * b) { }
    }
}