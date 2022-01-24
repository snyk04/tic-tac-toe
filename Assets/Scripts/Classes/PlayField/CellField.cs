using System;

namespace TicTacToe.PlayField
{
    public class CellField : IIndexable<Symbol>
    {
        public event Action<int, Symbol> OnChange;
        public int Length => _cells.Length;
        
        private IContainer<Symbol>[] _cells;

        
        public CellField(int amountOfRows, int amountOfColumns)
        {
            Initialize(amountOfRows, amountOfColumns);
        }
        
        public Symbol this[int i]
        {
            get => _cells[i].Value;
            set
            {
                if (_cells[i].Value != Symbol.Empty)
                {
                    throw new ApplicationException("You can't override cell's value!");
                }

                _cells[i].Value = value;
                OnChange?.Invoke(i, value);
            }
        }


        private void Initialize(int amountOfRows, int amountOfColumns)
        {
            int amountOfCells = amountOfRows * amountOfColumns;
            _cells = new IContainer<Symbol>[amountOfCells];
            for (int i = 0; i < amountOfCells; i++)
            {
                _cells[i] = new Cell();
            }
        }
    }
}