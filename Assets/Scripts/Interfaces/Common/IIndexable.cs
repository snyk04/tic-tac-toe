using System;

namespace TicTacToe.Common
{
    public interface IIndexable<T>
    {
        event Action<int, T> OnChange;
        T this[int i] { get; set; }
        int Length { get; }

        IIndexable<T> Copy();
    }
}