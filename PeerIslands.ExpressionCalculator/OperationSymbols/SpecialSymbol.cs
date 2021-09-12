namespace PeerIslands.ExpressionCalculator.OperationSymbols
{
    public class SpecialSymbol : Symbol
    {
        public override SymbolType Type => SymbolType.Parentheses;

        public SpecialSymbolsTypes SpecialSymbolType { get; }

        public SpecialSymbol(SpecialSymbolsTypes type)
        {
            SpecialSymbolType = type;
        }
    }
}