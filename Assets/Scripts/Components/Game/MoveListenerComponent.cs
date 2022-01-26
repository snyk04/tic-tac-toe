using UnityEngine;

namespace TicTacToe.Game
{
    public class MoveListenerComponent : MonoBehaviour
    {
        [SerializeField] private RefereeComponent _referee;
        
        public MoveListener MoveListener { get; private set; }


        private void Awake()
        {
            MoveListener = new MoveListener(_referee.Referee);
        }

        public void MakeMove(int cellIndex)
        {
            MoveListener.MakeMove(cellIndex);
        }
    }
}