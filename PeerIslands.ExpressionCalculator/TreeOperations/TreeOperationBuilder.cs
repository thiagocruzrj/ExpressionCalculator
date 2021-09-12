using PeerIslands.ExpressionCalculator.OperationSymbols;
using PeerIslands.ExpressionCalculator.TreeOperations.BinaryOperation;
using PeerIslands.ExpressionCalculator.TreeOperations.UnayOperation;
using System;
using System.Collections.Generic;

namespace PeerIslands.ExpressionCalculator.TreeOperations
{
    public class TreeOperationBuilder : ITreeOperationBuilder
    {
        public TreeOperation CreateTreeOperation(IList<Symbol> symbols) => GetSumSubtractCalc(symbols, 0, out _);

        private TreeOperation GetSumSubtractCalc(IList<Symbol> symbols, int index, out int currentIndex)
        {
            var leftSideNode = GetMultiplyDevideCalc(symbols, index, out index);

            while (index < symbols.Count)
            {
                if (!(symbols[index] is OperatorSymbol currentSymbol) || currentSymbol.OperatorTypes == OperatorTypes.Multiply ||
                    currentSymbol.OperatorTypes == OperatorTypes.Divide)
                {
                    currentIndex = index;
                    return leftSideNode;
                }

                index += 1;

                TreeOperation rightSideNode = GetMultiplyDevideCalc(symbols, index, out index);

                switch (currentSymbol.OperatorTypes)
                {
                    case OperatorTypes.Sum:
                        leftSideNode = new SumBinaryOperation(leftSideNode, rightSideNode);
                        break;
                    case OperatorTypes.Subtract:
                        leftSideNode = new SubtractBinaryOperation(leftSideNode, rightSideNode);
                        break;
                }
            }
            currentIndex = index;
            return leftSideNode;
        }

        private TreeOperation GetMultiplyDevideCalc(IList<Symbol> symbols, int index, out int currentIndex)
        {
            var leftSideNode = GetUnaryOperation(symbols, index, out index);

            while (index < symbols.Count)
            {
                if (!(symbols[index] is OperatorSymbol currentSymbol) || 
                    currentSymbol.OperatorTypes == OperatorTypes.Sum ||
                    currentSymbol.OperatorTypes == OperatorTypes.Subtract)
                {
                    currentIndex = index;
                    return leftSideNode;
                }

                index += 1;

                var rightSideNode = GetUnaryOperation(symbols, index, out index);

                switch (currentSymbol.OperatorTypes)
                {
                    case OperatorTypes.Multiply:
                        leftSideNode = new MultiplyBinaryOperation(leftSideNode, rightSideNode);
                        break;
                    case OperatorTypes.Divide:
                        leftSideNode = new DivideBinaryOperation(leftSideNode, rightSideNode);
                        break;
                }
            }
            currentIndex = index;
            return leftSideNode;
        }

        private TreeOperation GetUnaryOperation(IList<Symbol> symbols, int index, out int currentIndex)
        {
            while (index < symbols.Count)
            {
                if (symbols[index] is OperatorSymbol currentSymbol)
                {
                    switch (currentSymbol.OperatorTypes)
                    {
                        case OperatorTypes.Sum:
                            index += 1;
                            continue;
                        case OperatorTypes.Subtract:
                            index += 1;
                            var rightSideNode = GetUnaryOperation(symbols, index, out index);
                            currentIndex = index;
                            return new SubstractUnaryOperation(rightSideNode);
                    }
                }
                var nodeLeaf = GetSymbol(symbols, index, out index);
                currentIndex = index;
                return nodeLeaf;
            }
            throw new FormatException("GetUnaryOperation");
        }

        private TreeOperation GetSymbol(IList<Symbol> symbols, int index, out int currentIndex)
        {
            if (symbols[index] is NumberSymbol)
            {
                var currentSymbol = symbols[index] as NumberSymbol;
                var node = new NumberOperation(currentSymbol.Number);

                currentIndex = index + 1;

                return node;
            }

            if (symbols[index] is SpecialSymbol)
            {
                var currentSymbol = symbols[index] as SpecialSymbol;

                if (currentSymbol.SpecialSymbolType == SpecialSymbolsTypes.OpenParentheses)
                {
                    index += 1;

                    var node = GetSumSubtractCalc(symbols, index, out index);

                    currentIndex = index + 1;

                    return node;
                }
            }

            throw new FormatException($"Unexpected symbol: {symbols[index]}");
        }
    }
}