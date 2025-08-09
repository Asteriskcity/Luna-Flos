using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Guagua.Enemies
{
    public class A_DetectedPlayer : DetectPlayerState
    {

        private EnemyA enemy;

        public A_DetectedPlayer(Entity entity, EnemyStateMachine stateMachine, EnemiesData enemiesData, string animBoolName, EnemyA enemy) : base(entity, stateMachine, enemiesData, animBoolName)
        {
            this.enemy = enemy;
        }

        public override void DoChecks()
        {
            base.DoChecks();
        }

        public override void Enter()
        {
            base.Enter();
        }

        public override void LogicUpdate()
        {
            base.LogicUpdate();

            if (isPlayerInAttackRange)
            {
                stateMachine.ChangeState(enemy.attackstate);
            }
            else if (EnemyCollision.CheckPlayerDistance() >= enemiesData.MaxTracingRange)
            {
                stateMachine.ChangeState(enemy.idlestate);
            }
            else if (!isDetectedLedge || isDetectedWall)
            {
                stateMachine.ChangeState(enemy.idlestate);
            }
        }

        public override void PhysicsUpdate()
        {
            base.PhysicsUpdate();

            Movement.SetVelocityX((enemiesData.movespeed + 2f) * Movement.FacingDirection);
        }
    }
}
