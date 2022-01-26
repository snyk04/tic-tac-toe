using TicTacToe.Common;
using TicTacToe.PlayField.Logic;

namespace TicTacToe.Game
{
    public interface IMovable
    {
        int GetMove(IIndexable<Symbol> cellField, Symbol symbol);
    }
}