namespace PeerIslands.ExpressionCalculator.TreeOperations.UnayOperation
{
    public class SubstractUnaryOperation : UnaryOperation
    {
        public SubstractUnaryOperation(ITreeOperation rightSide) : base(rightSide, (a) => -a) { }
    }
}