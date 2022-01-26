using Classes.UI;
using TicTacToe.Game;
using UnityEngine;
using UnityEngine.UI;

namespace TicTacToe.UI
{
    public class GameOverInterfaceComponent : MonoBehaviour
    {
        [SerializeField] private Text _winnerText;
        [SerializeField] private RefereeComponent _referee;
        
        public GameOverInterface GameOverInterface { get; private set; }


        private void Awake()
        {
            GameOverInterface = new GameOverInterface(_winnerText, _referee.Referee);
        }
    }
}