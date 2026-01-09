using UnityEngine;

namespace PortfolioCase5
{
    public class Coin : MonoBehaviour
    {
        public int value = 1;
        public ParticleSystem pickupEffect;

        private void OnTriggerEnter(Collider other)
        {
            if (!other.CompareTag("Player")) return;

            if (Wallet.Instance != null)
                Wallet.Instance.AddCoin(value);

            if (pickupEffect != null)
                Instantiate(pickupEffect, transform.position, Quaternion.identity);

            Destroy(gameObject);
        }
    }
}
