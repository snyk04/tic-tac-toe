using System;

namespace TicTacToe
{
    public interface IIndexable<T>
    {
        event Action<int, T> OnChange;
        T this[int i] { get; set; }
        int Length { get; }
    }
}