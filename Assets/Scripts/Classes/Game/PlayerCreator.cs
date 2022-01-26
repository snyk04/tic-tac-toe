using System;

namespace TicTacToe.Game
{
    public static class PlayerCreator
    {
        public static IMovable CreatePlayer(PlayerType playerType)
        {
            return playerType switch
            {
                PlayerType.Player => new Player(),
                PlayerType.Bot => new Bot(),
                _ => throw new ArgumentOutOfRangeException(nameof(playerType), playerType, null)
            };
        }
    }
}