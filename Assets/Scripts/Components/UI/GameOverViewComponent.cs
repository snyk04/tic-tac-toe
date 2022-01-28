using TicTacToe.Game;
using UnityEngine;
using UnityEngine.UI;

namespace TicTacToe.UI
{
    public class GameOverViewComponent : MonoBehaviour
    {
        [SerializeField] private Text _winnerText;
        [SerializeField] private RefereeComponent _referee;
        
        public GameOverView GameOverView { get; private set; }


        private void Awake()
        {
            GameOverView = new GameOverView(_winnerText, _referee.Referee);
        }
    }
}