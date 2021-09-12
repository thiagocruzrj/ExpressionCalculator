namespace PeerIslands.ExpressionCalculator.OperationSymbols
{
    public class SpecialSymbol : ISymbol
    {
        public SymbolType Type => SymbolType.Parentheses;

        public SpecialSymbolsTypes SpecialSymbolType { get; }

        public SpecialSymbol(SpecialSymbolsTypes type)
        {
            SpecialSymbolType = type;
        }
    }
}