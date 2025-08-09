using System;
using Guagua.CoreSystem;
using UnityEngine;


namespace Guagua.Enemies
{
    public class EnemyB : Entity
    {
        public B_Idle idlestate { get; private set; }
        public B_Move movestate { get; private set; }
        public B_DetectedPlayer detectedstate { get; private set; }
        public B_Shoot shootstate { get; private set; }
        public B_GetHit gethitstate { get; private set; }

        public DeadState deadstate { get; private set; }


        public override void Awake()
        {
            base.Awake();

            idlestate = new B_Idle(this, stateMachine, enemiesData, "idle", this);
            movestate = new B_Move(this, stateMachine, enemiesData, "move", this);
            detectedstate = new B_DetectedPlayer(this, stateMachine, enemiesData, "move", this);
            shootstate = new B_Shoot(this, stateMachine, enemiesData, "shoot", this);
            gethitstate = new B_GetHit(this, stateMachine, enemiesData, "gethit", this);

            deadstate = new DeadState(this, stateMachine, enemiesData, "dead");
        }

        public override void Start()
        {
            base.Start();

            stateMachine.Initialize(idlestate);

            stats.OnGetHit += HandleGetHit;
            stats.OnDeath += HandleDeath;
            EnemyBullet.OnEnemyBulletHit += HandleBulletDamage;
        }

        public override void OnDestroy()
        {
            base.OnDestroy();

            stats.OnGetHit -= HandleGetHit;
            stats.OnDeath -= HandleDeath;
            EnemyBullet.OnEnemyBulletHit -= HandleBulletDamage;
        }

        private void HandleDeath()
        {
            stateMachine.ChangeState(deadstate);
        }

        private void HandleGetHit()
        {
            stateMachine.ChangeState(gethitstate);
        }


        private void HandleBulletDamage(Collider2D item)
        {
            if (item.TryGetComponent(out IDamageable damageable))
            {
                damageable.Damage(enemiesData.BulletDamage);
            }

            if (item.TryGetComponent(out IKnockback knockable))
            {
                knockable.KnockBack(movement.FacingDirection, enemiesData.Force, enemiesData.Angle);
            }
        }


        public override void OnDrawGizmos()
        {
            base.OnDrawGizmos();

            if (Core != null)
            {
                Gizmos.DrawWireSphere(transform.position, enemyCollision.playerDistance);
                Gizmos.DrawWireSphere(transform.position, enemyCollision.attackRadius);
            }
        }
    }
}
