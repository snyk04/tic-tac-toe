using TicTacToe.Common;
using TicTacToe.PlayField.Logic;

namespace TicTacToe.Game
{
    public class GameManager : IGameStarter
    {
        private readonly IGameHandler _referee;
        private readonly IIndexable<Symbol> _cellField;
        
        
        public GameManager(IGameHandler referee, IIndexable<Symbol> cellField)
        {
            _referee = referee;
            _cellField = cellField;
        }


        public void StartGame(PlayerType firstPlayerType, PlayerType secondPlayerType)
        {
            IMovable firstPlayer = PlayerCreator.CreatePlayer(firstPlayerType);
            IMovable secondPlayer = PlayerCreator.CreatePlayer(secondPlayerType);

            _referee.HandleGame(firstPlayer, secondPlayer, _cellField);
        }
    }
}