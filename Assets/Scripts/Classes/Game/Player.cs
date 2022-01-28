using TicTacToe.Common;
using TicTacToe.PlayField.Logic;

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

        
        public int GetMove(IIndexable<Symbol> cellField, Symbol symbol)
        {
            while (_waitingForInput) { }
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