namespace TicTacToe.PlayField
{
    public class CellFieldVisual
    {
        private readonly IContainer<string>[] _cellVisuals;
        
        
        public CellFieldVisual(IIndexable<Symbol> cellField, IContainer<string>[] cellVisuals)
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