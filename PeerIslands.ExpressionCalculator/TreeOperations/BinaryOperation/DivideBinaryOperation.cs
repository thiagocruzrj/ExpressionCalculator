namespace PeerIslands.ExpressionCalculator.TreeOperations.BinaryOperation
{
    public class DivideBinaryOperation : BinaryOperation
    {
        public DivideBinaryOperation(ITreeOperation leftSide, ITreeOperation rightSide) : base(leftSide, rightSide, (a, b) => a / b) { }
    }
}