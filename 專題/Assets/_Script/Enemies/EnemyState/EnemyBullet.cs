using System;
using Guagua.Nia;
using UnityEngine;

namespace Guagua.Enemies
{
    public class EnemyBullet : MonoBehaviour
    {

        public static event Action<Collider2D> OnEnemyBulletHit;

        [SerializeField] LayerMask Target;

        private Rigidbody2D Rb;

        private int FacingDirection;

        private void Awake()
        {
            Rb = GetComponent<Rigidbody2D>();
            FacingDirection = 1;
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Player"))
            {
                Collider2D detected = Physics2D.OverlapCircle(other.transform.position, 0.3f, Target);

                if (Player.inIFrame)
                    return;

                OnEnemyBulletHit?.Invoke(detected);
                Destroy(gameObject);
            }
            else if (other.CompareTag("Ground"))
            {
                Destroy(gameObject);
            }
        }

        public void CheckWhenToFlip(int direction)
        {
            if (direction != FacingDirection)
            {
                FacingDirection *= -1;
                Rb.transform.Rotate(0.0f, 180.0f, 0.0f);
            }
        }
    }
}
