using UnityEngine;

namespace PortfolioCase5
{
    public class ExplosiveBarrel : MonoBehaviour
    {
        [Tooltip("If collision impulse magnitude is >= threshold, player is destroyed.")]
        public float killImpactThreshold = 10f;

        [Tooltip("Optional explosion particle effect.")]
        public ParticleSystem explosionEffect;

        private void OnCollisionEnter(Collision collision)
        {
            if (!collision.collider.CompareTag("Player")) return;

            // Approximate impact "force" using impulse magnitude
            float impact = collision.impulse.magnitude;

            if (impact >= killImpactThreshold)
            {
                if (explosionEffect != null)
                    Instantiate(explosionEffect, transform.position, Quaternion.identity);

                Destroy(collision.collider.gameObject);
            }
        }
    }
}
