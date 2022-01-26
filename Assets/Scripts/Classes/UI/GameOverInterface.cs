using TicTacToe.Game;
using TicTacToe.PlayField.Logic;
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
        private void Show(Symbol winnerSymbol)
        {
            _winnerText.text = $"{winnerSymbol} won!";
        }
    }
}