using PeerIslands.ExpressionCalculator.OperationSymbols;
using System.Collections.Generic;

namespace PeerIslands.ExpressionCalculator.TreeOperations
{
    public interface ITreeOperationBuilder
    {
        ITreeOperation CreateTreeOperation(IList<Symbol> symbols);
    }
}