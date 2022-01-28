using System;
using TicTacToe.Common;
using TicTacToe.PlayField.Logic;

namespace TicTacToe.Game
{
    public class Bot : IMovable
    {
        private const int VictoryRating = 10;
        private const int DrawRating = 0;

        private Symbol _playerSymbol;
        private Symbol _opponentSymbol;
        
        public int GetMove(IIndexable<Symbol> cellField, Symbol symbol)
        {
            IIndexable<Symbol> tempCellField = cellField.Copy();

            _playerSymbol = symbol;
            _opponentSymbol = symbol.GetOpponentSymbol();

            int bestValue = int.MinValue;
            int move = -1;
            for (int i = 0; i < tempCellField.Length; i++)
            {
                if (tempCellField[i] != Symbol.Empty)
                {
                    continue;
                }

                tempCellField[i] = symbol;
                int moveValue = Minimax(tempCellField, false, 0, int.MinValue, int.MaxValue);
                tempCellField[i] = Symbol.Empty;
                
                if (moveValue > bestValue)
                {
                    bestValue = moveValue;
                    move = i;
                }
            }

            return move;
        }
        private int Minimax(IIndexable<Symbol> cellField, bool isMax, int depth, int alpha, int beta)
        {
            if (CellFieldAnalyzer.IsVictory(cellField, _playerSymbol))
            {
                return VictoryRating - depth;
            }
            if (CellFieldAnalyzer.IsVictory(cellField, _opponentSymbol))
            {
                return depth - VictoryRating;
            }
            if (!CellFieldAnalyzer.AreEmptyCellsOnField(cellField))
            {
                return DrawRating;
            }

            return isMax 
                ? GetBestValueForMaximizer(cellField, depth, alpha, beta) 
                : GetBestValueForMinimizer(cellField, depth, alpha, beta);
        }
        private int GetBestValueForMaximizer(IIndexable<Symbol> cellField, int depth, int alpha, int beta)
        {
            int bestValue = int.MinValue;
            for (int i = 0; i < cellField.Length; i++)
            {
                if (cellField[i] != Symbol.Empty)
                {
                    continue;
                }

                cellField[i] = _playerSymbol;
                bestValue = Math.Max(bestValue, Minimax(cellField, false, depth + 1, alpha, beta));
                alpha = Math.Max(alpha, bestValue);
                cellField[i] = Symbol.Empty;

                if (beta <= alpha)
                {
                    break;
                }
            }

            return bestValue;
        }
        private int GetBestValueForMinimizer(IIndexable<Symbol> cellField, int depth, int alpha, int beta)
        {
            int bestValue = int.MaxValue;
            for (int i = 0; i < cellField.Length; i++)
            {
                if (cellField[i] != Symbol.Empty)
                {
                    continue;
                }

                cellField[i] = _opponentSymbol;
                bestValue = Math.Min(bestValue, Minimax(cellField, true, depth + 1, alpha, beta));
                beta = Math.Min(beta, bestValue);
                cellField[i] = Symbol.Empty;
                
                if (beta <= alpha)
                {
                    break;
                }
            }

            return bestValue;
        }
    }
}