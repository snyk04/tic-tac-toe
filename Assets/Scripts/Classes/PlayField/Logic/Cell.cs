namespace TicTacToe.PlayField.Logic
{
    public class Cell : IContainer<Symbol>
    {
        public Symbol Value { get; set; }

        
        public Cell(Symbol value = Symbol.Empty)
        {
            Value = value;
        }
    }
}