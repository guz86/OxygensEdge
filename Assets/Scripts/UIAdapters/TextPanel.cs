using TMPro;
using UnityEngine;

namespace UI
{
    public class TextPanel : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _amountText;

        public void SetupValue(string amount)
        {
            _amountText.text = amount;
        }
        
        public void UpdateValue(string amount)
        {
            _amountText.text = amount;
        }
    }
}