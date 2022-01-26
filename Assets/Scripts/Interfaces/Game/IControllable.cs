namespace TicTacToe.Game
{
    public interface IControllable : IMovable
    {
        void SetMove(int cellIndex);
    }
}