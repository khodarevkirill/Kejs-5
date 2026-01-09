using UnityEngine;

namespace PortfolioCase5
{
    public class Wallet : MonoBehaviour
    {
        public static Wallet Instance { get; private set; }

        public int Coins { get; private set; }

        private void Awake()
        {
            if (Instance != null && Instance != this)
            {
                Destroy(gameObject);
                return;
            }
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }

        public void AddCoin(int amount = 1)
        {
            Coins += Mathf.Max(0, amount);
        }

        public void ResetWallet()
        {
            Coins = 0;
        }
    }
}
