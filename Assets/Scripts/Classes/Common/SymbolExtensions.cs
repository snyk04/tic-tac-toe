using System;
using TicTacToe.PlayField.Logic;

namespace TicTacToe.Common
{
    public static class SymbolExtensions
    {
        public static Symbol GetOpponentSymbol(this Symbol symbol)
        {
            return symbol switch
            {
                Symbol.X => Symbol.O,
                Symbol.O => Symbol.X,
                Symbol.Empty => throw new ArgumentException("There is no opponent for empty cell!"),
                _ => throw new ArgumentException()
            };
        }
    }
}