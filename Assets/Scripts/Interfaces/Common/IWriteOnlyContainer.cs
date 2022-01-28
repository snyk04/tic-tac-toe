namespace TicTacToe.Common
{
    public interface IWriteOnlyContainer<in T>
    {
        T Value { set; }
    }
}