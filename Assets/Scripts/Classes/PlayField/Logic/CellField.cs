using System;
using TicTacToe.Common;

namespace TicTacToe.PlayField.Logic
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
        public CellField(IContainer<Symbol>[] cells)
        {
            _cells = cells;
        }
        
        public Symbol this[int i]
        {
            get => _cells[i].Value;
            set
            {
                _cells[i].Value = value;
                OnChange?.Invoke(i, value);
            }
        }

        
        public IIndexable<Symbol> Copy()
        {
            return new CellField(_cells);
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