using UnityEngine;
using UnityEngine.UI;

namespace PortfolioCase5
{
    [RequireComponent(typeof(Text))]
    public class WalletUI : MonoBehaviour
    {
        public string prefix = "Coins: ";
        private Text _text;

        private void Awake()
        {
            _text = GetComponent<Text>();
        }

        private void Update()
        {
            if (Wallet.Instance == null)
            {
                _text.text = prefix + "0";
                return;
            }

            _text.text = prefix + Wallet.Instance.Coins.ToString();
        }
    }
}
