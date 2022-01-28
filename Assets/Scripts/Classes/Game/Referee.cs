using System;
using System.Threading;
using TicTacToe.Common;
using TicTacToe.PlayField.Logic;

namespace TicTacToe.Game
{
    public class Referee : IGameHandler, IDisposable
    {
        public IControllable CurrentControllablePlayer { get; private set; }
        public event Action<GameEndType> OnGameEnd;
        
        private IMovable _firstPlayer;
        private IMovable _secondPlayer;
        private IIndexable<Symbol> _cellField;

        private Thread _gameLoopThread;
        
        
        public void Dispose()
        {
            _gameLoopThread.Abort();
        }
        
        public void HandleGame(IMovable firstPlayer, IMovable secondPlayer, IIndexable<Symbol> cellField)
        {
            _firstPlayer = firstPlayer;
            _secondPlayer = secondPlayer;
            _cellField = cellField;

            _gameLoopThread = new Thread(GameLoop);
            _gameLoopThread.Start();
            OnGameEnd += _ => _gameLoopThread.Abort();
        }

        private void GameLoop()
        {
            while (true)
            {
                HandlePlayerMove(_firstPlayer, Symbol.X);
                HandlePlayerMove(_secondPlayer, Symbol.O);
            }
        }
        private void HandlePlayerMove(IMovable player, Symbol symbol)
        {
            if (player is IControllable controllablePlayer)
            {
                CurrentControllablePlayer = controllablePlayer;
            }

            int playerMove = player.GetMove(_cellField, symbol);

            _cellField[playerMove] = symbol;
            
            if (CellFieldAnalyzer.IsVictory(_cellField, symbol))
            {
                GameEndType gameEndType = symbol switch
                {
                    Symbol.X => GameEndType.XVictory,
                    Symbol.O => GameEndType.OVictory,
                    _ => throw new ArgumentOutOfRangeException()
                };
                OnGameEnd?.Invoke(gameEndType);
            }
            if (!CellFieldAnalyzer.AreEmptyCellsOnField(_cellField))
            {
                OnGameEnd?.Invoke(GameEndType.Draw);
            }
        }
    }
}