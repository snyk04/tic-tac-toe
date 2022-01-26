using System;
using TicTacToe.Common;
using TicTacToe.PlayField.Logic;

namespace TicTacToe.Game
{
    public interface IGameHandler
    {
        IControllable CurrentControllablePlayer { get; }
        event Action<GameEndType> OnGameEnd;
        void HandleGame(IMovable firstPlayer, IMovable secondPlayer, IIndexable<Symbol> cellField);
    }
}