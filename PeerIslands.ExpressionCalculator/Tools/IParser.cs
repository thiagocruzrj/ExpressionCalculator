using PeerIslands.ExpressionCalculator.OperationSymbols;
using System.Collections.Generic;

namespace PeerIslands.ExpressionCalculator.Tools
{
    public interface IParser
    {
        IList<Symbol> Parse(string expression);
    }
}