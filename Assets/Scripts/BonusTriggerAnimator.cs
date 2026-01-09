using UnityEngine;

namespace PortfolioCase5
{
    public class BonusTriggerAnimator : MonoBehaviour
    {
        [Tooltip("Animator on the bonus object (not on the trigger collider).")]
        public Animator bonusAnimator;

        [Tooltip("Animator bool parameter name.")]
        public string parameter = "IsActive";

        private void Reset()
        {
            var a = GetComponentInParent<Animator>();
            if (a != null) bonusAnimator = a;
        }

        private void OnTriggerEnter(Collider other)
        {
            if (!other.CompareTag("Player")) return;
            if (bonusAnimator != null)
                bonusAnimator.SetBool(parameter, true);
        }

        private void OnTriggerExit(Collider other)
        {
            if (!other.CompareTag("Player")) return;
            if (bonusAnimator != null)
                bonusAnimator.SetBool(parameter, false);
        }
    }
}
