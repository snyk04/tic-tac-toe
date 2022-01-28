using TicTacToe.Common;
using UnityEngine.UI;

namespace TicTacToe.PlayField.Visual
{
    public class CellVisual : IWriteOnlyContainer<string>
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
            set
            {
                UnityMainThreadDispatcher.Instance().Enqueue(() =>
                {
                    _valueText.text = value;
                    _cellButton.interactable = false;
                });
            }
        }
    }
}