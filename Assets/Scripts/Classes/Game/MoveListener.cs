namespace TicTacToe.Game
{
    public class MoveListener
    {
        private readonly IGameHandler _gameHandler;
        
        
        public MoveListener(IGameHandler gameHandler)
        {
            _gameHandler = gameHandler;
        }

        
        public void MakeMove(int cellIndex)
        {
            _gameHandler.CurrentControllablePlayer.SetMove(cellIndex);
        }
    }
}