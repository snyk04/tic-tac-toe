using System;
using TicTacToe.Common;
using TicTacToe.PlayField.Logic;
using UnityEngine;

namespace TicTacToe.PlayField.Visual
{
    public class CellFieldVisualComponent : MonoBehaviour
    {
        [SerializeField] private CellFieldComponent _cellField;
        [SerializeField] private CellVisualComponent[] _cellVisuals;
        
        public CellFieldVisual CellFieldVisual { get; private set; }

        
        private void Awake()
        {
            int amountOfCells = _cellVisuals.Length;

            if (amountOfCells != _cellField.CellField.Length)
            {
                throw new ArgumentException("Amount of cell visuals should be equal multiplying the number of " +
                                            "rows by the number of columns");
            }
            
            var cellVisuals = new IWriteOnlyContainer<string>[amountOfCells];
            for (int i = 0; i < amountOfCells; i++)
            {
                cellVisuals[i] = _cellVisuals[i].CellVisual;
            }
            
            CellFieldVisual = new CellFieldVisual(_cellField.CellField, cellVisuals);
        }
    }
}