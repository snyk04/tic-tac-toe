using TicTacToe.Common;
using TicTacToe.PlayField.Logic;

namespace TicTacToe.Game
{
    public static class CellFieldAnalyzer
    {
        public static bool CheckVictory(IIndexable<Symbol> cellField, Symbol symbol)
        {
            return (cellField[0] == symbol && cellField[1] == symbol && cellField[2] == symbol)
                   || (cellField[3] == symbol && cellField[4] == symbol && cellField[5] == symbol)
                   || (cellField[6] == symbol && cellField[7] == symbol && cellField[8] == symbol)
                   || (cellField[0] == symbol && cellField[3] == symbol && cellField[6] == symbol)
                   || (cellField[1] == symbol && cellField[4] == symbol && cellField[7] == symbol)
                   || (cellField[2] == symbol && cellField[5] == symbol && cellField[8] == symbol)
                   || (cellField[0] == symbol && cellField[4] == symbol && cellField[8] == symbol)
                   || (cellField[2] == symbol && cellField[4] == symbol && cellField[6] == symbol);
        }
        public static bool NoMovesLeft(IIndexable<Symbol> cellField)
        {
            for (int i = 0; i < cellField.Length; i++)
            {
                if (cellField[i] == Symbol.Empty)
                {
                    return false;
                }
            }

            return true;
        }
    }
}