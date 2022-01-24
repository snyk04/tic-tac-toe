using UnityEngine.UI;

namespace TicTacToe.PlayField
{
    public class CellVisual : IContainer<string>
    {
        private readonly Text _valueText;
        private readonly Button _cellButton;
        
        
        public CellVisual(Text valueText, Button cellButton)
        {
            _valueText = valueText;
            _cellButton = cellButton;
        }

        
        public string Value
        {
            get => _valueText.text;
            set
            {
                _valueText.text = value;
                _cellButton.interactable = false;
            }
        }
    }
}