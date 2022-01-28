using System;
using TicTacToe.Game;
using UnityEngine.UI;

namespace TicTacToe.UI
{
    public class GameOverView
    {
        private readonly Text _winnerText;


        public GameOverView(Text winnerText, IGameHandler gameHandler)
        {
            _winnerText = winnerText;

            gameHandler.OnGameEnd += Show;
        }
        private void Show(GameEndType gameEndType)
        {
            UnityMainThreadDispatcher.Instance().Enqueue(() =>
            {
                _winnerText.text = gameEndType switch
                {
                    GameEndType.XVictory => "X won!",
                    GameEndType.OVictory => "O won!",
                    GameEndType.Draw => "Draw!",
                    _ => throw new ArgumentOutOfRangeException(nameof(gameEndType), gameEndType, null)
                };
            });
        }
    }
}