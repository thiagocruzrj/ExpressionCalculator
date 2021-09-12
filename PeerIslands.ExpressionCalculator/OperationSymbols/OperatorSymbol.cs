namespace PeerIslands.ExpressionCalculator.OperationSymbols
{
    public class OperatorSymbol : Symbol
    {
        public override SymbolType Type => SymbolType.Operator;

        public OperatorTypes OperatorTypes { get; }

        public OperatorSymbol(OperatorTypes operatorTypes)
        {
            OperatorTypes = operatorTypes;
        }
    }
}