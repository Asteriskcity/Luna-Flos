using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Guagua.WeaponSystem
{
    public class Damage : WeaponComponent<DamageData, AttackDamage>
    {
        private ActionHitBox hitBox;

        private CoreSystem.Movement movement;

        private void HandleDetectedCollider2D(Collider2D[] colliders)
        {

            foreach (var item in colliders)
            {
                print($"Detected Item:{item.name}");

                if (item.TryGetComponent(out IDamageable damageable))
                {
                    damageable.Damage(currentAttackData.Amount);
                }

                if (item.TryGetComponent(out IKnockback knockable))
                {
                    knockable.KnockBack(movement.FacingDirection, currentAttackData.force, currentAttackData.angle);
                }

            }
        }

        protected override void Start()
        {
            base.Start();

            hitBox = GetComponent<ActionHitBox>();

            movement = Core.GetCoreComponent<CoreSystem.Movement>();

            hitBox.OnDetectedCollider2D += HandleDetectedCollider2D;
            BulletSetting.OnBulletHit += HandleDetectedCollider2D;
        }

        protected override void OnDestroy()
        {
            base.OnDestroy();

            hitBox.OnDetectedCollider2D -= HandleDetectedCollider2D;
            BulletSetting.OnBulletHit -= HandleDetectedCollider2D;
        }
    }
}
