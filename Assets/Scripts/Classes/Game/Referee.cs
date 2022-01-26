using System;
using System.Linq;
using System.Threading;
using TicTacToe.Common;
using TicTacToe.PlayField.Logic;

namespace TicTacToe.Game
{
    public class Referee : IGameHandler, IDisposable
    {
        public IControllable CurrentControllablePlayer { get; private set; }
        public event Action<Symbol> OnGameEnd;
        
        private IMovable _firstPlayer;
        private IMovable _secondPlayer;
        private IIndexable<Symbol> _cellField;

        private Thread _gameLoopThread;
        private Thread _currentPlayerMoveThread;
        
        
        public void Dispose()
        {
            _gameLoopThread.Abort();
            _currentPlayerMoveThread.Abort();
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
            int playerMove = 0;
            if (player.GetType().GetInterfaces().ToList().Contains(typeof(IControllable)))
            {
                CurrentControllablePlayer = (IControllable) player;
            }
            
            _currentPlayerMoveThread = new Thread(() => playerMove = player.GetMove(_cellField));
            _currentPlayerMoveThread.Start();
            _currentPlayerMoveThread.Join();
            
            UnityMainThreadDispatcher.Instance().Enqueue(() => _cellField[playerMove] = symbol);
            Thread.Sleep(100);
            if (CheckVictory(symbol))
            {
                UnityMainThreadDispatcher.Instance().Enqueue(() => OnGameEnd?.Invoke(symbol));
            }
        }

        private bool CheckVictory(Symbol symbol)
        {
            return (_cellField[0] == symbol && _cellField[1] == symbol && _cellField[2] == symbol)
                || (_cellField[3] == symbol && _cellField[4] == symbol && _cellField[5] == symbol)
                || (_cellField[6] == symbol && _cellField[7] == symbol && _cellField[8] == symbol)
                || (_cellField[0] == symbol && _cellField[3] == symbol && _cellField[6] == symbol)
                || (_cellField[1] == symbol && _cellField[4] == symbol && _cellField[7] == symbol)
                || (_cellField[2] == symbol && _cellField[5] == symbol && _cellField[8] == symbol)
                || (_cellField[0] == symbol && _cellField[4] == symbol && _cellField[8] == symbol)
                || (_cellField[6] == symbol && _cellField[4] == symbol && _cellField[5] == symbol);
        }
    }
}