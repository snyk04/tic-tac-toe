﻿using TicTacToe.Common;
using TicTacToe.PlayField.Logic;
using UnityEngine;

namespace TicTacToe.Game
{
    public class Player : IControllable
    {
        private bool _waitingForInput;
        private int _move;

        
        public Player()
        {
            _waitingForInput = true;
        }

        
        public int GetMove(IIndexable<Symbol> cellField)
        {
            while (_waitingForInput)
            {
                Debug.Log("i'm waiting for input!!!");
            }
            _waitingForInput = true;
            
            return _move;
        }
        public void SetMove(int cellIndex)
        {
            _move = cellIndex;
            _waitingForInput = false;
        }
    }
}