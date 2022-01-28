using TicTacToe.Common;
using TicTacToe.PlayField.Logic;

namespace TicTacToe.PlayField.Visual
{
    public class CellFieldVisual
    {
        private readonly IWriteOnlyContainer<string>[] _cellVisuals;
        
        
        public CellFieldVisual(IIndexable<Symbol> cellField, IWriteOnlyContainer<string>[] cellVisuals)
        {
            _cellVisuals = cellVisuals;

            cellField.OnChange += UpdateCellValue;
        }

        
        private void UpdateCellValue(int cellIndex, Symbol value)
        {
            _cellVisuals[cellIndex].Value = value.ToString();
        }
    }
}