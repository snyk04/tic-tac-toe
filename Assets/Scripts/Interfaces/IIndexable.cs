namespace TicTacToe
{
    public interface IIndexable<T>
    {
        T this[int i] { get; set; }
    }
}