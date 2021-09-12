namespace PeerIslands.ExpressionCalculator.TreeOperations.BinaryOperation
{
    public class SubstractBinaryOperation : BinaryOperation
    {
        public SubstractBinaryOperation(ITreeOperation leftSide, ITreeOperation rightSide) : base(leftSide, rightSide, (a, b) => a - b) { }
    }
}