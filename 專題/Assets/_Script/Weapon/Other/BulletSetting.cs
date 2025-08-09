using System;
using UnityEngine;

namespace Guagua.WeaponSystem
{
    public class BulletSetting : MonoBehaviour
    {

        public static event Action<Collider2D[]> OnBulletHit;

        [SerializeField] LayerMask Target;
        [SerializeField] Vector2 Size;

        private Rigidbody2D Rb;

        private int FacingDirection;

        private void Awake()
        {
            Rb = GetComponent<Rigidbody2D>();
            FacingDirection = 1;
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Enemy"))
            {
                Collider2D[] detected = Physics2D.OverlapBoxAll(other.transform.position, Size, 0f, Target);

                if (detected.Length == 0)
                    return;

                OnBulletHit?.Invoke(detected);

                Destroy(gameObject);
            }
            else
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
