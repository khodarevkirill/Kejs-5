using UnityEngine;

namespace PortfolioCase5
{
    [RequireComponent(typeof(Rigidbody))]
    public class PlayerController : MonoBehaviour
    {
        [Header("Movement")]
        public float moveSpeed = 6f;
        public float jumpForce = 6.5f;
        public Transform groundCheck;
        public float groundCheckRadius = 0.18f;
        public LayerMask groundMask = ~0;

        private Rigidbody _rb;
        private Vector3 _move;
        private bool _jumpRequested;

        public bool IsMoving { get; private set; }
        public bool IsGrounded { get; private set; }

        private void Awake()
        {
            _rb = GetComponent<Rigidbody>();
            if (groundCheck == null)
            {
                // fallback: create on the fly
                var gc = new GameObject("GroundCheck");
                gc.transform.SetParent(transform);
                gc.transform.localPosition = new Vector3(0, -0.9f, 0);
                groundCheck = gc.transform;
            }
        }

        private void Update()
        {
            float h = Input.GetAxisRaw("Horizontal");
            float v = Input.GetAxisRaw("Vertical");

            _move = new Vector3(h, 0f, v).normalized;
            IsMoving = _move.sqrMagnitude > 0.01f;

            if (Input.GetKeyDown(KeyCode.Space))
                _jumpRequested = true;
        }

        private void FixedUpdate()
        {
            IsGrounded = Physics.CheckSphere(groundCheck.position, groundCheckRadius, groundMask, QueryTriggerInteraction.Ignore);

            // Move (X,Z)
            Vector3 desired = new Vector3(_move.x * moveSpeed, _rb.velocity.y, _move.z * moveSpeed);
            _rb.velocity = desired;

            // Face move direction
            if (_move.sqrMagnitude > 0.01f)
            {
                Quaternion look = Quaternion.LookRotation(_move, Vector3.up);
                transform.rotation = Quaternion.Slerp(transform.rotation, look, 0.2f);
            }

            // Jump
            if (_jumpRequested && IsGrounded)
            {
                _rb.velocity = new Vector3(_rb.velocity.x, 0f, _rb.velocity.z);
                _rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            }
            _jumpRequested = false;
        }
    }
}
