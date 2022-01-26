using System;
using TicTacToe.Common;
using TicTacToe.PlayField.Logic;

namespace TicTacToe.Game
{
    public class Bot : IMovable
    {
        public int GetMove(IIndexable<Symbol> cellField)
        {
            for (int i = 0; i < cellField.Length; i++)
            {
                if (cellField[i] == Symbol.Empty)
                {
                    return i;
                }
            }

            throw new NotImplementedException();
        }
    }
}