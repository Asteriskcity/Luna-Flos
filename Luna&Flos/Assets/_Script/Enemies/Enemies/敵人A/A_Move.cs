using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Guagua.Enemies
{
    public class A_Move : MoveState
    {
        private EnemyA enemy;


        public A_Move(Entity entity, EnemyStateMachine stateMachine, EnemiesData enemiesData, string animBoolName, EnemyA enemy) : base(entity, stateMachine, enemiesData, animBoolName)
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

            if (isDetectedplayer)
            {
                stateMachine.ChangeState(enemy.detectedstate);
            }
            else if (!isDetectedLedge || isDetectedWall)
            {
                Movement.Flip();
            }
            else if (isMovingTimesup)
            {
                stateMachine.ChangeState(enemy.idlestate);
            }
        }

        public override void PhysicsUpdate()
        {
            base.PhysicsUpdate();

            Movement.SetVelocityX(enemiesData.movespeed * Movement.FacingDirection);
        }

    }
}
