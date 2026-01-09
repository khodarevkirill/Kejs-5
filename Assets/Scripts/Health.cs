using UnityEngine;
using UnityEngine.Events;

namespace PortfolioCase5
{
    public class Health : MonoBehaviour
    {
        public int maxHp = 100;
        public int currentHp;

        public UnityEvent<int, int> onHpChanged;
        public UnityEvent onDied;

        private void Awake()
        {
            currentHp = Mathf.Clamp(currentHp <= 0 ? maxHp : currentHp, 0, maxHp);
            onHpChanged?.Invoke(currentHp, maxHp);
        }

        public void Damage(int amount)
        {
            if (amount <= 0 || currentHp <= 0) return;

            currentHp = Mathf.Max(0, currentHp - amount);
            onHpChanged?.Invoke(currentHp, maxHp);

            if (currentHp == 0)
                onDied?.Invoke();
        }

        public void Heal(int amount)
        {
            if (amount <= 0 || currentHp <= 0) return;

            currentHp = Mathf.Min(maxHp, currentHp + amount);
            onHpChanged?.Invoke(currentHp, maxHp);
        }
    }
}
