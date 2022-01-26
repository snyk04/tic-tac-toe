using System;
using TicTacToe.Common;
using TicTacToe.PlayField.Logic;

namespace TicTacToe.Game
{
    public class Bot : IMovable
    {
        private Symbol _playerSymbol;
        private Symbol _opponentSymbol;
        
        public int GetMove(IIndexable<Symbol> cellField, Symbol symbol)
        {
            IIndexable<Symbol> tempCellField = cellField.Copy();

            _playerSymbol = symbol;
            _opponentSymbol = symbol switch
            {
                Symbol.X => Symbol.O,
                Symbol.O => Symbol.X,
                _ => throw new ArgumentException()
            };
            
            int bestValue = -100;
            int move = -1;

            for (int i = 0; i < tempCellField.Length; i++)
            {
                if (tempCellField[i] != Symbol.Empty)
                {
                    continue;
                }

                tempCellField[i] = symbol;

                int moveValue = MiniMax(tempCellField, false, 0);

                tempCellField[i] = Symbol.Empty;
                
                if (moveValue > bestValue)
                {
                    bestValue = moveValue;
                    move = i;
                }
            }
            
            return move;
        }
        
        private int MiniMax(IIndexable<Symbol> cellField, bool isMax, int depth)
        {
            if (CellFieldAnalyzer.CheckVictory(cellField, _playerSymbol))
            {
                return 10 - depth;
            }
            if (CellFieldAnalyzer.CheckVictory(cellField, _opponentSymbol))
            {
                return depth - 10;
            }
            if (CellFieldAnalyzer.NoMovesLeft(cellField))
            {
                return 0;
            }

            int bestValue;
            if (isMax)
            {
                bestValue = -100;
                for (int i = 0; i < cellField.Length; i++)
                {
                    if (cellField[i] != Symbol.Empty)
                    {
                        continue;
                    }
                    
                    cellField[i] = _playerSymbol;
                    bestValue = Math.Max(bestValue, MiniMax(cellField, false, depth + 1));
                    cellField[i] = Symbol.Empty;
                }
            }
            else
            {
                bestValue = 100;
                for (int i = 0; i < cellField.Length; i++)
                {
                    if (cellField[i] != Symbol.Empty)
                    {
                        continue;
                    }

                    cellField[i] = _opponentSymbol;
                    bestValue = Math.Min(bestValue, MiniMax(cellField, true, depth + 1));
                    cellField[i] = Symbol.Empty;
                }
            }
            
            return bestValue;
        }
    }
}