namespace TicTacToe
{
    public interface IContainer<T>
    {
        T Value { get; set; }
    }
}