using UnityEngine;
using UnityEngine.UI;

namespace TicTacToe.PlayField.Visual
{
    public class CellVisualComponent : MonoBehaviour
    {
        [SerializeField] private Text _valueText;
        [SerializeField] private Button _cellButton;
        
        public CellVisual CellVisual { get; private set; }

        
        private void Awake()
        {
            CellVisual = new CellVisual(_valueText, _cellButton);
        }
    }
}