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
            var leftSide = GetMultiplyDevideCalc(symbols, index, out index);

            while (index < symbols.Count)
            {
                if (!(symbols[index] is OperatorSymbol currentSymbol) || currentSymbol.OperatorTypes == OperatorTypes.Multiply ||
                    currentSymbol.OperatorTypes == OperatorTypes.Divide)
                {
                    currentIndex = index;
                    return leftSide;
                }

                index += 1;

                TreeOperation rightSide = GetMultiplyDevideCalc(symbols, index, out index);

                switch (currentSymbol.OperatorTypes)
                {
                    case OperatorTypes.Sum:
                        leftSide = new SumBinaryOperation(leftSide, rightSide);
                        break;
                    case OperatorTypes.Subtract:
                        leftSide = new SubtractBinaryOperation(leftSide, rightSide);
                        break;
                }
            }
            currentIndex = index;
            return leftSide;
        }

        private TreeOperation GetMultiplyDevideCalc(IList<Symbol> symbols, int index, out int currentIndex)
        {
            var leftSide = GetUnaryOperation(symbols, index, out index);

            while (index < symbols.Count)
            {
                if (!(symbols[index] is OperatorSymbol currentSymbol) || 
                    currentSymbol.OperatorTypes == OperatorTypes.Sum ||
                    currentSymbol.OperatorTypes == OperatorTypes.Subtract)
                {
                    currentIndex = index;
                    return leftSide;
                }

                index += 1;

                var rightSide = GetUnaryOperation(symbols, index, out index);

                switch (currentSymbol.OperatorTypes)
                {
                    case OperatorTypes.Multiply:
                        leftSide = new MultiplyBinaryOperation(leftSide, rightSide);
                        break;
                    case OperatorTypes.Divide:
                        leftSide = new DivideBinaryOperation(leftSide, rightSide);
                        break;
                }
            }
            currentIndex = index;
            return leftSide;
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
                            var rightSide = GetUnaryOperation(symbols, index, out index);
                            currentIndex = index;
                            return new SubstractUnaryOperation(rightSide);
                    }
                }
                var unarySymbol = GetSymbol(symbols, index, out index);
                currentIndex = index;
                return unarySymbol;
            }
            throw new FormatException("Fail trying to do an Operation with this symbols");
        }

        private TreeOperation GetSymbol(IList<Symbol> symbols, int index, out int currentIndex)
        {
            if (symbols[index] is NumberSymbol)
            {
                var currentSymbol = symbols[index] as NumberSymbol;
                var operation = new NumberOperation(currentSymbol.Number);

                currentIndex = index + 1;

                return operation;
            }

            if (symbols[index] is SpecialSymbol)
            {
                var currentSymbol = symbols[index] as SpecialSymbol;

                if (currentSymbol.SpecialSymbolType == SpecialSymbolsTypes.OpenParentheses)
                {
                    index += 1;

                    var sumWithSubtractCalc = GetSumSubtractCalc(symbols, index, out index);

                    currentIndex = index + 1;

                    return sumWithSubtractCalc;
                }
            }

            throw new FormatException($"Unexpected symbol: {symbols[index]}");
        }
    }
}