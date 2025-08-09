using System;
using System.Collections;
using System.Collections.Generic;
using Guagua.CoreSystem;
using UnityEngine;

namespace Guagua.WeaponSystem
{
    public class ActionHitBox : WeaponComponent<ActionHitBoxData, AttackActionHitbox>
    {
        private CoreSystem.Movement movement;

        public event Action<Collider2D[]> OnDetectedCollider2D;

        private Vector2 offset;
        private Collider2D[] detected;

        protected override void Start()
        {
            base.Start();

            movement = Core.GetCoreComponent<CoreSystem.Movement>();

            EventHandler.OnAttackAction += HandleAttackAction;
        }

        private void HandleAttackAction()
        {
            offset.Set(
                transform.position.x + (currentAttackData.HitBox.center.x * movement.FacingDirection),
                transform.position.y + currentAttackData.HitBox.center.y
            );


            detected = Physics2D.OverlapBoxAll(offset, currentAttackData.HitBox.size, 0f, data.DetectableLayers);

            if (detected.Length == 0)
                return;

            OnDetectedCollider2D?.Invoke(detected);
        }

        protected override void OnDestroy()
        {
            base.OnDestroy();

            EventHandler.OnAttackAction -= HandleAttackAction;
        }

        private void OnDrawGizmosSelected()
        {
            if (data == null)
                return;

            foreach (var item in data.AttackData)
            {
                if (!item.debug)
                    continue;

                Gizmos.DrawWireCube(transform.position + (Vector3)item.HitBox.center, item.HitBox.size);
            }
        }
    }
}
