using System;
using Guagua.Nia;
using UnityEngine;


namespace Guagua.Enemies
{
    public class ShootState : EnemyState
    {

        public event Action OnAttackAction;

        protected bool isPlayerInAttackRange;

        public ShootState(Entity entity, EnemyStateMachine stateMachine, EnemiesData enemiesData, string animBoolName) : base(entity, stateMachine, enemiesData, animBoolName)
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

            OnAttackAction += FireAction;
        }

        public override void LogicUpdate()
        {
            base.LogicUpdate();

            Movement.SetVelocityZero();
        }

        public override void Exit()
        {
            base.Exit();

            OnAttackAction -= FireAction;
        }



        public override void ActionTrigger()
        {
            base.ActionTrigger();

            OnAttackAction?.Invoke();
        }

        public virtual void FireAction() { }

        public virtual void DamageAction(Collider2D item) { }

    }
}
