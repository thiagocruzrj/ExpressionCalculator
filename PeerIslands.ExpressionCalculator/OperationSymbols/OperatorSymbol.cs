namespace PeerIslands.ExpressionCalculator.OperationSymbols
{
    public class OperatorSymbol : ISymbol
    {
        public SymbolType Type => SymbolType.Operator;

        public OperatorTypes OperatorTypes { get; }

        public OperatorSymbol(OperatorTypes operatorTypes)
        {
            OperatorTypes = operatorTypes;
        }
    }
}