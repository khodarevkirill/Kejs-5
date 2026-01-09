using UnityEngine;

namespace PortfolioCase5
{
    public class DamageOnContact : MonoBehaviour
    {
        public int damage = 10;
        public float damageCooldown = 0.5f;

        private float _nextTime;

        private void OnCollisionStay(Collision collision)
        {
            if (!collision.collider.CompareTag("Player")) return;
            if (Time.time < _nextTime) return;

            var hp = collision.collider.GetComponent<Health>();
            if (hp != null)
            {
                hp.Damage(damage);
                _nextTime = Time.time + damageCooldown;

                if (hp.currentHp <= 0)
                    Destroy(collision.collider.gameObject);
            }
        }
    }
}
