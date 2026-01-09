using UnityEngine;

namespace PortfolioCase5
{
    public class MovingHazard : MonoBehaviour
    {
        public Vector3 pointA;
        public Vector3 pointB;
        public float speed = 2f;
        public bool pingPong = true;

        private float _t;

        private void Start()
        {
            // If points not set, use local offsets
            if (pointA == Vector3.zero && pointB == Vector3.zero)
            {
                pointA = transform.position;
                pointB = transform.position + new Vector3(4f, 0f, 0f);
            }
        }

        private void Update()
        {
            if (pingPong)
            {
                _t += Time.deltaTime * speed / Mathf.Max(0.01f, Vector3.Distance(pointA, pointB));
                float u = Mathf.PingPong(_t, 1f);
                transform.position = Vector3.Lerp(pointA, pointB, u);
            }
            else
            {
                _t += Time.deltaTime * speed;
                transform.position = Vector3.Lerp(pointA, pointB, Mathf.Clamp01(_t));
            }
        }
    }
}
