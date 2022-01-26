using System;
using TicTacToe.PlayField.Logic;
using UnityEngine;

namespace TicTacToe.Game
{
    public class GameManagerComponent : MonoBehaviour
    {
	    [SerializeField] private RefereeComponent _referee;
        [SerializeField] private CellFieldComponent _cellField;

        [SerializeField] private PlayerType _firstPlayerType;
        [SerializeField] private PlayerType _secondPlayerType;

		public GameManager GameManager { get; private set; }

		
		private void Awake()
		{
			GameManager = new GameManager(_referee.Referee, _cellField.CellField);
		}
		private void Start()
		{
			StartGame();
		}

		public void StartGame()
		{
			GameManager.StartGame(_firstPlayerType, _secondPlayerType);
		}
    }
}