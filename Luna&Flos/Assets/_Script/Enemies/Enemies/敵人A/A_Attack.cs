using System.Collections;
using System.Collections.Generic;
using Guagua.Nia;
using UnityEngine;

namespace Guagua.Enemies
{
    public class A_Attack : AttackState
    {
        private EnemyA enemy;

        public A_Attack(Entity entity, EnemyStateMachine stateMachine, EnemiesData enemiesData, string animBoolName, EnemyA enemy) : base(entity, stateMachine, enemiesData, animBoolName)
        {
            this.enemy = enemy;

        }

        public override void Enter()
        {
            base.Enter();
        }

        public override void LogicUpdate()
        {
            base.LogicUpdate();
        }

        public override void HandleAction()
        {
            base.HandleAction();

            detected = Physics2D.OverlapCircleAll(EnemyCollision.Attackposition.position,
                            EnemyCollision.attackRadius, EnemyCollision.whatIsPlayer);

            foreach (var item in detected)
            {
                if (Player.inIFrame)
                    return;

                AttackAction(item, enemiesData.Amount, Movement.FacingDirection, enemiesData.Force, enemiesData.Angle);
            }
        }

        public override void Exit()
        {
            base.Exit();
        }

        public override void AnimationFinTrigger()
        {
            base.AnimationFinTrigger();

            if (!isPlayerInAttackRange)
            {
                stateMachine.ChangeState(enemy.detectedstate);
            }
        }




    }
}
