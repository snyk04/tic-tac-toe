using TicTacToe.PlayField;
using UnityEngine;

namespace Components.PlayField
{
    public class CellFieldComponent : MonoBehaviour
    {
        [SerializeField] private int _amountOfRows;
        [SerializeField] private int _amountOfColumns;
        
        public CellField CellField { get; private set; }


        private void Awake()
        {
            CellField = new CellField(_amountOfRows, _amountOfColumns);
        }


        public void SetCellValue(int cellIndex)
        {
            CellField[cellIndex] = Symbol.X;
        }
    }
}