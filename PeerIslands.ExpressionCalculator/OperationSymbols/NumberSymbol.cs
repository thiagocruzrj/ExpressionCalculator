namespace PeerIslands.ExpressionCalculator.OperationSymbols
{
    public class NumberSymbol : ISymbol
    {
        public SymbolType Type => SymbolType.Number;

        public double Number { get; }

        public NumberSymbol(double number)
        {
            Number = number;
        }
    }
}