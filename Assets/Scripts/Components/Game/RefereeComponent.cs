using UnityEngine;

namespace TicTacToe.Game
{
    public class RefereeComponent : MonoBehaviour
    {
        public Referee Referee { get; private set; }

        
        private void Awake()
        {
            Referee = new Referee();
        }
        private void OnDestroy()
        {
            Referee.Dispose();
        }
    }
}