using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Guagua.WeaponSystem
{
    public class FireShot : WeaponComponent<FireShotData, AttackFireShot>
    {

        private CoreSystem.Movement movement;

        protected override void Start()
        {
            base.Start();

            movement = Core.GetCoreComponent<CoreSystem.Movement>();
            EventHandler.OnFireAction += HandleFireAction;
        }


        private void HandleFireAction()
        {
            GameObject newbullet = Instantiate(currentAttackData.Bullet,
                                        transform.position + (Vector3)currentAttackData.Offset, Quaternion.identity);

            newbullet.GetComponent<BulletSetting>().CheckWhenToFlip(movement.FacingDirection);
            newbullet.GetComponent<Rigidbody2D>().velocity = new Vector2(movement.FacingDirection * currentAttackData.Speed, 0);
        }

        protected override void OnDestroy()
        {
            base.OnDestroy();

            EventHandler.OnFireAction -= HandleFireAction;
        }

        private void OnDrawGizmosSelected()
        {
            if (data == null)
                return;

            foreach (var item in data.AttackData)
            {
                if (!item.debug)
                    continue;

                Gizmos.DrawWireSphere(transform.position + (Vector3)currentAttackData.Offset, currentAttackData.Radius);
            }
        }
    }
}
