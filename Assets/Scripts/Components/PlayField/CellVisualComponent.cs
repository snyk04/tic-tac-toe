using TicTacToe.PlayField;
using UnityEngine;
using UnityEngine.UI;

namespace Components.PlayField
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