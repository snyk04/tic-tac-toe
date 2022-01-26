using System;
using TicTacToe.Game;
using UnityEngine.UI;

namespace Classes.UI
{
    public class GameOverInterface
    {
        private readonly Text _winnerText;


        public GameOverInterface(Text winnerText, IGameHandler gameHandler)
        {
            _winnerText = winnerText;

            gameHandler.OnGameEnd += Show;
        }
        private void Show(GameEndType gameEndType)
        {
            _winnerText.text = gameEndType switch
            {
                GameEndType.XVictory => "X won!",
                GameEndType.OVictory => "O won!",
                GameEndType.Draw => "Draw!",
                _ => throw new ArgumentOutOfRangeException(nameof(gameEndType), gameEndType, null)
            };
        }
    }
}