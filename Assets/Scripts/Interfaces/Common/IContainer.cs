namespace TicTacToe.Common
{
    public interface IContainer<T>
    {
        T Value { get; set; }
    }
}