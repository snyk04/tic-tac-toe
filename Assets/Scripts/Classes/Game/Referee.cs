using System;
using System.Linq;
using System.Threading;
using TicTacToe.Common;
using TicTacToe.PlayField.Logic;

namespace TicTacToe.Game
{
    public class Referee : IGameHandler, IDisposable
    {
        private const int TurnDelay = 20;
        
        public IControllable CurrentControllablePlayer { get; private set; }
        public event Action<GameEndType> OnGameEnd;
        
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
            Thread.Sleep(TurnDelay);
            int playerMove = 0;
            if (player.GetType().GetInterfaces().ToList().Contains(typeof(IControllable)))
            {
                CurrentControllablePlayer = (IControllable) player;
            }
            
            _currentPlayerMoveThread = new Thread(() => playerMove = player.GetMove(_cellField, symbol));
            _currentPlayerMoveThread.Start();
            _currentPlayerMoveThread.Join();
            
            UnityMainThreadDispatcher.Instance().Enqueue(() => _cellField[playerMove] = symbol);
            Thread.Sleep(TurnDelay);
            
            if (CellFieldAnalyzer.CheckVictory(_cellField, symbol))
            {
                GameEndType gameEndType = symbol switch
                {
                    Symbol.X => GameEndType.XVictory,
                    Symbol.O => GameEndType.OVictory,
                    _ => throw new ArgumentOutOfRangeException()
                };
                UnityMainThreadDispatcher.Instance().Enqueue(() => OnGameEnd?.Invoke(gameEndType));
            }
            if (CellFieldAnalyzer.NoMovesLeft(_cellField))
            {
                UnityMainThreadDispatcher.Instance().Enqueue(() => OnGameEnd?.Invoke(GameEndType.Draw));
            }
        }
    }
}