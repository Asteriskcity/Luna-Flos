using System;
using UnityEngine;

namespace Guagua.Enemies
{
    public class AttackState : EnemyState
    {

        public event Action OnAttackAction;

        protected bool isPlayerInAttackRange;
        //protected bool isStillCanAttack;
        //protected bool CanAttack;

        protected Collider2D[] detected;

        public AttackState(Entity entity, EnemyStateMachine stateMachine, EnemiesData enemiesData, string animBoolName) : base(entity, stateMachine, enemiesData, animBoolName)
        {
        }

        public override void DoChecks()
        {
            base.DoChecks();

            isPlayerInAttackRange = EnemyCollision.PlayerInAttackRange;
        }

        public override void Enter()
        {
            base.Enter();

            OnAttackAction += HandleAction;
        }

        public override void LogicUpdate()
        {
            base.LogicUpdate();

            Movement.SetVelocityZero();
        }

        public override void Exit()
        {
            base.Exit();

            OnAttackAction -= HandleAction;
        }

        public override void ActionTrigger()
        {
            base.ActionTrigger();

            OnAttackAction?.Invoke();
        }


        public virtual void HandleAction() { }


        public void AttackAction(Collider2D item, float damage, int direction, float force, Vector2 angle)
        {
            if (item.TryGetComponent(out IDamageable damageable))
            {
                damageable.Damage(damage);
            }

            if (item.TryGetComponent(out IKnockback knockable))
            {
                knockable.KnockBack(direction, force, angle);
            }
        }




    }
}
