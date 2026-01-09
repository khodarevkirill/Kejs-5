using UnityEngine;

namespace PortfolioCase5
{
    public class MovementParticles : MonoBehaviour
    {
        public PlayerController player;
        public ParticleSystem particles;
        public float minSpeedToEmit = 0.1f;

        private void Awake()
        {
            if (player == null) player = GetComponent<PlayerController>();
            if (particles == null) particles = GetComponentInChildren<ParticleSystem>();
        }

        private void Update()
        {
            if (player == null || particles == null) return;

            bool shouldPlay = player.IsGrounded && player.IsMoving;

            if (shouldPlay && !particles.isPlaying) particles.Play();
            if (!shouldPlay && particles.isPlaying) particles.Stop();
        }
    }
}
